namespace PLCSlideshowController
{
    partial class PlcMonitorForm
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
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.inputRawValueLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.endIndicator = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pauseIndicator = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nextIndicator = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startIndicator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.feedbackGroupBox = new System.Windows.Forms.GroupBox();
            this.feedbackRawValueLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endFeedbackIndicator = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pauseFeedbackIndicator = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nextFeedbackIndicator = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.startFeedbackIndicator = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.statusGroupBox = new System.Windows.Forms.GroupBox();
            this.ptlValueLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.stepValueLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.inputGroupBox.SuspendLayout();
            this.feedbackGroupBox.SuspendLayout();
            this.statusGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.inputRawValueLabel);
            this.inputGroupBox.Controls.Add(this.label10);
            this.inputGroupBox.Controls.Add(this.endIndicator);
            this.inputGroupBox.Controls.Add(this.label8);
            this.inputGroupBox.Controls.Add(this.pauseIndicator);
            this.inputGroupBox.Controls.Add(this.label6);
            this.inputGroupBox.Controls.Add(this.nextIndicator);
            this.inputGroupBox.Controls.Add(this.label4);
            this.inputGroupBox.Controls.Add(this.startIndicator);
            this.inputGroupBox.Controls.Add(this.label1);
            this.inputGroupBox.Location = new System.Drawing.Point(12, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(260, 150);
            this.inputGroupBox.TabIndex = 0;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input Signals (PLC -> PC)";
            // 
            // inputRawValueLabel
            // 
            this.inputRawValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputRawValueLabel.Location = new System.Drawing.Point(137, 25);
            this.inputRawValueLabel.Name = "inputRawValueLabel";
            this.inputRawValueLabel.Size = new System.Drawing.Size(117, 15);
            this.inputRawValueLabel.TabIndex = 9;
            this.inputRawValueLabel.Text = "0x00";
            this.inputRawValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "DBB0 Raw Val:";
            // 
            // endIndicator
            // 
            this.endIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.endIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endIndicator.Location = new System.Drawing.Point(140, 115);
            this.endIndicator.Name = "endIndicator";
            this.endIndicator.Size = new System.Drawing.Size(114, 20);
            this.endIndicator.TabIndex = 7;
            this.endIndicator.Text = "OFF";
            this.endIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Bit 3 (DBX0.3) - End";
            // 
            // pauseIndicator
            // 
            this.pauseIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.pauseIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pauseIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseIndicator.Location = new System.Drawing.Point(140, 90);
            this.pauseIndicator.Name = "pauseIndicator";
            this.pauseIndicator.Size = new System.Drawing.Size(114, 20);
            this.pauseIndicator.TabIndex = 5;
            this.pauseIndicator.Text = "OFF";
            this.pauseIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Bit 2 (DBX0.2) - Pause";
            // 
            // nextIndicator
            // 
            this.nextIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.nextIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextIndicator.Location = new System.Drawing.Point(140, 65);
            this.nextIndicator.Name = "nextIndicator";
            this.nextIndicator.Size = new System.Drawing.Size(114, 20);
            this.nextIndicator.TabIndex = 3;
            this.nextIndicator.Text = "OFF";
            this.nextIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bit 1 (DBX0.1) - Next";
            // 
            // startIndicator
            // 
            this.startIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.startIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startIndicator.Location = new System.Drawing.Point(140, 40);
            this.startIndicator.Name = "startIndicator";
            this.startIndicator.Size = new System.Drawing.Size(114, 20);
            this.startIndicator.TabIndex = 1;
            this.startIndicator.Text = "OFF";
            this.startIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bit 0 (DBX0.0) - Start";
            // 
            // feedbackGroupBox
            // 
            this.feedbackGroupBox.Controls.Add(this.feedbackRawValueLabel);
            this.feedbackGroupBox.Controls.Add(this.label3);
            this.feedbackGroupBox.Controls.Add(this.endFeedbackIndicator);
            this.feedbackGroupBox.Controls.Add(this.label7);
            this.feedbackGroupBox.Controls.Add(this.pauseFeedbackIndicator);
            this.feedbackGroupBox.Controls.Add(this.label11);
            this.feedbackGroupBox.Controls.Add(this.nextFeedbackIndicator);
            this.feedbackGroupBox.Controls.Add(this.label13);
            this.feedbackGroupBox.Controls.Add(this.startFeedbackIndicator);
            this.feedbackGroupBox.Controls.Add(this.label15);
            this.feedbackGroupBox.Location = new System.Drawing.Point(12, 168);
            this.feedbackGroupBox.Name = "feedbackGroupBox";
            this.feedbackGroupBox.Size = new System.Drawing.Size(260, 150);
            this.feedbackGroupBox.TabIndex = 1;
            this.feedbackGroupBox.TabStop = false;
            this.feedbackGroupBox.Text = "Feedback Signals (PC -> PLC)";
            // 
            // feedbackRawValueLabel
            // 
            this.feedbackRawValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackRawValueLabel.Location = new System.Drawing.Point(137, 25);
            this.feedbackRawValueLabel.Name = "feedbackRawValueLabel";
            this.feedbackRawValueLabel.Size = new System.Drawing.Size(117, 15);
            this.feedbackRawValueLabel.TabIndex = 9;
            this.feedbackRawValueLabel.Text = "0x00";
            this.feedbackRawValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DBB2 Raw Val:";
            // 
            // endFeedbackIndicator
            // 
            this.endFeedbackIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.endFeedbackIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endFeedbackIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endFeedbackIndicator.Location = new System.Drawing.Point(140, 115);
            this.endFeedbackIndicator.Name = "endFeedbackIndicator";
            this.endFeedbackIndicator.Size = new System.Drawing.Size(114, 20);
            this.endFeedbackIndicator.TabIndex = 7;
            this.endFeedbackIndicator.Text = "OFF";
            this.endFeedbackIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Bit 3 (DBX2.3) - End";
            // 
            // pauseFeedbackIndicator
            // 
            this.pauseFeedbackIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.pauseFeedbackIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pauseFeedbackIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseFeedbackIndicator.Location = new System.Drawing.Point(140, 90);
            this.pauseFeedbackIndicator.Name = "pauseFeedbackIndicator";
            this.pauseFeedbackIndicator.Size = new System.Drawing.Size(114, 20);
            this.pauseFeedbackIndicator.TabIndex = 5;
            this.pauseFeedbackIndicator.Text = "OFF";
            this.pauseFeedbackIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Bit 2 (DBX2.2) - Pause";
            // 
            // nextFeedbackIndicator
            // 
            this.nextFeedbackIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.nextFeedbackIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextFeedbackIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextFeedbackIndicator.Location = new System.Drawing.Point(140, 65);
            this.nextFeedbackIndicator.Name = "nextFeedbackIndicator";
            this.nextFeedbackIndicator.Size = new System.Drawing.Size(114, 20);
            this.nextFeedbackIndicator.TabIndex = 3;
            this.nextFeedbackIndicator.Text = "OFF";
            this.nextFeedbackIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Bit 1 (DBX2.1) - Next";
            // 
            // startFeedbackIndicator
            // 
            this.startFeedbackIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.startFeedbackIndicator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startFeedbackIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startFeedbackIndicator.Location = new System.Drawing.Point(140, 40);
            this.startFeedbackIndicator.Name = "startFeedbackIndicator";
            this.startFeedbackIndicator.Size = new System.Drawing.Size(114, 20);
            this.startFeedbackIndicator.TabIndex = 1;
            this.startFeedbackIndicator.Text = "OFF";
            this.startFeedbackIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Bit 0 (DBX2.0) - Start";
            // 
            // statusGroupBox
            // 
            this.statusGroupBox.Controls.Add(this.ptlValueLabel);
            this.statusGroupBox.Controls.Add(this.label14);
            this.statusGroupBox.Controls.Add(this.stepValueLabel);
            this.statusGroupBox.Controls.Add(this.label12);
            this.statusGroupBox.Location = new System.Drawing.Point(12, 324);
            this.statusGroupBox.Name = "statusGroupBox";
            this.statusGroupBox.Size = new System.Drawing.Size(260, 80);
            this.statusGroupBox.TabIndex = 2;
            this.statusGroupBox.TabStop = false;
            this.statusGroupBox.Text = "Status Output (PC -> PLC)";
            // 
            // ptlValueLabel
            // 
            this.ptlValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ptlValueLabel.Location = new System.Drawing.Point(140, 49);
            this.ptlValueLabel.Name = "ptlValueLabel";
            this.ptlValueLabel.Size = new System.Drawing.Size(114, 15);
            this.ptlValueLabel.TabIndex = 11;
            this.ptlValueLabel.Text = "0";
            this.ptlValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Current PTL # (DBB4):";
            // 
            // stepValueLabel
            // 
            this.stepValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepValueLabel.Location = new System.Drawing.Point(140, 25);
            this.stepValueLabel.Name = "stepValueLabel";
            this.stepValueLabel.Size = new System.Drawing.Size(114, 15);
            this.stepValueLabel.TabIndex = 9;
            this.stepValueLabel.Text = "0";
            this.stepValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Current Step # (DBB3):";
            // 
            // PlcMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 416);
            this.Controls.Add(this.statusGroupBox);
            this.Controls.Add(this.feedbackGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PlcMonitorForm";
            this.Text = "PLC Monitor";
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.feedbackGroupBox.ResumeLayout(false);
            this.feedbackGroupBox.PerformLayout();
            this.statusGroupBox.ResumeLayout(false);
            this.statusGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label startIndicator;
        private System.Windows.Forms.Label endIndicator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label pauseIndicator;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label nextIndicator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label inputRawValueLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox feedbackGroupBox;
        private System.Windows.Forms.Label feedbackRawValueLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label endFeedbackIndicator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label pauseFeedbackIndicator;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label nextFeedbackIndicator;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label startFeedbackIndicator;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label ptlValueLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label stepValueLabel;
        private System.Windows.Forms.Label label12;
    }
}
