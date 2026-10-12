namespace BoardGame_Store
{
    partial class SpecialForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
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
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnBackupManual = new System.Windows.Forms.Button();
            this.chkBackupAuto = new System.Windows.Forms.CheckBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalUnit = new System.Windows.Forms.Label();
            this.grpReports = new System.Windows.Forms.GroupBox();
            this.lblOrderSelect = new System.Windows.Forms.Label();
            this.cmbOrder = new System.Windows.Forms.ComboBox();
            this.btnWord = new System.Windows.Forms.Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpImportExport.SuspendLayout();
            this.grpBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.grpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 26);
            this.lblTitle.TabIndex = 4;
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
            this.grpImportExport.Controls.Add(this.lblLog);
            this.grpImportExport.Controls.Add(this.txtLog);
            this.grpImportExport.Location = new System.Drawing.Point(20, 55);
            this.grpImportExport.Name = "grpImportExport";
            this.grpImportExport.Size = new System.Drawing.Size(860, 320);
            this.grpImportExport.TabIndex = 1;
            this.grpImportExport.TabStop = false;
            this.grpImportExport.Text = "Импорт / Экспорт данных (CSV)";
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(15, 28);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(71, 17);
            this.lblTables.TabIndex = 0;
            this.lblTables.Text = "Таблицы:";
            // 
            // clbTables
            // 
            this.clbTables.CheckOnClick = true;
            this.clbTables.FormattingEnabled = true;
            this.clbTables.IntegralHeight = false;
            this.clbTables.Location = new System.Drawing.Point(15, 50);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(200, 200);
            this.clbTables.TabIndex = 0;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(15, 258);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(99, 30);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Выбрать все";
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(120, 258);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(95, 30);
            this.btnDeselectAll.TabIndex = 2;
            this.btnDeselectAll.Text = "Очистить";
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(235, 28);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(144, 17);
            this.lblFolder.TabIndex = 3;
            this.lblFolder.Text = "Папка (CSV-файлы):";
            // 
            // txtFolder
            // 
            this.txtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolder.Location = new System.Drawing.Point(235, 50);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.ReadOnly = true;
            this.txtFolder.Size = new System.Drawing.Size(510, 23);
            this.txtFolder.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(755, 48);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 27);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Обзор...";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.Location = new System.Drawing.Point(235, 90);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.Size = new System.Drawing.Size(280, 40);
            this.btnExportSelected.TabIndex = 5;
            this.btnExportSelected.Text = "Экспорт выбранных →";
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);
            // 
            // btnImportSelected
            // 
            this.btnImportSelected.Location = new System.Drawing.Point(525, 90);
            this.btnImportSelected.Name = "btnImportSelected";
            this.btnImportSelected.Size = new System.Drawing.Size(280, 40);
            this.btnImportSelected.TabIndex = 6;
            this.btnImportSelected.Text = "← Импорт выбранных";
            this.btnImportSelected.Click += new System.EventHandler(this.btnImportSelected_Click);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(235, 145);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(57, 17);
            this.lblLog.TabIndex = 7;
            this.lblLog.Text = "Статус:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(235, 165);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(610, 140);
            this.txtLog.TabIndex = 2;
            this.txtLog.WordWrap = false;
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
            this.grpBackup.Location = new System.Drawing.Point(20, 385);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(860, 90);
            this.grpBackup.TabIndex = 2;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Резервное копирование БД";
            // 
            // btnBackupManual
            // 
            this.btnBackupManual.Location = new System.Drawing.Point(20, 30);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(220, 40);
            this.btnBackupManual.TabIndex = 0;
            this.btnBackupManual.Text = "Ручное резервирование";
            this.btnBackupManual.Click += new System.EventHandler(this.btnBackupManual_Click);
            // 
            // chkBackupAuto
            // 
            this.chkBackupAuto.AutoSize = true;
            this.chkBackupAuto.Location = new System.Drawing.Point(270, 40);
            this.chkBackupAuto.Name = "chkBackupAuto";
            this.chkBackupAuto.Size = new System.Drawing.Size(249, 21);
            this.chkBackupAuto.TabIndex = 1;
            this.chkBackupAuto.Text = "Автоматическое резервирование";
            this.chkBackupAuto.CheckedChanged += new System.EventHandler(this.chkBackupAuto_CheckedChanged);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(533, 40);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(60, 17);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Каждые";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(599, 38);
            this.nudInterval.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.nudInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(70, 23);
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
            this.lblIntervalUnit.Location = new System.Drawing.Point(679, 40);
            this.lblIntervalUnit.Name = "lblIntervalUnit";
            this.lblIntervalUnit.Size = new System.Drawing.Size(46, 17);
            this.lblIntervalUnit.TabIndex = 4;
            this.lblIntervalUnit.Text = "часов";
            // 
            // grpReports
            // 
            this.grpReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReports.Controls.Add(this.lblOrderSelect);
            this.grpReports.Controls.Add(this.cmbOrder);
            this.grpReports.Controls.Add(this.btnWord);
            this.grpReports.Controls.Add(this.lblPeriod);
            this.grpReports.Controls.Add(this.dtpFrom);
            this.grpReports.Controls.Add(this.lblTo);
            this.grpReports.Controls.Add(this.dtpTo);
            this.grpReports.Controls.Add(this.btnExcel);
            this.grpReports.Location = new System.Drawing.Point(20, 485);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(860, 160);
            this.grpReports.TabIndex = 3;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Печать чека и отчёты";
            // 
            // lblOrderSelect
            // 
            this.lblOrderSelect.AutoSize = true;
            this.lblOrderSelect.Location = new System.Drawing.Point(20, 40);
            this.lblOrderSelect.Name = "lblOrderSelect";
            this.lblOrderSelect.Size = new System.Drawing.Size(51, 17);
            this.lblOrderSelect.TabIndex = 0;
            this.lblOrderSelect.Text = "Заказ:";
            // 
            // cmbOrder
            // 
            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.Location = new System.Drawing.Point(90, 37);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(150, 24);
            this.cmbOrder.TabIndex = 1;
            // 
            // btnWord
            // 
            this.btnWord.Location = new System.Drawing.Point(270, 30);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(220, 40);
            this.btnWord.TabIndex = 2;
            this.btnWord.Text = "Печать чека (Word)";
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(20, 100);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(69, 17);
            this.lblPeriod.TabIndex = 3;
            this.lblPeriod.Text = "Период с";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(90, 97);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 23);
            this.dtpFrom.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(240, 100);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 17);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "по";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(280, 97);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 23);
            this.dtpTo.TabIndex = 6;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(440, 88);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Отчёт по выручке (Excel)";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(740, 665);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 720);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpImportExport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MinimumSize = new System.Drawing.Size(900, 720);
            this.Name = "SpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специальные возможности";
            this.grpImportExport.ResumeLayout(false);
            this.grpImportExport.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
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
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnBackupManual;
        private System.Windows.Forms.CheckBox chkBackupAuto;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lblIntervalUnit;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Label lblOrderSelect;
        private System.Windows.Forms.ComboBox cmbOrder;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnBack;
    }
}