namespace BoardGame_Store
{
    partial class SpecialForm
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

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpImportExport = new System.Windows.Forms.GroupBox();
            this.lblTables = new System.Windows.Forms.Label();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExportSelected = new System.Windows.Forms.Button();
            this.btnImportSelected = new System.Windows.Forms.Button();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnBackupManual = new System.Windows.Forms.Button();
            this.chkBackupAuto = new System.Windows.Forms.CheckBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalUnit = new System.Windows.Forms.Label();
            this.lblBackupsTitle = new System.Windows.Forms.Label();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnRefreshBackups = new System.Windows.Forms.Button();
            this.grpReports = new System.Windows.Forms.GroupBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpImportExport.SuspendLayout();
            this.grpBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.grpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(313, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Специальные возможности";
            // 
            // grpImportExport
            // 
            this.grpImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImportExport.Controls.Add(this.lblTables);
            this.grpImportExport.Controls.Add(this.clbTables);
            this.grpImportExport.Controls.Add(this.btnSelectAll);
            this.grpImportExport.Controls.Add(this.btnDeselectAll);
            this.grpImportExport.Controls.Add(this.lblFolder);
            this.grpImportExport.Controls.Add(this.txtFolder);
            this.grpImportExport.Controls.Add(this.btnBrowse);
            this.grpImportExport.Controls.Add(this.btnExportSelected);
            this.grpImportExport.Controls.Add(this.btnImportSelected);
            this.grpImportExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpImportExport.Location = new System.Drawing.Point(20, 50);
            this.grpImportExport.Name = "grpImportExport";
            this.grpImportExport.Size = new System.Drawing.Size(854, 190);
            this.grpImportExport.TabIndex = 2;
            this.grpImportExport.TabStop = false;
            this.grpImportExport.Text = "Импорт и экспорт CSV (отметьте нужные таблицы)";
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTables.Location = new System.Drawing.Point(20, 25);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(246, 15);
            this.lblTables.TabIndex = 0;
            this.lblTables.Text = "Отметьте таблицы для экспорта / импорта:";
            // 
            // clbTables
            // 
            this.clbTables.CheckOnClick = true;
            this.clbTables.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Location = new System.Drawing.Point(20, 45);
            this.clbTables.MultiColumn = true;
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(595, 76);
            this.clbTables.TabIndex = 1;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(625, 45);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(100, 30);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Выбрать все";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeselectAll.ForeColor = System.Drawing.Color.White;
            this.btnDeselectAll.Location = new System.Drawing.Point(735, 45);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(110, 30);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Снять все";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolder.Location = new System.Drawing.Point(20, 130);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(44, 15);
            this.lblFolder.TabIndex = 4;
            this.lblFolder.Text = "Папка:";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolder.Location = new System.Drawing.Point(80, 127);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(527, 23);
            this.txtFolder.TabIndex = 5;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(625, 122);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(100, 28);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Обзор...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSelected.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportSelected.ForeColor = System.Drawing.Color.White;
            this.btnExportSelected.Location = new System.Drawing.Point(20, 155);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.Size = new System.Drawing.Size(200, 30);
            this.btnExportSelected.TabIndex = 7;
            this.btnExportSelected.Text = "Экспорт выбранных в CSV";
            this.btnExportSelected.UseVisualStyleBackColor = false;
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);
            // 
            // btnImportSelected
            // 
            this.btnImportSelected.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnImportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSelected.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportSelected.ForeColor = System.Drawing.Color.White;
            this.btnImportSelected.Location = new System.Drawing.Point(240, 155);
            this.btnImportSelected.Name = "btnImportSelected";
            this.btnImportSelected.Size = new System.Drawing.Size(200, 30);
            this.btnImportSelected.TabIndex = 8;
            this.btnImportSelected.Text = "Импорт из CSV";
            this.btnImportSelected.UseVisualStyleBackColor = false;
            this.btnImportSelected.Click += new System.EventHandler(this.btnImportSelected_Click);
            // 
            // grpBackup
            // 
            this.grpBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBackup.Controls.Add(this.btnBackupManual);
            this.grpBackup.Controls.Add(this.chkBackupAuto);
            this.grpBackup.Controls.Add(this.lblInterval);
            this.grpBackup.Controls.Add(this.nudInterval);
            this.grpBackup.Controls.Add(this.lblIntervalUnit);
            this.grpBackup.Controls.Add(this.lblBackupsTitle);
            this.grpBackup.Controls.Add(this.dgvBackups);
            this.grpBackup.Controls.Add(this.btnRestore);
            this.grpBackup.Controls.Add(this.btnRefreshBackups);
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBackup.Location = new System.Drawing.Point(20, 250);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(854, 210);
            this.grpBackup.TabIndex = 3;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Резервное копирование и Восстановление";
            // 
            // btnBackupManual
            // 
            this.btnBackupManual.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBackupManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupManual.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupManual.ForeColor = System.Drawing.Color.White;
            this.btnBackupManual.Location = new System.Drawing.Point(20, 28);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(220, 32);
            this.btnBackupManual.TabIndex = 0;
            this.btnBackupManual.Text = "Создать ручной бэкап";
            this.btnBackupManual.UseVisualStyleBackColor = false;
            this.btnBackupManual.Click += new System.EventHandler(this.btnBackupManual_Click);
            // 
            // chkBackupAuto
            // 
            this.chkBackupAuto.AutoSize = true;
            this.chkBackupAuto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkBackupAuto.Location = new System.Drawing.Point(280, 35);
            this.chkBackupAuto.Name = "chkBackupAuto";
            this.chkBackupAuto.Size = new System.Drawing.Size(154, 23);
            this.chkBackupAuto.TabIndex = 1;
            this.chkBackupAuto.Text = "Авторезерв каждые";
            this.chkBackupAuto.UseVisualStyleBackColor = true;
            this.chkBackupAuto.CheckedChanged += new System.EventHandler(this.chkBackupAuto_CheckedChanged);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblInterval.Location = new System.Drawing.Point(490, 35);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(0, 19);
            this.lblInterval.TabIndex = 2;
            // 
            // nudInterval
            // 
            this.nudInterval.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudInterval.Location = new System.Drawing.Point(490, 32);
            this.nudInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(70, 25);
            this.nudInterval.TabIndex = 3;
            this.nudInterval.Value = new decimal(new int[] {
            24,
            0,
            0,
            0});
            // 
            // lblIntervalUnit
            // 
            this.lblIntervalUnit.AutoSize = true;
            this.lblIntervalUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblIntervalUnit.Location = new System.Drawing.Point(570, 35);
            this.lblIntervalUnit.Name = "lblIntervalUnit";
            this.lblIntervalUnit.Size = new System.Drawing.Size(45, 19);
            this.lblIntervalUnit.TabIndex = 4;
            this.lblIntervalUnit.Text = "часов";
            // 
            // lblBackupsTitle
            // 
            this.lblBackupsTitle.AutoSize = true;
            this.lblBackupsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupsTitle.Location = new System.Drawing.Point(20, 75);
            this.lblBackupsTitle.Name = "lblBackupsTitle";
            this.lblBackupsTitle.Size = new System.Drawing.Size(247, 15);
            this.lblBackupsTitle.TabIndex = 5;
            this.lblBackupsTitle.Text = "Доступные копии в выбранной папке (.sql):";
            // 
            // dgvBackups
            // 
            this.dgvBackups.AllowUserToAddRows = false;
            this.dgvBackups.AllowUserToDeleteRows = false;
            this.dgvBackups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackups.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackups.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(20, 95);
            this.dgvBackups.MultiSelect = false;
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.RowHeadersVisible = false;
            this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackups.Size = new System.Drawing.Size(600, 95);
            this.dgvBackups.TabIndex = 6;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.DarkRed;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(632, 95);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(200, 45);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Восстановить базу";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnRefreshBackups
            // 
            this.btnRefreshBackups.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshBackups.BackColor = System.Drawing.Color.Gray;
            this.btnRefreshBackups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshBackups.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshBackups.ForeColor = System.Drawing.Color.White;
            this.btnRefreshBackups.Location = new System.Drawing.Point(632, 145);
            this.btnRefreshBackups.Name = "btnRefreshBackups";
            this.btnRefreshBackups.Size = new System.Drawing.Size(200, 30);
            this.btnRefreshBackups.TabIndex = 8;
            this.btnRefreshBackups.Text = "Обновить список";
            this.btnRefreshBackups.UseVisualStyleBackColor = false;
            this.btnRefreshBackups.Click += new System.EventHandler(this.btnRefreshBackups_Click);
            // 
            // grpReports
            // 
            this.grpReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReports.Controls.Add(this.lblPeriod);
            this.grpReports.Controls.Add(this.dtpFrom);
            this.grpReports.Controls.Add(this.lblTo);
            this.grpReports.Controls.Add(this.dtpTo);
            this.grpReports.Controls.Add(this.btnExcel);
            this.grpReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpReports.Location = new System.Drawing.Point(20, 470);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(854, 100);
            this.grpReports.TabIndex = 4;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Отчёты";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPeriod.Location = new System.Drawing.Point(20, 30);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(58, 15);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Период с";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(90, 27);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(220, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "по";
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(250, 27);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(376, 24);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(350, 32);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Сформировать отчёт в Excel (CSV)";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblLog
            // 
            this.lblLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLog.Location = new System.Drawing.Point(20, 580);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(116, 15);
            this.lblLog.TabIndex = 5;
            this.lblLog.Text = "Журнал операций:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(20, 600);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(854, 140);
            this.txtLog.TabIndex = 6;
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 760);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpImportExport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SpecialForm";
            this.Text = "Специальные возможности";
            this.grpImportExport.ResumeLayout(false);
            this.grpImportExport.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.grpReports.ResumeLayout(false);
            this.grpReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpImportExport;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExportSelected;
        private System.Windows.Forms.Button btnImportSelected;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnBackupManual;
        private System.Windows.Forms.CheckBox chkBackupAuto;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lblIntervalUnit;
        private System.Windows.Forms.Label lblBackupsTitle;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnRefreshBackups;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
    }
}