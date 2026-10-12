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
            this.btnImportCsv = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
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

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(340, 26);
            this.lblTitle.Text = "Специальные возможности";

            // grpImportExport
            this.grpImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImportExport.Controls.Add(this.btnImportCsv);
            this.grpImportExport.Controls.Add(this.btnExportCsv);
            this.grpImportExport.Location = new System.Drawing.Point(20, 60);
            this.grpImportExport.Name = "grpImportExport";
            this.grpImportExport.Size = new System.Drawing.Size(780, 100);
            this.grpImportExport.TabIndex = 1;
            this.grpImportExport.TabStop = false;
            this.grpImportExport.Text = "Импорт и экспорт данных (CSV)";

            this.btnImportCsv.Location = new System.Drawing.Point(30, 35);
            this.btnImportCsv.Name = "btnImportCsv";
            this.btnImportCsv.Size = new System.Drawing.Size(220, 45);
            this.btnImportCsv.Text = "Импорт из CSV";
            this.btnImportCsv.Click += new System.EventHandler(this.btnImportCsv_Click);

            this.btnExportCsv.Location = new System.Drawing.Point(280, 35);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(220, 45);
            this.btnExportCsv.Text = "Экспорт в CSV";
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);

            // grpBackup
            this.grpBackup.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBackup.Controls.Add(this.btnBackupManual);
            this.grpBackup.Controls.Add(this.chkBackupAuto);
            this.grpBackup.Controls.Add(this.lblInterval);
            this.grpBackup.Controls.Add(this.nudInterval);
            this.grpBackup.Controls.Add(this.lblIntervalUnit);
            this.grpBackup.Location = new System.Drawing.Point(20, 170);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(780, 110);
            this.grpBackup.TabIndex = 2;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Резервное копирование БД";

            this.btnBackupManual.Location = new System.Drawing.Point(30, 35);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(220, 45);
            this.btnBackupManual.Text = "Ручное резервирование";
            this.btnBackupManual.Click += new System.EventHandler(this.btnBackupManual_Click);

            this.chkBackupAuto.AutoSize = true;
            this.chkBackupAuto.Location = new System.Drawing.Point(280, 48);
            this.chkBackupAuto.Name = "chkBackupAuto";
            this.chkBackupAuto.Size = new System.Drawing.Size(210, 21);
            this.chkBackupAuto.Text = "Автоматическое резервирование";
            this.chkBackupAuto.CheckedChanged += new System.EventHandler(this.chkBackupAuto_CheckedChanged);

            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(510, 48);
            this.lblInterval.Size = new System.Drawing.Size(60, 17);
            this.lblInterval.Text = "Каждые";

            this.nudInterval.Location = new System.Drawing.Point(590, 46);
            this.nudInterval.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            this.nudInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(70, 23);
            this.nudInterval.Value = new decimal(new int[] { 24, 0, 0, 0 });

            this.lblIntervalUnit.AutoSize = true;
            this.lblIntervalUnit.Location = new System.Drawing.Point(670, 48);
            this.lblIntervalUnit.Size = new System.Drawing.Size(45, 17);
            this.lblIntervalUnit.Text = "часов";

            // grpReports
            this.grpReports.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReports.Controls.Add(this.lblOrderSelect);
            this.grpReports.Controls.Add(this.cmbOrder);
            this.grpReports.Controls.Add(this.btnWord);
            this.grpReports.Controls.Add(this.lblPeriod);
            this.grpReports.Controls.Add(this.dtpFrom);
            this.grpReports.Controls.Add(this.lblTo);
            this.grpReports.Controls.Add(this.dtpTo);
            this.grpReports.Controls.Add(this.btnExcel);
            this.grpReports.Location = new System.Drawing.Point(20, 290);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(780, 180);
            this.grpReports.TabIndex = 3;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Печать чека и отчёты";

            this.lblOrderSelect.AutoSize = true;
            this.lblOrderSelect.Location = new System.Drawing.Point(30, 40);
            this.lblOrderSelect.Size = new System.Drawing.Size(55, 17);
            this.lblOrderSelect.Text = "Заказ:";

            this.cmbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrder.Location = new System.Drawing.Point(100, 37);
            this.cmbOrder.Name = "cmbOrder";
            this.cmbOrder.Size = new System.Drawing.Size(150, 24);

            this.btnWord.Location = new System.Drawing.Point(280, 30);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(220, 40);
            this.btnWord.Text = "Печать чека (Word)";
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);

            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(30, 100);
            this.lblPeriod.Size = new System.Drawing.Size(65, 17);
            this.lblPeriod.Text = "Период с";

            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(100, 97);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 23);

            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(250, 100);
            this.lblTo.Size = new System.Drawing.Size(26, 17);
            this.lblTo.Text = "по";

            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(290, 97);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 23);

            this.btnExcel.Location = new System.Drawing.Point(450, 88);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(280, 40);
            this.btnExcel.Text = "Отчёт по выручке (Excel)";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // btnBack
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(660, 495);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // SpecialForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 560);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpImportExport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(830, 560);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "SpecialForm";
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