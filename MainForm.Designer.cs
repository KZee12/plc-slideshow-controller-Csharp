namespace PLCSlideshowController
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            plcControlsGroupBox = new GroupBox();
            monitorWindowButton = new Button();
            simulationButton = new Button();
            connectButton = new Button();
            dbNumberTextBox = new TextBox();
            label2 = new Label();
            ipAddressTextBox = new TextBox();
            label1 = new Label();
            statusGroupBox = new GroupBox();
            kuroLogoPictureBox = new PictureBox();
            officeSuiteComboBox = new ComboBox();
            currentSlideshowLabel = new Label();
            plcIndexLabel = new Label();
            label5 = new Label();
            connectionStatusLabel = new Label();
            label3 = new Label();
            splitContainer = new SplitContainer();
            mappingsListView = new ListView();
            columnIndex = new ColumnHeader();
            columnFile = new ColumnHeader();
            label4 = new Label();
            mappingIndexTextBox = new TextBox();
            addMappingButton = new Button();
            removeMappingButton = new Button();
            saveSopButton = new Button();
            removeStepButton = new Button();
            addStepButton = new Button();
            sopStepsGridView = new DataGridView();
            endSlideTextBox = new TextBox();
            labelEndSlide = new Label();
            cycleTimer = new System.Windows.Forms.Timer(components);
            plcControlsGroupBox.SuspendLayout();
            statusGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)kuroLogoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sopStepsGridView).BeginInit();
            SuspendLayout();
            // 
            // plcControlsGroupBox
            // 
            plcControlsGroupBox.Controls.Add(monitorWindowButton);
            plcControlsGroupBox.Controls.Add(simulationButton);
            plcControlsGroupBox.Controls.Add(connectButton);
            plcControlsGroupBox.Controls.Add(dbNumberTextBox);
            plcControlsGroupBox.Controls.Add(label2);
            plcControlsGroupBox.Controls.Add(ipAddressTextBox);
            plcControlsGroupBox.Controls.Add(label1);
            plcControlsGroupBox.Location = new Point(16, 18);
            plcControlsGroupBox.Margin = new Padding(4, 5, 4, 5);
            plcControlsGroupBox.Name = "plcControlsGroupBox";
            plcControlsGroupBox.Padding = new Padding(4, 5, 4, 5);
            plcControlsGroupBox.Size = new Size(371, 218);
            plcControlsGroupBox.TabIndex = 0;
            plcControlsGroupBox.TabStop = false;
            plcControlsGroupBox.Text = "PLC Controls";
            // 
            // monitorWindowButton
            // 
            monitorWindowButton.Location = new Point(185, 163);
            monitorWindowButton.Margin = new Padding(4, 5, 4, 5);
            monitorWindowButton.Name = "monitorWindowButton";
            monitorWindowButton.Size = new Size(165, 35);
            monitorWindowButton.TabIndex = 6;
            monitorWindowButton.Text = "Open Monitor";
            monitorWindowButton.UseVisualStyleBackColor = true;
            monitorWindowButton.Click += monitorWindowButton_Click;
            // 
            // simulationButton
            // 
            simulationButton.Location = new Point(185, 118);
            simulationButton.Margin = new Padding(4, 5, 4, 5);
            simulationButton.Name = "simulationButton";
            simulationButton.Size = new Size(165, 35);
            simulationButton.TabIndex = 4;
            simulationButton.Text = "Simulation Mode";
            simulationButton.UseVisualStyleBackColor = true;
            simulationButton.Click += simulationButton_Click;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(12, 118);
            connectButton.Margin = new Padding(4, 5, 4, 5);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(165, 80);
            connectButton.TabIndex = 4;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // dbNumberTextBox
            // 
            dbNumberTextBox.Location = new Point(101, 77);
            dbNumberTextBox.Margin = new Padding(4, 5, 4, 5);
            dbNumberTextBox.Name = "dbNumberTextBox";
            dbNumberTextBox.Size = new Size(248, 27);
            dbNumberTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 82);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 2;
            label2.Text = "DB Number:";
            // 
            // ipAddressTextBox
            // 
            ipAddressTextBox.Location = new Point(101, 32);
            ipAddressTextBox.Margin = new Padding(4, 5, 4, 5);
            ipAddressTextBox.Name = "ipAddressTextBox";
            ipAddressTextBox.Size = new Size(248, 27);
            ipAddressTextBox.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 37);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 0;
            label1.Text = "PLC IP:";
            // 
            // statusGroupBox
            // 
            statusGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusGroupBox.Controls.Add(kuroLogoPictureBox);
            statusGroupBox.Controls.Add(officeSuiteComboBox);
            statusGroupBox.Controls.Add(currentSlideshowLabel);
            statusGroupBox.Controls.Add(plcIndexLabel);
            statusGroupBox.Controls.Add(label5);
            statusGroupBox.Controls.Add(connectionStatusLabel);
            statusGroupBox.Controls.Add(label3);
            statusGroupBox.Location = new Point(395, 18);
            statusGroupBox.Margin = new Padding(4, 5, 4, 5);
            statusGroupBox.Name = "statusGroupBox";
            statusGroupBox.Padding = new Padding(4, 5, 4, 5);
            statusGroupBox.Size = new Size(768, 218);
            statusGroupBox.TabIndex = 1;
            statusGroupBox.TabStop = false;
            statusGroupBox.Text = "Status";
            // 
            // kuroLogoPictureBox
            // 
            kuroLogoPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            kuroLogoPictureBox.Image = plc_slideshow_controller.Properties.Resources.KURO_logo_transparent;
            kuroLogoPictureBox.Location = new Point(540, 29);
            kuroLogoPictureBox.Margin = new Padding(4, 5, 4, 5);
            kuroLogoPictureBox.Name = "kuroLogoPictureBox";
            kuroLogoPictureBox.Size = new Size(220, 86);
            kuroLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            kuroLogoPictureBox.TabIndex = 6;
            kuroLogoPictureBox.TabStop = false;
            // 
            // officeSuiteComboBox
            // 
            officeSuiteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            officeSuiteComboBox.FormattingEnabled = true;
            officeSuiteComboBox.Items.AddRange(new object[] { "PowerPoint", "Default App" });
            officeSuiteComboBox.Location = new Point(12, 122);
            officeSuiteComboBox.Margin = new Padding(4, 5, 4, 5);
            officeSuiteComboBox.Name = "officeSuiteComboBox";
            officeSuiteComboBox.Size = new Size(267, 28);
            officeSuiteComboBox.TabIndex = 5;
            // 
            // currentSlideshowLabel
            // 
            currentSlideshowLabel.AutoSize = true;
            currentSlideshowLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            currentSlideshowLabel.Location = new Point(8, 178);
            currentSlideshowLabel.Margin = new Padding(4, 0, 4, 0);
            currentSlideshowLabel.Name = "currentSlideshowLabel";
            currentSlideshowLabel.Size = new Size(187, 17);
            currentSlideshowLabel.TabIndex = 4;
            currentSlideshowLabel.Text = "Current Slideshow: None";
            // 
            // plcIndexLabel
            // 
            plcIndexLabel.AutoSize = true;
            plcIndexLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            plcIndexLabel.Location = new Point(109, 82);
            plcIndexLabel.Margin = new Padding(4, 0, 4, 0);
            plcIndexLabel.Name = "plcIndexLabel";
            plcIndexLabel.Size = new Size(17, 17);
            plcIndexLabel.TabIndex = 3;
            plcIndexLabel.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 82);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 2;
            label5.Text = "PLC Index:";
            // 
            // connectionStatusLabel
            // 
            connectionStatusLabel.AutoSize = true;
            connectionStatusLabel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectionStatusLabel.ForeColor = Color.Red;
            connectionStatusLabel.Location = new Point(109, 37);
            connectionStatusLabel.Margin = new Padding(4, 0, 4, 0);
            connectionStatusLabel.Name = "connectionStatusLabel";
            connectionStatusLabel.Size = new Size(106, 17);
            connectionStatusLabel.TabIndex = 1;
            connectionStatusLabel.Text = "Disconnected";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 37);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 20);
            label3.TabIndex = 0;
            label3.Text = "Connection:";
            // 
            // splitContainer
            // 
            splitContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer.Location = new Point(16, 246);
            splitContainer.Margin = new Padding(4, 5, 4, 5);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(mappingsListView);
            splitContainer.Panel1.Controls.Add(label4);
            splitContainer.Panel1.Controls.Add(mappingIndexTextBox);
            splitContainer.Panel1.Controls.Add(addMappingButton);
            splitContainer.Panel1.Controls.Add(removeMappingButton);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(saveSopButton);
            splitContainer.Panel2.Controls.Add(removeStepButton);
            splitContainer.Panel2.Controls.Add(addStepButton);
            splitContainer.Panel2.Controls.Add(sopStepsGridView);
            splitContainer.Panel2.Controls.Add(endSlideTextBox);
            splitContainer.Panel2.Controls.Add(labelEndSlide);
            splitContainer.Size = new Size(1147, 626);
            splitContainer.SplitterDistance = 230;
            splitContainer.SplitterWidth = 6;
            splitContainer.TabIndex = 2;
            // 
            // mappingsListView
            // 
            mappingsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mappingsListView.Columns.AddRange(new ColumnHeader[] { columnIndex, columnFile });
            mappingsListView.FullRowSelect = true;
            mappingsListView.Location = new Point(4, 49);
            mappingsListView.Margin = new Padding(4, 5, 4, 5);
            mappingsListView.MultiSelect = false;
            mappingsListView.Name = "mappingsListView";
            mappingsListView.Size = new Size(1137, 174);
            mappingsListView.TabIndex = 4;
            mappingsListView.UseCompatibleStateImageBehavior = false;
            mappingsListView.View = View.Details;
            mappingsListView.SelectedIndexChanged += mappingsListView_SelectedIndexChanged;
            // 
            // columnIndex
            // 
            columnIndex.Text = "Index";
            columnIndex.Width = 80;
            // 
            // columnFile
            // 
            columnFile.Text = "File";
            columnFile.Width = 450;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 14);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 0;
            label4.Text = "SOP Index:";
            // 
            // mappingIndexTextBox
            // 
            mappingIndexTextBox.Location = new Point(99, 9);
            mappingIndexTextBox.Margin = new Padding(4, 5, 4, 5);
            mappingIndexTextBox.Name = "mappingIndexTextBox";
            mappingIndexTextBox.Size = new Size(81, 27);
            mappingIndexTextBox.TabIndex = 1;
            // 
            // addMappingButton
            // 
            addMappingButton.Location = new Point(189, 6);
            addMappingButton.Margin = new Padding(4, 5, 4, 5);
            addMappingButton.Name = "addMappingButton";
            addMappingButton.Size = new Size(161, 35);
            addMappingButton.TabIndex = 2;
            addMappingButton.Text = "Add Slideshow File";
            addMappingButton.UseVisualStyleBackColor = true;
            addMappingButton.Click += addMappingButton_Click;
            // 
            // removeMappingButton
            // 
            removeMappingButton.Location = new Point(359, 6);
            removeMappingButton.Margin = new Padding(4, 5, 4, 5);
            removeMappingButton.Name = "removeMappingButton";
            removeMappingButton.Size = new Size(147, 35);
            removeMappingButton.TabIndex = 3;
            removeMappingButton.Text = "Remove Selected";
            removeMappingButton.UseVisualStyleBackColor = true;
            removeMappingButton.Click += removeMappingButton_Click;
            // 
            // saveSopButton
            // 
            saveSopButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            saveSopButton.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveSopButton.Location = new Point(1004, 5);
            saveSopButton.Margin = new Padding(4, 5, 4, 5);
            saveSopButton.Name = "saveSopButton";
            saveSopButton.Size = new Size(139, 35);
            saveSopButton.TabIndex = 5;
            saveSopButton.Text = "Save SOP";
            saveSopButton.UseVisualStyleBackColor = true;
            saveSopButton.Click += saveSopButton_Click;
            // 
            // removeStepButton
            // 
            removeStepButton.Location = new Point(123, 5);
            removeStepButton.Margin = new Padding(4, 5, 4, 5);
            removeStepButton.Name = "removeStepButton";
            removeStepButton.Size = new Size(111, 35);
            removeStepButton.TabIndex = 4;
            removeStepButton.Text = "Remove Step";
            removeStepButton.UseVisualStyleBackColor = true;
            removeStepButton.Click += removeStepButton_Click;
            // 
            // addStepButton
            // 
            addStepButton.Location = new Point(4, 5);
            addStepButton.Margin = new Padding(4, 5, 4, 5);
            addStepButton.Name = "addStepButton";
            addStepButton.Size = new Size(111, 35);
            addStepButton.TabIndex = 3;
            addStepButton.Text = "Add Step";
            addStepButton.UseVisualStyleBackColor = true;
            addStepButton.Click += addStepButton_Click;
            // 
            // sopStepsGridView
            // 
            sopStepsGridView.AllowUserToAddRows = false;
            sopStepsGridView.AllowUserToDeleteRows = false;
            sopStepsGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sopStepsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            sopStepsGridView.Location = new Point(4, 49);
            sopStepsGridView.Margin = new Padding(4, 5, 4, 5);
            sopStepsGridView.Name = "sopStepsGridView";
            sopStepsGridView.RowHeadersWidth = 51;
            sopStepsGridView.Size = new Size(1139, 336);
            sopStepsGridView.TabIndex = 2;
            // 
            // endSlideTextBox
            // 
            endSlideTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            endSlideTextBox.Location = new Point(929, 8);
            endSlideTextBox.Margin = new Padding(4, 5, 4, 5);
            endSlideTextBox.Name = "endSlideTextBox";
            endSlideTextBox.Size = new Size(65, 27);
            endSlideTextBox.TabIndex = 1;
            // 
            // labelEndSlide
            // 
            labelEndSlide.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelEndSlide.AutoSize = true;
            labelEndSlide.Location = new Point(791, 12);
            labelEndSlide.Margin = new Padding(4, 0, 4, 0);
            labelEndSlide.Name = "labelEndSlide";
            labelEndSlide.Size = new Size(132, 20);
            labelEndSlide.TabIndex = 0;
            labelEndSlide.Text = "End Slide Number:";
            // 
            // cycleTimer
            // 
            cycleTimer.Tick += cycleTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 891);
            Controls.Add(splitContainer);
            Controls.Add(statusGroupBox);
            Controls.Add(plcControlsGroupBox);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1194, 898);
            Name = "MainForm";
            Text = "PLC Slideshow Controller";
            FormClosing += MainForm_FormClosing;
            plcControlsGroupBox.ResumeLayout(false);
            plcControlsGroupBox.PerformLayout();
            statusGroupBox.ResumeLayout(false);
            statusGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)kuroLogoPictureBox).EndInit();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel1.PerformLayout();
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)sopStepsGridView).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox plcControlsGroupBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox dbNumberTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ipAddressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox statusGroupBox;
        private System.Windows.Forms.Label plcIndexLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListView mappingsListView;
        private System.Windows.Forms.ColumnHeader columnIndex;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.Button removeMappingButton;
        private System.Windows.Forms.Button addMappingButton;
        private System.Windows.Forms.TextBox mappingIndexTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label currentSlideshowLabel;
        private System.Windows.Forms.Timer cycleTimer;
        private System.Windows.Forms.Button simulationButton;
        private System.Windows.Forms.ComboBox officeSuiteComboBox;
        private System.Windows.Forms.DataGridView sopStepsGridView;
        private System.Windows.Forms.TextBox endSlideTextBox;
        private System.Windows.Forms.Label labelEndSlide;
        private System.Windows.Forms.Button saveSopButton;
        private System.Windows.Forms.Button removeStepButton;
        private System.Windows.Forms.Button addStepButton;
        private System.Windows.Forms.Button monitorWindowButton;
        private System.Windows.Forms.PictureBox kuroLogoPictureBox;
    }
}

