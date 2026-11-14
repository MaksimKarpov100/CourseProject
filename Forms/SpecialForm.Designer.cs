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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpecialForm));
            this.lblTitle = new System.Windows.Forms.Label();

            // Панели-карточки
            this.panelImport = new System.Windows.Forms.Panel();
            this.panelBackup = new System.Windows.Forms.Panel();
            this.panelReports = new System.Windows.Forms.Panel();
            this.panelLog = new System.Windows.Forms.Panel();

            // Элементы Импорта/Экспорта
            this.lblImportTitle = new System.Windows.Forms.Label();
            this.clbTables = new System.Windows.Forms.CheckedListBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnExportSelected = new System.Windows.Forms.Button();
            this.btnImportCSV = new System.Windows.Forms.Button();

            // Элементы Бэкапа
            this.lblBackupTitle = new System.Windows.Forms.Label();
            this.dgvBackups = new System.Windows.Forms.DataGridView();
            this.btnBackupManual = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();

            // Элементы Отчетов
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();

            // Элементы Лога
            this.lblLogTitle = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();

            this.panelImport.SuspendLayout();
            this.panelBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).BeginInit();
            this.panelReports.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1024, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Специальные возможности";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // ==================== КАРТОЧКА 1: ИМПОРТ/ЭКСПОРТ ====================
            // ИСПРАВЛЕНИЕ: Привязываем к левому верхнему углу
            this.panelImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.panelImport.BackColor = System.Drawing.Color.White;
            this.panelImport.Controls.Add(this.lblImportTitle);
            this.panelImport.Controls.Add(this.clbTables);
            this.panelImport.Controls.Add(this.btnSelectAll);
            this.panelImport.Controls.Add(this.btnDeselectAll);
            this.panelImport.Controls.Add(this.lblFolder);
            this.panelImport.Controls.Add(this.txtFolder);
            this.panelImport.Controls.Add(this.btnBrowse);
            this.panelImport.Controls.Add(this.btnExportSelected);
            this.panelImport.Controls.Add(this.btnImportCSV);
            this.panelImport.Location = new System.Drawing.Point(20, 70);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(480, 330);
            this.panelImport.TabIndex = 1;
            this.panelImport.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblImportTitle.AutoSize = true;
            this.lblImportTitle.Font = new System.Drawing.Font("Trebuchet MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblImportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblImportTitle.Location = new System.Drawing.Point(20, 15);
            this.lblImportTitle.Name = "lblImportTitle";
            this.lblImportTitle.Size = new System.Drawing.Size(230, 24);
            this.lblImportTitle.Text = "1. Импорт / Экспорт CSV";

            this.clbTables.CheckOnClick = true;
            this.clbTables.Font = new System.Drawing.Font("Tahoma", 10F);
            this.clbTables.FormattingEnabled = true;
            this.clbTables.Items.AddRange(new object[] { "users", "customers", "categories", "statuses", "board_games", "orders", "order_items" });
            this.clbTables.Location = new System.Drawing.Point(20, 50);
            this.clbTables.Name = "clbTables";
            this.clbTables.Size = new System.Drawing.Size(280, 154);
            this.clbTables.TabIndex = 1;

            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSelectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectAll.FlatAppearance.BorderSize = 0;
            this.btnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(315, 50);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(140, 32);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Выбрать все";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);

            this.btnDeselectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDeselectAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeselectAll.FlatAppearance.BorderSize = 0;
            this.btnDeselectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnDeselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeselectAll.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeselectAll.ForeColor = System.Drawing.Color.White;
            this.btnDeselectAll.Location = new System.Drawing.Point(315, 90);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(140, 32);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Снять все";
            this.btnDeselectAll.UseVisualStyleBackColor = false;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);

            this.lblFolder.AutoSize = true;
            this.lblFolder.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFolder.ForeColor = System.Drawing.Color.DimGray;
            this.lblFolder.Location = new System.Drawing.Point(20, 220);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(51, 17);
            this.lblFolder.Text = "Папка:";

            this.txtFolder.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFolder.Location = new System.Drawing.Point(75, 217);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(280, 24);
            this.txtFolder.TabIndex = 4;

            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowse.FlatAppearance.BorderSize = 0;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(365, 215);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 28);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Обзор...";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            this.btnExportSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportSelected.FlatAppearance.BorderSize = 0;
            this.btnExportSelected.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnExportSelected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSelected.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportSelected.ForeColor = System.Drawing.Color.White;
            this.btnExportSelected.Location = new System.Drawing.Point(20, 265);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.Size = new System.Drawing.Size(210, 45);
            this.btnExportSelected.TabIndex = 6;
            this.btnExportSelected.Text = "Экспорт в CSV";
            this.btnExportSelected.UseVisualStyleBackColor = false;
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);

            this.btnImportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImportCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportCSV.FlatAppearance.BorderSize = 0;
            this.btnImportCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnImportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCSV.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportCSV.ForeColor = System.Drawing.Color.White;
            this.btnImportCSV.Location = new System.Drawing.Point(240, 265);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(210, 45);
            this.btnImportCSV.TabIndex = 7;
            this.btnImportCSV.Text = "Импорт из CSV";
            this.btnImportCSV.UseVisualStyleBackColor = false;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);

            // ==================== КАРТОЧКА 2: БЭКАП ====================
            // ИСПРАВЛЕНИЕ: Привязываем к правому верхнему углу
            this.panelBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBackup.BackColor = System.Drawing.Color.White;
            this.panelBackup.Controls.Add(this.lblBackupTitle);
            this.panelBackup.Controls.Add(this.dgvBackups);
            this.panelBackup.Controls.Add(this.btnBackupManual);
            this.panelBackup.Controls.Add(this.btnRestore);
            this.panelBackup.Location = new System.Drawing.Point(520, 70);
            this.panelBackup.Name = "panelBackup";
            this.panelBackup.Size = new System.Drawing.Size(480, 330);
            this.panelBackup.TabIndex = 2;
            this.panelBackup.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblBackupTitle.AutoSize = true;
            this.lblBackupTitle.Font = new System.Drawing.Font("Trebuchet MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblBackupTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblBackupTitle.Location = new System.Drawing.Point(20, 15);
            this.lblBackupTitle.Name = "lblBackupTitle";
            this.lblBackupTitle.Size = new System.Drawing.Size(240, 24);
            this.lblBackupTitle.Text = "2. Резервное копирование";

            this.dgvBackups.AllowUserToAddRows = false;
            this.dgvBackups.AllowUserToDeleteRows = false;
            this.dgvBackups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBackups.BackgroundColor = System.Drawing.Color.White;
            this.dgvBackups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBackups.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvBackups.Location = new System.Drawing.Point(20, 50);
            this.dgvBackups.Name = "dgvBackups";
            this.dgvBackups.ReadOnly = true;
            this.dgvBackups.RowHeadersVisible = false;
            this.dgvBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBackups.Size = new System.Drawing.Size(440, 195);
            this.dgvBackups.TabIndex = 0;

            this.btnBackupManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBackupManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupManual.FlatAppearance.BorderSize = 0;
            this.btnBackupManual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBackupManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupManual.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackupManual.ForeColor = System.Drawing.Color.White;
            this.btnBackupManual.Location = new System.Drawing.Point(20, 265);
            this.btnBackupManual.Name = "btnBackupManual";
            this.btnBackupManual.Size = new System.Drawing.Size(210, 45);
            this.btnBackupManual.TabIndex = 1;
            this.btnBackupManual.Text = "Создать бэкап";
            this.btnBackupManual.UseVisualStyleBackColor = false;
            this.btnBackupManual.Click += new System.EventHandler(this.btnBackupManual_Click);

            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(240, 265);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(220, 45);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Восстановить БД";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            // ==================== КАРТОЧКА 3: ОТЧЕТЫ ====================
            // ИСПРАВЛЕНИЕ: Привязываем к левому и правому краям, чтобы растягивалась
            this.panelReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReports.BackColor = System.Drawing.Color.White;
            this.panelReports.Controls.Add(this.lblReportTitle);
            this.panelReports.Controls.Add(this.lblFrom);
            this.panelReports.Controls.Add(this.dtpFrom);
            this.panelReports.Controls.Add(this.lblTo);
            this.panelReports.Controls.Add(this.dtpTo);
            this.panelReports.Controls.Add(this.btnExcel);
            this.panelReports.Location = new System.Drawing.Point(20, 415);
            this.panelReports.Name = "panelReports";
            this.panelReports.Size = new System.Drawing.Size(980, 100);
            this.panelReports.TabIndex = 3;
            this.panelReports.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblReportTitle.Location = new System.Drawing.Point(20, 15);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(200, 22);
            this.lblReportTitle.Text = "3. Формирование отчетов";

            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFrom.ForeColor = System.Drawing.Color.DimGray;
            this.lblFrom.Location = new System.Drawing.Point(20, 55);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(66, 17);
            this.lblFrom.Text = "Период с:";

            this.dtpFrom.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(100, 52);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(150, 24);
            this.dtpFrom.TabIndex = 1;

            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTo.ForeColor = System.Drawing.Color.DimGray;
            this.lblTo.Location = new System.Drawing.Point(270, 55);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(25, 17);
            this.lblTo.Text = "по:";

            this.dtpTo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(310, 52);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(150, 24);
            this.dtpTo.TabIndex = 3;

            // Кнопку отчета прижимаем к правому краю внутри панели отчетов
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(640, 35);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(300, 45);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "Сформировать отчет в Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);

            // ==================== КАРТОЧКА 4: ЛОГ ====================
            // Привязываем ко всем краям, чтобы растягивалась везде
            this.panelLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLog.BackColor = System.Drawing.Color.White;
            this.panelLog.Controls.Add(this.lblLogTitle);
            this.panelLog.Controls.Add(this.txtLog);
            this.panelLog.Location = new System.Drawing.Point(20, 530);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(980, 170);
            this.panelLog.TabIndex = 4;
            this.panelLog.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);

            this.lblLogTitle.AutoSize = true;
            this.lblLogTitle.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblLogTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblLogTitle.Location = new System.Drawing.Point(20, 10);
            this.lblLogTitle.Name = "lblLogTitle";
            this.lblLogTitle.Size = new System.Drawing.Size(140, 20);
            this.lblLogTitle.Text = "Журнал операций";

            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtLog.Location = new System.Drawing.Point(20, 40);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(940, 115);
            this.txtLog.TabIndex = 0;

            // SpecialForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.panelLog);
            this.Controls.Add(this.panelReports);
            this.Controls.Add(this.panelBackup);
            this.Controls.Add(this.panelImport);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpecialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Специальные возможности";
            this.Load += new System.EventHandler(this.SpecialForm_Load);

            this.panelImport.ResumeLayout(false);
            this.panelImport.PerformLayout();
            this.panelBackup.ResumeLayout(false);
            this.panelBackup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBackups)).EndInit();
            this.panelReports.ResumeLayout(false);
            this.panelReports.PerformLayout();
            this.panelLog.ResumeLayout(false);
            this.panelLog.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelImport;
        private System.Windows.Forms.Label lblImportTitle;
        private System.Windows.Forms.CheckedListBox clbTables;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnExportSelected;
        private System.Windows.Forms.Button btnImportCSV;

        private System.Windows.Forms.Panel panelBackup;
        private System.Windows.Forms.Label lblBackupTitle;
        private System.Windows.Forms.DataGridView dgvBackups;
        private System.Windows.Forms.Button btnBackupManual;
        private System.Windows.Forms.Button btnRestore;

        private System.Windows.Forms.Panel panelReports;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnExcel;

        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.Label lblLogTitle;
        private System.Windows.Forms.TextBox txtLog;
    }
}