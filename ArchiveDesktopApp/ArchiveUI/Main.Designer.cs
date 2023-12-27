namespace ArchiveUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ArchivesListView = new System.Windows.Forms.ListView();
            this.ArchiveName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Enabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TabControls = new System.Windows.Forms.TabControl();
            this.Archives = new System.Windows.Forms.TabPage();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.Details = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.det_ActionCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RunArchiveButton = new System.Windows.Forms.Button();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.BackupFolderSelect = new System.Windows.Forms.Button();
            this.SourceFolderSelect = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.det_ArchiveName = new System.Windows.Forms.TextBox();
            this.det_Enabled = new System.Windows.Forms.ComboBox();
            this.det_Schedule = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.det_Backup = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.det_Source = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.det_Description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Logs = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.LogsListView = new System.Windows.Forms.ListView();
            this.LogDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.TabControls.SuspendLayout();
            this.Archives.SuspendLayout();
            this.Details.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchivesListView
            // 
            this.ArchivesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArchivesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ArchiveName,
            this.LastRun,
            this.Enabled});
            this.ArchivesListView.FullRowSelect = true;
            this.ArchivesListView.GridLines = true;
            this.ArchivesListView.HideSelection = false;
            this.ArchivesListView.Location = new System.Drawing.Point(6, 34);
            this.ArchivesListView.MultiSelect = false;
            this.ArchivesListView.Name = "ArchivesListView";
            this.ArchivesListView.Size = new System.Drawing.Size(587, 318);
            this.ArchivesListView.TabIndex = 4;
            this.ArchivesListView.UseCompatibleStateImageBehavior = false;
            this.ArchivesListView.View = System.Windows.Forms.View.Details;
            this.ArchivesListView.SelectedIndexChanged += new System.EventHandler(this.ArchiveList_SelectedIndexChanged);
            // 
            // ArchiveName
            // 
            this.ArchiveName.Text = "Archive Name";
            this.ArchiveName.Width = 385;
            // 
            // LastRun
            // 
            this.LastRun.Text = "Last Run";
            this.LastRun.Width = 150;
            // 
            // Enabled
            // 
            this.Enabled.Text = "Enabled";
            this.Enabled.Width = 55;
            // 
            // TabControls
            // 
            this.TabControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControls.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabControls.Controls.Add(this.Archives);
            this.TabControls.Controls.Add(this.Details);
            this.TabControls.Controls.Add(this.Logs);
            this.TabControls.Location = new System.Drawing.Point(0, 0);
            this.TabControls.Name = "TabControls";
            this.TabControls.SelectedIndex = 0;
            this.TabControls.Size = new System.Drawing.Size(611, 388);
            this.TabControls.TabIndex = 5;
            this.TabControls.SelectedIndexChanged += new System.EventHandler(this.TabControls_SelectedIndexChanged);
            // 
            // Archives
            // 
            this.Archives.Controls.Add(this.DeleteButton);
            this.Archives.Controls.Add(this.EditButton);
            this.Archives.Controls.Add(this.NewButton);
            this.Archives.Controls.Add(this.RunButton);
            this.Archives.Controls.Add(this.ArchivesListView);
            this.Archives.Location = new System.Drawing.Point(4, 25);
            this.Archives.Name = "Archives";
            this.Archives.Padding = new System.Windows.Forms.Padding(3);
            this.Archives.Size = new System.Drawing.Size(603, 359);
            this.Archives.TabIndex = 0;
            this.Archives.Text = "Archives";
            this.Archives.UseVisualStyleBackColor = true;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Location = new System.Drawing.Point(454, 6);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(139, 23);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Delete Archive";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(306, 6);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(139, 23);
            this.EditButton.TabIndex = 7;
            this.EditButton.Text = "Edit Archive";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(157, 6);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(139, 23);
            this.NewButton.TabIndex = 6;
            this.NewButton.Text = "New Archive";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(6, 6);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(139, 23);
            this.RunButton.TabIndex = 5;
            this.RunButton.Text = "Run All Enabled Archives";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // Details
            // 
            this.Details.Controls.Add(this.panel1);
            this.Details.Location = new System.Drawing.Point(4, 25);
            this.Details.Name = "Details";
            this.Details.Padding = new System.Windows.Forms.Padding(3);
            this.Details.Size = new System.Drawing.Size(603, 359);
            this.Details.TabIndex = 1;
            this.Details.Text = "Details";
            this.Details.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.det_ActionCount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.RunArchiveButton);
            this.panel1.Controls.Add(this.CalculateButton);
            this.panel1.Controls.Add(this.BackupFolderSelect);
            this.panel1.Controls.Add(this.SourceFolderSelect);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.det_ArchiveName);
            this.panel1.Controls.Add(this.det_Enabled);
            this.panel1.Controls.Add(this.det_Schedule);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.det_Backup);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.det_Source);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.det_Description);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 344);
            this.panel1.TabIndex = 0;
            // 
            // det_ActionCount
            // 
            this.det_ActionCount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.det_ActionCount.Location = new System.Drawing.Point(107, 205);
            this.det_ActionCount.MaximumSize = new System.Drawing.Size(475, 23);
            this.det_ActionCount.MinimumSize = new System.Drawing.Size(475, 20);
            this.det_ActionCount.Name = "det_ActionCount";
            this.det_ActionCount.ReadOnly = true;
            this.det_ActionCount.Size = new System.Drawing.Size(475, 20);
            this.det_ActionCount.TabIndex = 20;
            this.det_ActionCount.TabStop = false;
            this.det_ActionCount.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 19;
            this.label8.Text = "Action Count";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RunArchiveButton
            // 
            this.RunArchiveButton.Location = new System.Drawing.Point(350, 6);
            this.RunArchiveButton.Name = "RunArchiveButton";
            this.RunArchiveButton.Size = new System.Drawing.Size(75, 23);
            this.RunArchiveButton.TabIndex = 18;
            this.RunArchiveButton.Text = "Run Archive";
            this.RunArchiveButton.UseVisualStyleBackColor = true;
            this.RunArchiveButton.Click += new System.EventHandler(this.RunArchiveButton_Click);
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(269, 6);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(75, 23);
            this.CalculateButton.TabIndex = 17;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // BackupFolderSelect
            // 
            this.BackupFolderSelect.Location = new System.Drawing.Point(558, 145);
            this.BackupFolderSelect.Name = "BackupFolderSelect";
            this.BackupFolderSelect.Size = new System.Drawing.Size(24, 23);
            this.BackupFolderSelect.TabIndex = 16;
            this.BackupFolderSelect.Text = "...";
            this.BackupFolderSelect.UseVisualStyleBackColor = true;
            this.BackupFolderSelect.Click += new System.EventHandler(this.SelectBackup_Click);
            // 
            // SourceFolderSelect
            // 
            this.SourceFolderSelect.Location = new System.Drawing.Point(558, 116);
            this.SourceFolderSelect.Name = "SourceFolderSelect";
            this.SourceFolderSelect.Size = new System.Drawing.Size(24, 23);
            this.SourceFolderSelect.TabIndex = 15;
            this.SourceFolderSelect.Text = "...";
            this.SourceFolderSelect.UseVisualStyleBackColor = true;
            this.SourceFolderSelect.Click += new System.EventHandler(this.SelectSource_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(188, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(107, 6);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // det_ArchiveName
            // 
            this.det_ArchiveName.Location = new System.Drawing.Point(107, 34);
            this.det_ArchiveName.MaximumSize = new System.Drawing.Size(475, 23);
            this.det_ArchiveName.MinimumSize = new System.Drawing.Size(475, 23);
            this.det_ArchiveName.Name = "det_ArchiveName";
            this.det_ArchiveName.Size = new System.Drawing.Size(475, 20);
            this.det_ArchiveName.TabIndex = 1;
            // 
            // det_Enabled
            // 
            this.det_Enabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.det_Enabled.FormattingEnabled = true;
            this.det_Enabled.Items.AddRange(new object[] {
            "True",
            "False"});
            this.det_Enabled.Location = new System.Drawing.Point(107, 176);
            this.det_Enabled.Name = "det_Enabled";
            this.det_Enabled.Size = new System.Drawing.Size(121, 21);
            this.det_Enabled.TabIndex = 5;
            // 
            // det_Schedule
            // 
            this.det_Schedule.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.det_Schedule.Enabled = false;
            this.det_Schedule.ForeColor = System.Drawing.Color.DarkGray;
            this.det_Schedule.Location = new System.Drawing.Point(107, 233);
            this.det_Schedule.MaximumSize = new System.Drawing.Size(475, 20);
            this.det_Schedule.MinimumSize = new System.Drawing.Size(475, 20);
            this.det_Schedule.Name = "det_Schedule";
            this.det_Schedule.ReadOnly = true;
            this.det_Schedule.Size = new System.Drawing.Size(475, 20);
            this.det_Schedule.TabIndex = 11;
            this.det_Schedule.TabStop = false;
            this.det_Schedule.Text = "Not Implemented";
            // 
            // label7
            // 
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(3, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "Schedule";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 8;
            this.label6.Text = "Enabled";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // det_Backup
            // 
            this.det_Backup.Location = new System.Drawing.Point(107, 146);
            this.det_Backup.MaximumSize = new System.Drawing.Size(445, 23);
            this.det_Backup.MinimumSize = new System.Drawing.Size(445, 23);
            this.det_Backup.Name = "det_Backup";
            this.det_Backup.Size = new System.Drawing.Size(445, 20);
            this.det_Backup.TabIndex = 4;
            this.det_Backup.Leave += new System.EventHandler(this.SelectBackup_FocusLeave);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Backup Folder";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // det_Source
            // 
            this.det_Source.Location = new System.Drawing.Point(107, 116);
            this.det_Source.MaximumSize = new System.Drawing.Size(445, 23);
            this.det_Source.MinimumSize = new System.Drawing.Size(445, 23);
            this.det_Source.Name = "det_Source";
            this.det_Source.Size = new System.Drawing.Size(445, 20);
            this.det_Source.TabIndex = 3;
            this.det_Source.Leave += new System.EventHandler(this.SelectSource_FocusLeave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Source Folder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // det_Description
            // 
            this.det_Description.Location = new System.Drawing.Point(107, 62);
            this.det_Description.MaximumSize = new System.Drawing.Size(475, 46);
            this.det_Description.MinimumSize = new System.Drawing.Size(475, 46);
            this.det_Description.Multiline = true;
            this.det_Description.Name = "det_Description";
            this.det_Description.Size = new System.Drawing.Size(475, 46);
            this.det_Description.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Archive Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Logs
            // 
            this.Logs.Controls.Add(this.LogTextBox);
            this.Logs.Controls.Add(this.LogsListView);
            this.Logs.Location = new System.Drawing.Point(4, 25);
            this.Logs.Name = "Logs";
            this.Logs.Size = new System.Drawing.Size(603, 359);
            this.Logs.TabIndex = 2;
            this.Logs.Text = "Logs";
            this.Logs.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(166, 6);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(427, 376);
            this.LogTextBox.TabIndex = 6;
            this.LogTextBox.Text = "";
            // 
            // LogsListView
            // 
            this.LogsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LogDate});
            this.LogsListView.FullRowSelect = true;
            this.LogsListView.GridLines = true;
            this.LogsListView.HideSelection = false;
            this.LogsListView.Location = new System.Drawing.Point(6, 6);
            this.LogsListView.MultiSelect = false;
            this.LogsListView.Name = "LogsListView";
            this.LogsListView.ShowItemToolTips = true;
            this.LogsListView.Size = new System.Drawing.Size(154, 342);
            this.LogsListView.TabIndex = 5;
            this.LogsListView.UseCompatibleStateImageBehavior = false;
            this.LogsListView.View = System.Windows.Forms.View.Details;
            this.LogsListView.SelectedIndexChanged += new System.EventHandler(this.LogsListView_SelectedIndexChanged);
            // 
            // LogDate
            // 
            this.LogDate.Text = "Log Date";
            this.LogDate.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 395);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "CURRENT ARCHIVE:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSelected
            // 
            this.lblSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelected.AutoSize = true;
            this.lblSelected.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblSelected.Location = new System.Drawing.Point(153, 390);
            this.lblSelected.MinimumSize = new System.Drawing.Size(440, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Padding = new System.Windows.Forms.Padding(5);
            this.lblSelected.Size = new System.Drawing.Size(440, 23);
            this.lblSelected.TabIndex = 7;
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.AutoSize = true;
            this.lblProgress.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblProgress.Location = new System.Drawing.Point(153, 418);
            this.lblProgress.MinimumSize = new System.Drawing.Size(440, 0);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Padding = new System.Windows.Forms.Padding(5);
            this.lblProgress.Size = new System.Drawing.Size(440, 23);
            this.lblProgress.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 422);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "PROGRESS:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // StopButton
            // 
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.ForeColor = System.Drawing.Color.Maroon;
            this.StopButton.Location = new System.Drawing.Point(10, 418);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(65, 23);
            this.StopButton.TabIndex = 9;
            this.StopButton.Text = "STOP";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabControls);
            this.MaximumSize = new System.Drawing.Size(625, 489);
            this.MinimumSize = new System.Drawing.Size(625, 489);
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Archive";
            this.TabControls.ResumeLayout(false);
            this.Archives.ResumeLayout(false);
            this.Details.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.Logs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView ArchivesListView;
        private System.Windows.Forms.ColumnHeader ArchiveName;
        private System.Windows.Forms.ColumnHeader LastRun;
        private System.Windows.Forms.TabControl TabControls;
        private System.Windows.Forms.TabPage Archives;
        private System.Windows.Forms.TabPage Details;
        private System.Windows.Forms.TabPage Logs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView LogsListView;
        private System.Windows.Forms.ColumnHeader LogDate;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.ColumnHeader Enabled;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox det_Backup;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox det_Source;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox det_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox det_Enabled;
        private System.Windows.Forms.TextBox det_ArchiveName;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox det_Schedule;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button BackupFolderSelect;
        private System.Windows.Forms.Button SourceFolderSelect;
        private System.Windows.Forms.Button RunArchiveButton;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox det_ActionCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button StopButton;
    }
}

