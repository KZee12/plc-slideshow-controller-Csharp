using System;
using System.Windows.Forms;

namespace PLCSlideshowController
{
    public partial class SimulationForm : Form
    {
        private MainForm mainApp;

        public SimulationForm(MainForm mainForm)
        {
            InitializeComponent();
            mainApp = mainForm;
        }

        private void simStartButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(simIndexTextBox.Text, out int index))
            {
                mainApp.HandleStartSlideshow(index);
            }
            else
            {
                MessageBox.Show("Please enter a valid number for the index.", "Invalid Index", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void simNextButton_Click(object sender, EventArgs e)
        {
            mainApp.HandleNextSignal();
        }

        private void simPauseButton_Click(object sender, EventArgs e)
        {
            mainApp.HandlePauseResume();
        }

        private void simEndButton_Click(object sender, EventArgs e)
        {
            mainApp.HandleEndSlideshow();
        }

        private void SimulationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Notify the main form that simulation mode is ending
            mainApp.ToggleSimulationMode(false);
        }
    }
}
