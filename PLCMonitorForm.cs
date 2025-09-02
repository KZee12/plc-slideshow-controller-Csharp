using System.Drawing;
using System.Windows.Forms;

namespace PLCSlideshowController
{
    public partial class PlcMonitorForm : Form
    {
        public PlcMonitorForm()
        {
            InitializeComponent();
        }

        public void UpdateMonitor(byte controlByte, byte feedbackByte, byte stepNumber, byte ptlNumber)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(() => UpdateMonitor(controlByte, feedbackByte, stepNumber, ptlNumber)));
                return;
            }

            // --- Update Input Signals ---
            inputRawValueLabel.Text = $"0x{controlByte:X2}";
            UpdateIndicator(startIndicator, (controlByte & 1) == 1);
            UpdateIndicator(nextIndicator, (controlByte & 2) == 2);
            UpdateIndicator(pauseIndicator, (controlByte & 4) == 4);
            UpdateIndicator(endIndicator, (controlByte & 8) == 8);

            // --- Update Feedback Signals ---
            feedbackRawValueLabel.Text = $"0x{feedbackByte:X2}";
            UpdateIndicator(startFeedbackIndicator, (feedbackByte & 1) == 1);
            UpdateIndicator(nextFeedbackIndicator, (feedbackByte & 2) == 2);
            UpdateIndicator(pauseFeedbackIndicator, (feedbackByte & 4) == 4);
            UpdateIndicator(endFeedbackIndicator, (feedbackByte & 8) == 8);

            // --- Update Status Outputs ---
            stepValueLabel.Text = stepNumber.ToString();
            ptlValueLabel.Text = ptlNumber.ToString();
        }

        private void UpdateIndicator(Label indicator, bool isActive)
        {
            indicator.Text = isActive ? "ON" : "OFF";
            indicator.BackColor = isActive ? Color.LimeGreen : SystemColors.Control;
        }
    }
}
