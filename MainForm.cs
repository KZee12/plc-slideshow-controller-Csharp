using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using S7.Net;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace PLCSlideshowController
{
    public partial class MainForm : Form
    {
        // --- SOP State Machine ---
        private enum SOPState { Idle, WaitingForStartSignal, WaitingForPick, PlaceInProgress, ProcessOver, WaitingForStartReset }
        private SOPState currentState = SOPState.Idle;
        private SopConfiguration currentSOP;
        private int currentStepIndex = 0;
        private bool isPaused = false;
        private int currentStepNumberForPlc = 0;
        private int currentPtlNumberForPlc = 0;
        private bool isPickSlideActive = false;
        private bool isPlaceSlideActive = false;

        // --- PLC and Monitoring Variables ---
        private Plc plcClient;
        private bool isConnected = false;
        private bool isMonitoring = false;
        private Thread monitorThread;
        private byte lastControlByte = 0;
        private PlcMonitorForm plcMonitorForm;

        // --- Slideshow Application Control ---
        private PowerPoint.Application slideshowApp;
        private PowerPoint.Presentation slideshowPresentation;
        private int currentSlideshowIndex = -1;
        private string currentlySelectedSopPath;
        private BindingList<AssemblyStep> currentStepsBindingList;

        // --- Configuration and Mappings ---
        private Dictionary<int, string> slideMappings = new Dictionary<int, string>();
        private string userConfigDirectory;
        private string slidesDirectory;
        private string mappingsFilePath;

        public MainForm()
        {
            InitializeComponent();
            InitializeAppPaths(); // This must be called first
            SetupSopGridView();
            SetStartup();
            LoadConfig();
            LoadSlideMappings();
            UpdateSlideMappingsUI();
            officeSuiteComboBox.SelectedIndex = 1;
        }

        private void InitializeAppPaths()
        {
            string appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "PLCSlideshowController");
            Directory.CreateDirectory(appDataFolder);

            userConfigDirectory = appDataFolder;
            slidesDirectory = Path.Combine(userConfigDirectory, "slides");
            Directory.CreateDirectory(slidesDirectory);
            mappingsFilePath = Path.Combine(userConfigDirectory, "slide_mappings.txt");
        }

        private void SetupSopGridView()
        {
            sopStepsGridView.AutoGenerateColumns = false;
            sopStepsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            sopStepsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            sopStepsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StepNumber",
                HeaderText = "Step #",
                DataPropertyName = "StepNumber",
                FillWeight = 10,
                ReadOnly = true // Step number is automatic
            });
            sopStepsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PickSlide",
                HeaderText = "Pick Slide",
                DataPropertyName = "PickSlide",
                FillWeight = 15
            });
            sopStepsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PlaceSlide",
                HeaderText = "Place Slide",
                DataPropertyName = "PlaceSlide",
                FillWeight = 15
            });
            sopStepsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PtlNumber",
                HeaderText = "PTL #",
                DataPropertyName = "PtlNumber",
                FillWeight = 10
            });
            sopStepsGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CycleTimeSeconds",
                HeaderText = "Cycle (s)",
                DataPropertyName = "CycleTimeSeconds",
                FillWeight = 15
            });
            sopStepsGridView.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "IsVideo",
                HeaderText = "Is Video",
                DataPropertyName = "IsVideo",
                FillWeight = 10
            });
        }

        private void SetStartup()
        {
            try
            {
                string appName = "PLCSlideshowController";
                string appPath = Application.ExecutablePath;
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                rk.SetValue(appName, appPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not set application to run at startup: {ex.Message}", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Configuration Management
        private void LoadConfig()
        {
            string configPath = Path.Combine(userConfigDirectory, "config.ini");
            if (File.Exists(configPath))
            {
                var lines = File.ReadAllLines(configPath);
                var config = lines.Select(line => line.Split('=')).ToDictionary(parts => parts[0].Trim(), parts => parts[1].Trim());
                if (config.ContainsKey("PLC_IP")) ipAddressTextBox.Text = config["PLC_IP"];
                if (config.ContainsKey("DB_Number")) dbNumberTextBox.Text = config["DB_Number"];
            }
            else
            {
                ipAddressTextBox.Text = "192.168.1.100";
                dbNumberTextBox.Text = "1";
                SaveConfig();
            }
        }

        private void SaveConfig()
        {
            string configPath = Path.Combine(userConfigDirectory, "config.ini");
            string[] lines = { $"PLC_IP = {ipAddressTextBox.Text}", $"DB_Number = {dbNumberTextBox.Text}" };
            File.WriteAllLines(configPath, lines);
        }

        private void LoadSlideMappings()
        {
            slideMappings.Clear();
            if (File.Exists(mappingsFilePath))
            {
                var lines = File.ReadAllLines(mappingsFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { '=' }, 2);
                    if (parts.Length == 2 && int.TryParse(parts[0], out int index) && File.Exists(parts[1]))
                    {
                        slideMappings[index] = parts[1];
                    }
                }
            }
        }

        private void SaveSlideMappings()
        {
            var lines = slideMappings.Select(kvp => $"{kvp.Key}={kvp.Value}");
            File.WriteAllLines(mappingsFilePath, lines);
        }
        #endregion

        #region UI Event Handlers
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (isConnected) DisconnectPlc(); else ConnectPlc();
        }

        private void addMappingButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(mappingIndexTextBox.Text, out int index) || index < 0 || index > 255)
            {
                MessageBox.Show("Please enter a valid index (0-255).", "Invalid Index", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Presentation Files|*.pptx;*.ppsx;*.odp|All Files|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string destinationPath = Path.Combine(slidesDirectory, Path.GetFileName(ofd.FileName));
                    File.Copy(ofd.FileName, destinationPath, true);
                    slideMappings[index] = destinationPath;
                    SaveSlideMappings();
                    UpdateSlideMappingsUI();
                }
            }
        }

        private void removeMappingButton_Click(object sender, EventArgs e)
        {
            if (mappingsListView.SelectedItems.Count > 0)
            {
                var selectedItem = mappingsListView.SelectedItems[0];
                int index = int.Parse(selectedItem.SubItems[0].Text);
                if (slideMappings.ContainsKey(index))
                {
                    slideMappings.Remove(index);
                    SaveSlideMappings();
                    UpdateSlideMappingsUI();
                    ClearSopEditor();
                }
            }
        }

        private void simulationButton_Click(object sender, EventArgs e)
        {
            ToggleSimulationMode(true);
            using (var simForm = new SimulationForm(this))
            {
                simForm.ShowDialog();
            }
        }

        private void monitorWindowButton_Click(object sender, EventArgs e)
        {
            if (plcMonitorForm == null || plcMonitorForm.IsDisposed)
            {
                plcMonitorForm = new PlcMonitorForm();
                plcMonitorForm.Show();
            }
            else
            {
                plcMonitorForm.Focus();
            }
        }

        private void mappingsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mappingsListView.SelectedItems.Count > 0)
            {
                var selectedItem = mappingsListView.SelectedItems[0];
                int index = int.Parse(selectedItem.SubItems[0].Text);
                if (slideMappings.TryGetValue(index, out string path))
                {
                    currentlySelectedSopPath = path;
                    LoadSopForSelectedSlideshow();
                }
            }
            else
            {
                ClearSopEditor();
            }
        }

        private void addStepButton_Click(object sender, EventArgs e)
        {
            if (currentStepsBindingList != null)
            {
                currentStepsBindingList.Add(new AssemblyStep { StepNumber = currentStepsBindingList.Count + 1 });
            }
        }

        private void removeStepButton_Click(object sender, EventArgs e)
        {
            if (sopStepsGridView.SelectedRows.Count > 0)
            {
                var stepToRemove = (AssemblyStep)sopStepsGridView.SelectedRows[0].DataBoundItem;
                currentStepsBindingList.Remove(stepToRemove);

                // Re-number steps
                for (int i = 0; i < currentStepsBindingList.Count; i++)
                {
                    currentStepsBindingList[i].StepNumber = i + 1;
                }
            }
        }

        private void saveSopButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentlySelectedSopPath))
            {
                MessageBox.Show("Please select a slideshow before saving an SOP.", "No Slideshow Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(endSlideTextBox.Text, out int endSlide))
            {
                MessageBox.Show("Please enter a valid number for the end slide.", "Invalid End Slide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var sopConfig = new SopConfiguration
            {
                EndSlide = endSlide,
                Steps = currentStepsBindingList.ToList()
            };

            string configPath = currentlySelectedSopPath + ".json";
            string json = JsonConvert.SerializeObject(sopConfig, Formatting.Indented);
            File.WriteAllText(configPath, json);
            MessageBox.Show("SOP saved successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HandleEndSlideshow();
            DisconnectPlc();
        }
        #endregion

        #region PLC Communication
        private void ConnectPlc()
        {
            try
            {
                plcClient = new Plc(CpuType.S71200, ipAddressTextBox.Text, 0, 1);
                plcClient.Open();
                isConnected = true;
                lastControlByte = 0;

                connectionStatusLabel.Text = "Connected";
                connectionStatusLabel.ForeColor = Color.Green;
                connectButton.Text = "Disconnect";
                SaveConfig();
                StartMonitoring();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to connect to PLC: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisconnectPlc()
        {
            if (isMonitoring) StopMonitoring();
            plcClient?.Close();
            isConnected = false;
            connectionStatusLabel.Text = "Disconnected";
            connectionStatusLabel.ForeColor = Color.Red;
            connectButton.Text = "Connect";
        }

        private void StartMonitoring()
        {
            isMonitoring = true;
            monitorThread = new Thread(MonitorLoop) { IsBackground = true };
            monitorThread.Start();
        }

        private void StopMonitoring()
        {
            isMonitoring = false;
            monitorThread?.Join();
        }

        private void MonitorLoop()
        {
            while (isMonitoring)
            {
                try
                {
                    if (!int.TryParse(dbNumberTextBox.Text, out int dbNumber)) continue;

                    var allData = (byte[])plcClient.ReadBytes(DataType.DataBlock, dbNumber, 0, 5);
                    byte controlByte = allData[0];
                    byte index = allData[1];
                    byte feedbackByte = allData[2];
                    byte stepNumber = allData[3];
                    byte ptlNumber = allData[4];

                    if (plcMonitorForm != null && !plcMonitorForm.IsDisposed)
                    {
                        plcMonitorForm.UpdateMonitor(controlByte, feedbackByte, stepNumber, ptlNumber);
                    }

                    bool startBit = (controlByte & 1) == 1;
                    bool nextBit = (controlByte & 2) == 2;
                    bool pauseBit = (controlByte & 4) == 4;
                    bool endBit = (controlByte & 8) == 8;

                    bool startRisingEdge = startBit && !((lastControlByte & 1) == 1);
                    bool nextRisingEdge = nextBit && !((lastControlByte & 2) == 2);
                    bool pauseRisingEdge = pauseBit && !((lastControlByte & 4) == 4);
                    bool endRisingEdge = endBit && !((lastControlByte & 8) == 8);

                    if (currentState == SOPState.WaitingForStartReset && !startBit)
                    {
                        currentState = SOPState.ProcessOver;
                    }

                    if (startRisingEdge) this.Invoke((MethodInvoker)delegate { HandleStartSignal(index); });
                    if (nextRisingEdge) this.Invoke((MethodInvoker)delegate { HandleNextSignal(); });
                    if (pauseRisingEdge) this.Invoke((MethodInvoker)delegate { HandlePauseResume(); });
                    if (endRisingEdge) this.Invoke((MethodInvoker)delegate { HandleEndSlideshow(); });

                    lastControlByte = controlByte;
                    this.Invoke((MethodInvoker)delegate { plcIndexLabel.Text = index.ToString(); });

                    if (plcClient.IsConnected)
                    {
                        plcClient.Write($"DB{dbNumber}.DBB3", (byte)currentStepNumberForPlc);
                        plcClient.Write($"DB{dbNumber}.DBB4", (byte)currentPtlNumberForPlc);
                    }
                }
                catch { }
                Thread.Sleep(100);
            }
        }

        private void UpdatePlcFeedbackState()
        {
            if (!int.TryParse(dbNumberTextBox.Text, out int dbNumber) || plcClient == null || !plcClient.IsConnected) return;

            byte stateByte = 0;
            if (isPickSlideActive) stateByte |= (1 << 5);
            if (isPlaceSlideActive) stateByte |= (1 << 6);

            try
            {
                plcClient.Write($"DB{dbNumber}.DBB2", stateByte);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update PLC Feedback State Error: {ex.Message}");
            }
        }

        private async void SendFeedbackBitPulse(int bitAddress)
        {
            try
            {
                if (!int.TryParse(dbNumberTextBox.Text, out int dbNumber) || plcClient == null || !plcClient.IsConnected) return;

                byte currentStateByte = 0;
                if (isPickSlideActive) currentStateByte |= (1 << 5);
                if (isPlaceSlideActive) currentStateByte |= (1 << 6);

                byte pulseOnByte = (byte)(currentStateByte | (1 << bitAddress));

                await plcClient.WriteAsync($"DB{dbNumber}.DBB2", pulseOnByte);
                await Task.Delay(500);

                UpdatePlcFeedbackState();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"PLC Feedback Pulse Error: {ex.Message}");
            }
        }
        #endregion

        #region SOP and Slideshow Control
        public async void HandleStartSignal(int index)
        {
            if (currentState == SOPState.Idle)
            {
                await HandleStartSlideshow(index);
            }
            else if (currentState == SOPState.ProcessOver)
            {
                if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
                {
                    CleanupSlideshow();
                }
                else
                {
                    SendKeys.SendWait("{ESC}");
                    await Task.Delay(500);
                    currentState = SOPState.Idle;
                }
                await HandleStartSlideshow(index);
            }
        }

        public async Task HandleStartSlideshow(int index)
        {
            if (slideMappings.TryGetValue(index, out string path))
            {
                string configPath = path + ".json";
                if (!File.Exists(configPath))
                {
                    MessageBox.Show($"Configuration file not found for this SOP.", "Configuration Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string json = File.ReadAllText(configPath);
                currentSOP = JsonConvert.DeserializeObject<SopConfiguration>(json);

                if (currentSOP == null || currentSOP.Steps == null || currentSOP.Steps.Count == 0)
                {
                    MessageBox.Show("SOP configuration is empty.", "Empty SOP", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await OpenPresentation(path);

                currentSlideshowIndex = index;
                currentSlideshowLabel.Text = "Current Slideshow: " + Path.GetFileName(path);

                isPaused = false;
                currentState = SOPState.WaitingForStartSignal;
                currentStepNumberForPlc = 0;
                currentPtlNumberForPlc = 0;
                SendFeedbackBitPulse(0);
            }
            else
            {
                currentSlideshowLabel.Text = $"Current Slideshow: No mapping for index {index}";
            }
        }

        public void HandleNextSignal()
        {
            if (isPaused || currentState == SOPState.ProcessOver || currentState == SOPState.WaitingForStartReset || currentState == SOPState.PlaceInProgress)
            {
                return;
            }

            if (currentState == SOPState.WaitingForStartSignal)
            {
                if (officeSuiteComboBox.SelectedItem.ToString() != "PowerPoint") SendKeys.SendWait("{RIGHT}");
                currentStepIndex = 0;
                AdvanceToStep(currentStepIndex);
            }
            else if (currentState == SOPState.WaitingForPick)
            {
                if (officeSuiteComboBox.SelectedItem.ToString() != "PowerPoint") SendKeys.SendWait("{RIGHT}");
                AdvanceToPlaceSlide();
            }

            SendFeedbackBitPulse(1);
        }

        public void HandlePauseResume()
        {
            if (currentState == SOPState.Idle) return;
            isPaused = !isPaused;

            if (isPaused)
            {
                cycleTimer.Stop();
                PauseVideoOnCurrentSlide();
                this.Text = "PLC Slideshow Controller (PAUSED)";
            }
            else
            {
                if (currentState == SOPState.PlaceInProgress) cycleTimer.Start();
                ResumeVideoOnCurrentSlide();
                this.Text = "PLC Slideshow Controller";
            }
            SendFeedbackBitPulse(2);
        }

        public void HandleEndSlideshow()
        {
            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                slideshowPresentation?.SlideShowWindow?.View?.Exit();
            }
            else
            {
                SendKeys.SendWait("{ESC}");
            }
            CleanupSlideshow();
            SendFeedbackBitPulse(3);
        }

        private void AdvanceToStep(int stepIndex)
        {
            if (currentSOP == null || stepIndex >= currentSOP.Steps.Count)
            {
                if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint") GoToSlide(currentSOP.EndSlide);

                isPickSlideActive = false;
                isPlaceSlideActive = false;
                UpdatePlcFeedbackState();
                currentState = SOPState.WaitingForStartReset;
                currentStepNumberForPlc = 255;
                currentPtlNumberForPlc = 0;
                return;
            }

            var step = currentSOP.Steps[stepIndex];
            currentStepNumberForPlc = step.StepNumber;
            currentPtlNumberForPlc = step.PtlNumber;

            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                if (step.PickSlide == 0)
                {
                    GoToSlide(step.PlaceSlide);
                    AdvanceToPlaceSlide();
                }
                else
                {
                    GoToSlide(step.PickSlide);
                    isPickSlideActive = true;
                    isPlaceSlideActive = false;
                    UpdatePlcFeedbackState();
                    currentState = SOPState.WaitingForPick;
                }
            }
            else
            {
                if (step.PickSlide == 0)
                {
                    AdvanceToPlaceSlide();
                }
                else
                {
                    isPickSlideActive = true;
                    isPlaceSlideActive = false;
                    UpdatePlcFeedbackState();
                    currentState = SOPState.WaitingForPick;
                }
            }
        }

        private void AdvanceToPlaceSlide()
        {
            currentState = SOPState.PlaceInProgress;
            isPickSlideActive = false;
            isPlaceSlideActive = true;
            UpdatePlcFeedbackState();
            var step = currentSOP.Steps[currentStepIndex];

            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                GoToSlide(step.PlaceSlide);
                if (step.IsVideo) PlayVideoOnCurrentSlide();
            }
            else
            {
                if (step.IsVideo) PlayVideoOnCurrentSlide();
            }

            cycleTimer.Interval = step.CycleTimeSeconds * 1000;
            cycleTimer.Start();
        }

        private void cycleTimer_Tick(object sender, EventArgs e)
        {
            cycleTimer.Stop();
            if (currentState == SOPState.PlaceInProgress)
            {
                if (officeSuiteComboBox.SelectedItem.ToString() != "PowerPoint")
                {
                    SendKeys.SendWait("{RIGHT}");
                }
                currentStepIndex++;
                AdvanceToStep(currentStepIndex);
            }
        }

        private Task OpenPresentation(string path)
        {
            return Task.Run(async () =>
            {
                if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
                {
                    try
                    {
                        slideshowApp = new PowerPoint.Application();
                        slideshowPresentation = slideshowApp.Presentations.Open(path, WithWindow: Microsoft.Office.Core.MsoTriState.msoFalse);
                        slideshowPresentation.SlideShowSettings.Run();
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            MessageBox.Show($"Failed to open PowerPoint: {ex.Message}", "PowerPoint Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                        CleanupSlideshow();
                    }
                }
                else
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
                        await Task.Delay(5000);
                        SendKeys.SendWait("{F5}");
                    }
                    catch (Exception ex)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            MessageBox.Show($"Failed to open presentation: {ex.Message}", "Slideshow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
            });
        }

        private void GoToSlide(int slideNumber)
        {
            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                if (slideshowPresentation?.SlideShowWindow != null)
                {
                    try { slideshowPresentation.SlideShowWindow.View.GotoSlide(slideNumber); }
                    catch { }
                }
            }
        }

        private void PlayVideoOnCurrentSlide()
        {
            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                if (slideshowPresentation?.SlideShowWindow != null)
                {
                    try
                    {
                        slideshowPresentation.SlideShowWindow.View.Next();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"PowerPoint Next/Play Error: {ex.Message}");
                    }
                }
            }
            else
            {
                SendKeys.SendWait("{RIGHT}");
            }
        }

        private void PauseVideoOnCurrentSlide()
        {
            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                try { slideshowPresentation?.SlideShowWindow?.View?.Player(1)?.Pause(); }
                catch { }
            }
        }

        private void ResumeVideoOnCurrentSlide()
        {
            if (officeSuiteComboBox.SelectedItem.ToString() == "PowerPoint")
            {
                try { slideshowPresentation?.SlideShowWindow?.View?.Player(1)?.Play(); }
                catch { }
            }
        }

        private void CleanupSlideshow()
        {
            cycleTimer.Stop();
            currentState = SOPState.Idle;
            isPaused = false;
            isPickSlideActive = false;
            isPlaceSlideActive = false;
            UpdatePlcFeedbackState();
            this.Text = "PLC Slideshow Controller";
            currentStepNumberForPlc = 0;
            currentPtlNumberForPlc = 0;

            try
            {
                if (slideshowPresentation != null)
                {
                    slideshowPresentation.Close();
                    Marshal.ReleaseComObject(slideshowPresentation);
                    slideshowPresentation = null;
                }
                if (slideshowApp != null)
                {
                    slideshowApp.Quit();
                    Marshal.ReleaseComObject(slideshowApp);
                    slideshowApp = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch { }
        }
        #endregion

        #region UI Updates
        private void UpdateSlideMappingsUI()
        {
            mappingsListView.Items.Clear();
            foreach (var mapping in slideMappings.OrderBy(m => m.Key))
            {
                var item = new ListViewItem(mapping.Key.ToString());
                item.SubItems.Add(Path.GetFileName(mapping.Value));
                mappingsListView.Items.Add(item);
            }
        }

        public void ToggleSimulationMode(bool isEnabled)
        {
            plcControlsGroupBox.Enabled = !isEnabled;
            statusGroupBox.Enabled = !isEnabled;
            if (isEnabled && isConnected)
            {
                DisconnectPlc();
            }
        }

        private void LoadSopForSelectedSlideshow()
        {
            if (string.IsNullOrEmpty(currentlySelectedSopPath))
            {
                ClearSopEditor();
                return;
            }

            string configPath = currentlySelectedSopPath + ".json";
            SopConfiguration sopConfig;
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                sopConfig = JsonConvert.DeserializeObject<SopConfiguration>(json) ?? new SopConfiguration();
            }
            else
            {
                sopConfig = new SopConfiguration();
            }

            endSlideTextBox.Text = sopConfig.EndSlide.ToString();
            currentStepsBindingList = new BindingList<AssemblyStep>(sopConfig.Steps);
            sopStepsGridView.DataSource = currentStepsBindingList;
        }

        private void ClearSopEditor()
        {
            currentlySelectedSopPath = null;
            endSlideTextBox.Text = "";
            sopStepsGridView.DataSource = null;
        }
        #endregion
    }
}

