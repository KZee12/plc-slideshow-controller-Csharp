namespace PLCSlideshowController
{
    partial class SimulationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.simulationGroupBox = new System.Windows.Forms.GroupBox();
            this.simPauseButton = new System.Windows.Forms.Button();
            this.simEndButton = new System.Windows.Forms.Button();
            this.simNextButton = new System.Windows.Forms.Button();
            this.simStartButton = new System.Windows.Forms.Button();
            this.simIndexTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.simulationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // simulationGroupBox
            // 
            this.simulationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.simulationGroupBox.Controls.Add(this.simPauseButton);
            this.simulationGroupBox.Controls.Add(this.simEndButton);
            this.simulationGroupBox.Controls.Add(this.simNextButton);
            this.simulationGroupBox.Controls.Add(this.simStartButton);
            this.simulationGroupBox.Controls.Add(this.simIndexTextBox);
            this.simulationGroupBox.Controls.Add(this.label6);
            this.simulationGroupBox.Location = new System.Drawing.Point(12, 12);
            this.simulationGroupBox.Name = "simulationGroupBox";
            this.simulationGroupBox.Size = new System.Drawing.Size(518, 91);
            this.simulationGroupBox.TabIndex = 5;
            this.simulationGroupBox.TabStop = false;
            this.simulationGroupBox.Text = "Simulation Controls";
            // 
            // simPauseButton
            // 
            this.simPauseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simPauseButton.Location = new System.Drawing.Point(288, 53);
            this.simPauseButton.Name = "simPauseButton";
            this.simPauseButton.Size = new System.Drawing.Size(100, 23);
            this.simPauseButton.TabIndex = 6;
            this.simPauseButton.Text = "||";
            this.simPauseButton.UseVisualStyleBackColor = true;
            this.simPauseButton.Click += new System.EventHandler(this.simPauseButton_Click);
            // 
            // simEndButton
            // 
            this.simEndButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simEndButton.Location = new System.Drawing.Point(394, 53);
            this.simEndButton.Name = "simEndButton";
            this.simEndButton.Size = new System.Drawing.Size(100, 23);
            this.simEndButton.TabIndex = 5;
            this.simEndButton.Text = "■";
            this.simEndButton.UseVisualStyleBackColor = true;
            this.simEndButton.Click += new System.EventHandler(this.simEndButton_Click);
            // 
            // simNextButton
            // 
            this.simNextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simNextButton.Location = new System.Drawing.Point(182, 53);
            this.simNextButton.Name = "simNextButton";
            this.simNextButton.Size = new System.Drawing.Size(100, 23);
            this.simNextButton.TabIndex = 4;
            this.simNextButton.Text = "▶|";
            this.simNextButton.UseVisualStyleBackColor = true;
            this.simNextButton.Click += new System.EventHandler(this.simNextButton_Click);
            // 
            // simStartButton
            // 
            this.simStartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simStartButton.Location = new System.Drawing.Point(76, 53);
            this.simStartButton.Name = "simStartButton";
            this.simStartButton.Size = new System.Drawing.Size(100, 23);
            this.simStartButton.TabIndex = 3;
            this.simStartButton.Text = "▶";
            this.simStartButton.UseVisualStyleBackColor = true;
            this.simStartButton.Click += new System.EventHandler(this.simStartButton_Click);
            // 
            // simIndexTextBox
            // 
            this.simIndexTextBox.Location = new System.Drawing.Point(76, 24);
            this.simIndexTextBox.Name = "simIndexTextBox";
            this.simIndexTextBox.Size = new System.Drawing.Size(168, 20);
            this.simIndexTextBox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Index:";
            // 
            // SimulationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 115);
            this.Controls.Add(this.simulationGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SimulationForm";
            this.Text = "Simulation Mode";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulationForm_FormClosing);
            this.simulationGroupBox.ResumeLayout(false);
            this.simulationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox simulationGroupBox;
        private System.Windows.Forms.Button simPauseButton;
        private System.Windows.Forms.Button simEndButton;
        private System.Windows.Forms.Button simNextButton;
        private System.Windows.Forms.Button simStartButton;
        private System.Windows.Forms.TextBox simIndexTextBox;
        private System.Windows.Forms.Label label6;
    }
}
