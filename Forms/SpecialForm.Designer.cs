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
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.lblTables = new System.Windows.Forms.Label();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExportSelected = new System.Windows.Forms.Button();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.lblBackupsTitle = new System.Windows.Forms.Label();
            this.btnBackupManual = new System.Windows.Forms.Button();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.btnRestore = new System.Windows.Forms.Button();
            this.grpReports = new System.Windows.Forms.GroupBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpImportExport.SuspendLayout();
            this.grpBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.grpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(984, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Специальные возможности";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpImportExport
            // 
            this.grpImportExport.Controls.Add(this.btnDeselectAll);
            this.grpImportExport.Controls.Add(this.btnSelectAll);
            this.grpImportExport.Controls.Add(this.lblTables);
            this.grpImportExport.Controls.Add(this.clbTables);
            this.grpImportExport.Controls.Add(this.lblFolder);
            this.grpImportExport.Controls.Add(this.txtFolder);
            this.grpImportExport.Controls.Add(this.btnBrowse);
            this.grpImportExport.Controls.Add(this.btnExportSelected);
            this.grpImportExport.Controls.Add(this.btnImportCSV);
            this.grpImportExport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpImportExport.Location = new System.Drawing.Point(20, 60);
            this.grpImportExport.Name = "grpImportExport";
            this.grpImportExport.Size = new System.Drawing.Size(460, 260);
            this.grpImportExport.TabIndex = 1;
            this.grpImportExport.TabStop = false;
            this.grpImportExport.Text = "Импорт / Экспорт CSV";
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnDeselectAll.Location = new System.Drawing.Point(350, 45);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(90, 25);
            this.btnDeselectAll.TabIndex = 8;
            this.btnDeselectAll.Text = "Снять все";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnSelectAll.Location = new System.Drawing.Point(350, 15);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(90, 25);
            this.btnSelectAll.TabIndex = 7;
            this.btnSelectAll.Text = "Выбрать все";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTables.Location = new System.Drawing.Point(15, 25);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(140, 15);
            this.lblTables.TabIndex = 0;
            this.lblTables.Text = "Таблицы для экспорта:";
            // 
            // clbTables
            // 
            this.clbTables.CheckOnClick = true;
            this.clbTables.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Items.AddRange(new object[] {
            "users",
            "customers",
            "categories",
            "statuses",
            "board_games",
            "orders",
            "order_items"});
            this.clbTables.Location = new System.Drawing.Point(15, 45);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(320, 130);
            this.clbTables.TabIndex = 1;
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFolder.Location = new System.Drawing.Point(15, 189);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(47, 15);
            this.lblFolder.TabIndex = 2;
            this.lblFolder.Text = "Папка:";
            // 
            // txtFolder
            // 
            this.txtFolder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFolder.Location = new System.Drawing.Point(70, 186);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(280, 23);
            this.txtFolder.TabIndex = 3;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(360, 184);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(80, 27);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Обзор...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.BackColor = System.Drawing.Color.DarkOrange;
            this.btnExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSelected.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportSelected.ForeColor = System.Drawing.Color.White;
            this.btnExportSelected.Location = new System.Drawing.Point(15, 220);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.Size = new System.Drawing.Size(210, 30);
            this.btnExportSelected.TabIndex = 5;
            this.btnExportSelected.Text = "Экспорт выбранных в CSV";
            this.btnExportSelected.UseVisualStyleBackColor = false;
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.BackColor = System.Drawing.Color.SteelBlue;
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportCSV.ForeColor = System.Drawing.Color.White;
            this.btnImportCSV.Location = new System.Drawing.Point(235, 220);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(210, 30);
            this.btnImportCSV.TabIndex = 6;
            this.btnImportCSV.Text = "Импорт из CSV";
            this.btnImportCSV.UseVisualStyleBackColor = false;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.lblBackupsTitle);
            this.grpBackup.Controls.Add(this.btnBackupManual);
            this.grpBackup.Controls.Add(this.dgvBackups);
            this.grpBackup.Controls.Add(this.btnRestore);
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpBackup.Location = new System.Drawing.Point(500, 60);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(460, 260);
            this.grpBackup.TabIndex = 2;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Резервное копирование";
            // 
            // lblBackupsTitle
            // 
            this.lblBackupsTitle.AutoSize = true;
            this.lblBackupsTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupsTitle.Location = new System.Drawing.Point(15, 25);
            this.lblBackupsTitle.Name = "lblBackupsTitle";
            this.lblBackupsTitle.Size = new System.Drawing.Size(115, 15);
            this.lblBackupsTitle.TabIndex = 0;
            this.lblBackupsTitle.Text = "Доступные бэкапы:";
            // 
            // btnBackupManual
            // 
            this.btnBackupManual.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBackupManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupManual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBackupManual.ForeColor = System.Drawing.Color.White;
            this.btnBackupManual.Location = new System.Drawing.Point(15, 220);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(210, 30);
            this.btnBackupManual.TabIndex = 1;
            this.btnBackupManual.Text = "Создать ручной бэкап";
            this.btnBackupManual.UseVisualStyleBackColor = false;
            this.btnBackupManual.Click += new System.EventHandler(this.btnBackupManual_Click);
            // 
            // dgvBackups
            // 
            this.dgvBackups.AllowUserToAddRows = false;
            this.dgvBackups.AllowUserToDeleteRows = false;
            this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackups.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Location = new System.Drawing.Point(15, 45);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.RowHeadersVisible = false;
            this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackups.Size = new System.Drawing.Size(430, 160);
            this.dgvBackups.TabIndex = 3;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.Firebrick;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(235, 220);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(210, 30);
            this.btnRestore.TabIndex = 4;
            this.btnRestore.Text = "Восстановить базу";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // grpReports
            // 
            this.grpReports.Controls.Add(this.btnExcel);
            this.grpReports.Controls.Add(this.dtpTo);
            this.grpReports.Controls.Add(this.lblTo);
            this.grpReports.Controls.Add(this.dtpFrom);
            this.grpReports.Controls.Add(this.lblFrom);
            this.grpReports.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.grpReports.Location = new System.Drawing.Point(20, 330);
            this.grpReports.Name = "grpReports";
            this.grpReports.Size = new System.Drawing.Size(940, 100);
            this.grpReports.TabIndex = 3;
            this.grpReports.TabStop = false;
            this.grpReports.Text = "Формирование отчетов";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Black;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(500, 35);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(300, 40);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Сформировать отчет в Excel (CSV)";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(340, 42);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 25);
            this.dtpTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTo.Location = new System.Drawing.Point(300, 45);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 19);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "по";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(150, 42);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 25);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFrom.Location = new System.Drawing.Point(30, 45);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(104, 19);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Период с:";
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLog.Location = new System.Drawing.Point(20, 440);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(143, 19);
            this.lblLog.TabIndex = 4;
            this.lblLog.Text = "Журнал операций:";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtLog.Location = new System.Drawing.Point(20, 465);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(940, 120);
            this.txtLog.TabIndex = 5;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(830, 600);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 40);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SpecialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(984, 650);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.grpReports);
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpImportExport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "SpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специальные возможности";
            this.Load += new System.EventHandler(this.SpecialForm_Load);
            this.grpImportExport.ResumeLayout(false);
            this.grpImportExport.PerformLayout();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.grpReports.ResumeLayout(false);
            this.grpReports.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpImportExport;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExportSelected;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Label lblBackupsTitle;
        private System.Windows.Forms.Button btnBackupManual;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.GroupBox grpReports;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnBack;
    }
}