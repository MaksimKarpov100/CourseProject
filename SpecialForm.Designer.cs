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
            this.lblRole = new System.Windows.Forms.Label();
            this.grpImportExport = new System.Windows.Forms.GroupBox();
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.btnBackupManual = new System.Windows.Forms.Button();
            this.chkBackupAuto = new System.Windows.Forms.CheckBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.lblIntervalUnit = new System.Windows.Forms.Label();
            this.grpReports = new System.Windows.Forms.GroupBox();
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
            this.lblTitle.Location = new System.Drawing.Point(244, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(319, 26);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Специальные возможности";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(94, 17);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "[Роль] [ФИО]";
            // 
            // grpImportExport
            // 
            this.grpImportExport.Controls.Add(this.btnImportCsv);
            this.grpImportExport.Controls.Add(this.btnExportCsv);
            this.grpImportExport.Location = new System.Drawing.Point(20, 55);
            this.grpImportExport.Name = "grpImportExport";
            this.grpImportExport.Size = new System.Drawing.Size(770, 100);
            this.grpImportExport.TabIndex = 3;
            this.grpImportExport.TabStop = false;
            this.grpImportExport.Text = "Импорт и экспорт данных (CSV)";
            // 
            // btnImportCsv
            // 
            this.btnImportCsv.Location = new System.Drawing.Point(30, 35);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(180, 45);
            this.btnImportCsv.TabIndex = 0;
            this.btnImportCsv.Text = "Импорт из CSV";
            this.btnImportCsv.UseVisualStyleBackColor = true;
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Location = new System.Drawing.Point(240, 35);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(180, 45);
            this.btnExportCsv.TabIndex = 1;
            this.btnExportCsv.Text = "Экспорт в CSV";
            this.btnExportCsv.UseVisualStyleBackColor = true;
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.btnBackupManual);
            this.grpBackup.Controls.Add(this.chkBackupAuto);
            this.grpBackup.Controls.Add(this.lblInterval);
            this.grpBackup.Controls.Add(this.nudInterval);
            this.grpBackup.Controls.Add(this.lblIntervalUnit);
            this.grpBackup.Location = new System.Drawing.Point(20, 165);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(770, 110);
            this.grpBackup.TabIndex = 2;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Резервное копирование базы данных";
            // 
            // btnBackupManual
            // 
            this.btnBackupManual.Location = new System.Drawing.Point(30, 30);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(180, 45);
            this.btnBackupManual.TabIndex = 0;
            this.btnBackupManual.Text = "Ручное резервное копирование";
            this.btnBackupManual.UseVisualStyleBackColor = true;
            // 
            // chkBackupAuto
            // 
            this.chkBackupAuto.AutoSize = true;
            this.chkBackupAuto.Location = new System.Drawing.Point(240, 42);
            this.chkBackupAuto.Name = "chkBackupAuto";
            this.chkBackupAuto.Size = new System.Drawing.Size(249, 21);
            this.chkBackupAuto.TabIndex = 1;
            this.chkBackupAuto.Text = "Автоматическое резервирование";
            this.chkBackupAuto.UseVisualStyleBackColor = true;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(440, 43);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(60, 17);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Каждые";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(520, 41);
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
            this.lblIntervalUnit.Location = new System.Drawing.Point(600, 43);
            this.lblIntervalUnit.Name = "lblIntervalUnit";
            this.lblIntervalUnit.Size = new System.Drawing.Size(46, 17);
            this.lblIntervalUnit.TabIndex = 4;
            this.lblIntervalUnit.Text = "часов";
            // 
            // grpReports
            // 
            this.grpReports.Controls.Add(this.lblPeriod);
            this.grpReports.Controls.Add(this.dtpFrom);
            this.grpReports.Controls.Add(this.lblTo);
            this.grpReports.Controls.Add(this.dtpTo);
            this.grpReports.Controls.Add(this.btnExcel);
            this.grpReports.Location = new System.Drawing.Point(20, 285);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(770, 140);
            this.grpReports.TabIndex = 1;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Формирование отчётов";
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(30, 40);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(69, 17);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Период с";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(100, 37);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(240, 40);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 17);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "по";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(270, 37);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.TabIndex = 3;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(30, 75);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(200, 40);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "Сформировать отчёт Excel 2019";
            this.btnExcel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(680, 435);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 490);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpImportExport);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специальные возможности";
            this.grpImportExport.ResumeLayout(false);
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.grpReports.ResumeLayout(false);
            this.grpReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.GroupBox grpImportExport;
        private System.Windows.Forms.Button btnImportCsv;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Button btnBackupManual;
        private System.Windows.Forms.CheckBox chkBackupAuto;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.Label lblIntervalUnit;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnBack;
    }
}