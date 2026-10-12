namespace BoardGame_Store
{
    partial class OrdersListForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.pnlNew = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.pnlNotReady = new System.Windows.Forms.Panel();
            this.lblNotReady = new System.Windows.Forms.Label();
            this.pnlReady = new System.Windows.Forms.Panel();
            this.lblReady = new System.Windows.Forms.Label();
            this.pnlCanceled = new System.Windows.Forms.Panel();
            this.lblCanceled = new System.Windows.Forms.Label();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.lblComposition = new System.Windows.Forms.Label();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.panelCalc = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblSumWithout = new System.Windows.Forms.Label();
            this.txtSumWithout = new System.Windows.Forms.TextBox();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.lblSumWith = new System.Windows.Forms.Label();
            this.txtSumWith = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpLegend.SuspendLayout();
            this.panelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.panelCalc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Учёт заказов";
            // 
            // panelFilters
            // 
            this.panelFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilters.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelFilters.Controls.Add(this.lblOrderNumber);
            this.panelFilters.Controls.Add(this.txtOrderNumber);
            this.panelFilters.Controls.Add(this.lblDateFrom);
            this.panelFilters.Controls.Add(this.dtpDateFrom);
            this.panelFilters.Controls.Add(this.lblDateTo);
            this.panelFilters.Controls.Add(this.dtpDateTo);
            this.panelFilters.Controls.Add(this.lblStatus);
            this.panelFilters.Controls.Add(this.cmbStatus);
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Controls.Add(this.btnReset);
            this.panelFilters.Location = new System.Drawing.Point(20, 55);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(960, 75);
            this.panelFilters.TabIndex = 1;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(10, 12);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(104, 17);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Номер заказа:";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(120, 9);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(100, 23);
            this.txtOrderNumber.TabIndex = 1;
            this.txtOrderNumber.Text = "Поиск...";
            this.txtOrderNumber.TextChanged += new System.EventHandler(this.txtOrderNumber_TextChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(240, 12);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(21, 17);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "С:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(270, 9);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpDateFrom.TabIndex = 3;
            this.dtpDateFrom.ValueChanged += new System.EventHandler(this.dtpDateFrom_ValueChanged);
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(400, 12);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(30, 17);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "По:";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(435, 9);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(120, 23);
            this.dtpDateTo.TabIndex = 5;
            this.dtpDateTo.ValueChanged += new System.EventHandler(this.dtpDateTo_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(57, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Статус:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Все",
            "Новый",
            "Не готов",
            "Готов",
            "Отменён"});
            this.cmbStatus.Location = new System.Drawing.Point(120, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 24);
            this.cmbStatus.TabIndex = 7;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStatus_SelectedIndexChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(280, 45);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(117, 17);
            this.lblSort.TabIndex = 8;
            this.lblSort.Text = "Сортировать по:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] {
            "По номеру",
            "По дате",
            "По статусу",
            "По сумме"});
            this.cmbSort.Location = new System.Drawing.Point(400, 42);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(160, 24);
            this.cmbSort.TabIndex = 9;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(860, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 50);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Сброс";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(20, 140);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.RowTemplate.Height = 32;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(960, 175);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrders_CellDoubleClick);
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 325);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(160, 17);
            this.lblCount.TabIndex = 8;
            this.lblCount.Text = "Количество записей: 0";
            // 
            // grpLegend
            // 
            this.grpLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLegend.Controls.Add(this.pnlNew);
            this.grpLegend.Controls.Add(this.lblNew);
            this.grpLegend.Controls.Add(this.pnlNotReady);
            this.grpLegend.Controls.Add(this.lblNotReady);
            this.grpLegend.Controls.Add(this.pnlReady);
            this.grpLegend.Controls.Add(this.lblReady);
            this.grpLegend.Controls.Add(this.pnlCanceled);
            this.grpLegend.Controls.Add(this.lblCanceled);
            this.grpLegend.Location = new System.Drawing.Point(645, 320);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(335, 70);
            this.grpLegend.TabIndex = 7;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Легенда статусов";
            // 
            // pnlNew
            // 
            this.pnlNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNew.Location = new System.Drawing.Point(10, 22);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(15, 15);
            this.pnlNew.TabIndex = 0;
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(30, 22);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(51, 17);
            this.lblNew.TabIndex = 1;
            this.lblNew.Text = "Новый";
            // 
            // pnlNotReady
            // 
            this.pnlNotReady.BackColor = System.Drawing.Color.White;
            this.pnlNotReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNotReady.Location = new System.Drawing.Point(120, 22);
            this.pnlNotReady.Name = "pnlNotReady";
            this.pnlNotReady.Size = new System.Drawing.Size(15, 15);
            this.pnlNotReady.TabIndex = 2;
            // 
            // lblNotReady
            // 
            this.lblNotReady.AutoSize = true;
            this.lblNotReady.Location = new System.Drawing.Point(140, 22);
            this.lblNotReady.Name = "lblNotReady";
            this.lblNotReady.Size = new System.Drawing.Size(65, 17);
            this.lblNotReady.TabIndex = 3;
            this.lblNotReady.Text = "Не готов";
            // 
            // pnlReady
            // 
            this.pnlReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.pnlReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReady.Location = new System.Drawing.Point(10, 42);
            this.pnlReady.Name = "pnlReady";
            this.pnlReady.Size = new System.Drawing.Size(15, 15);
            this.pnlReady.TabIndex = 4;
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.Location = new System.Drawing.Point(30, 42);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(46, 17);
            this.lblReady.TabIndex = 5;
            this.lblReady.Text = "Готов";
            // 
            // pnlCanceled
            // 
            this.pnlCanceled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.pnlCanceled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanceled.Location = new System.Drawing.Point(120, 42);
            this.pnlCanceled.Name = "pnlCanceled";
            this.pnlCanceled.Size = new System.Drawing.Size(15, 15);
            this.pnlCanceled.TabIndex = 6;
            // 
            // lblCanceled
            // 
            this.lblCanceled.AutoSize = true;
            this.lblCanceled.Location = new System.Drawing.Point(140, 42);
            this.lblCanceled.Name = "lblCanceled";
            this.lblCanceled.Size = new System.Drawing.Size(67, 17);
            this.lblCanceled.TabIndex = 7;
            this.lblCanceled.Text = "Отменён";
            // 
            // panelPagination
            // 
            this.panelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cmbPageSize);
            this.panelPagination.Location = new System.Drawing.Point(20, 400);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(960, 40);
            this.panelPagination.TabIndex = 3;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(250, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(310, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(380, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(115, 17);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(519, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(579, 7);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(649, 14);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(68, 17);
            this.lblPageSize.TabIndex = 5;
            this.lblPageSize.Text = "Записей:";
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this.cmbPageSize.Location = new System.Drawing.Point(719, 10);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);
            this.cmbPageSize.TabIndex = 6;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            // 
            // lblComposition
            // 
            this.lblComposition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblComposition.AutoSize = true;
            this.lblComposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblComposition.Location = new System.Drawing.Point(20, 450);
            this.lblComposition.Name = "lblComposition";
            this.lblComposition.Size = new System.Drawing.Size(124, 18);
            this.lblComposition.TabIndex = 6;
            this.lblComposition.Text = "Состав заказа";
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvContent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(20, 475);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.RowTemplate.Height = 30;
            this.dgvContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContent.Size = new System.Drawing.Size(600, 175);
            this.dgvContent.TabIndex = 4;
            // 
            // panelCalc
            // 
            this.panelCalc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCalc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCalc.Controls.Add(this.lblDiscount);
            this.panelCalc.Controls.Add(this.nudDiscount);
            this.panelCalc.Controls.Add(this.lblSumWithout);
            this.panelCalc.Controls.Add(this.txtSumWithout);
            this.panelCalc.Controls.Add(this.lblDiscountAmount);
            this.panelCalc.Controls.Add(this.txtDiscountAmount);
            this.panelCalc.Controls.Add(this.lblSumWith);
            this.panelCalc.Controls.Add(this.txtSumWith);
            this.panelCalc.Controls.Add(this.lblTotal);
            this.panelCalc.Controls.Add(this.txtTotal);
            this.panelCalc.Location = new System.Drawing.Point(635, 475);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Size = new System.Drawing.Size(345, 175);
            this.panelCalc.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(15, 15);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(85, 17);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "Скидка (%):";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudDiscount.Location = new System.Drawing.Point(200, 13);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(130, 23);
            this.nudDiscount.TabIndex = 1;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            // 
            // lblSumWithout
            // 
            this.lblSumWithout.AutoSize = true;
            this.lblSumWithout.Location = new System.Drawing.Point(15, 45);
            this.lblSumWithout.Name = "lblSumWithout";
            this.lblSumWithout.Size = new System.Drawing.Size(85, 17);
            this.lblSumWithout.TabIndex = 2;
            this.lblSumWithout.Text = "Без скидки:";
            // 
            // txtSumWithout
            // 
            this.txtSumWithout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSumWithout.Location = new System.Drawing.Point(200, 42);
            this.txtSumWithout.Name = "txtSumWithout";
            this.txtSumWithout.ReadOnly = true;
            this.txtSumWithout.Size = new System.Drawing.Size(130, 23);
            this.txtSumWithout.TabIndex = 3;
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(15, 75);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(90, 17);
            this.lblDiscountAmount.TabIndex = 4;
            this.lblDiscountAmount.Text = "Скидка руб.:";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountAmount.Location = new System.Drawing.Point(200, 72);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(130, 23);
            this.txtDiscountAmount.TabIndex = 5;
            // 
            // lblSumWith
            // 
            this.lblSumWith.AutoSize = true;
            this.lblSumWith.Location = new System.Drawing.Point(15, 105);
            this.lblSumWith.Name = "lblSumWith";
            this.lblSumWith.Size = new System.Drawing.Size(86, 17);
            this.lblSumWith.TabIndex = 6;
            this.lblSumWith.Text = "Со скидкой:";
            // 
            // txtSumWith
            // 
            this.txtSumWith.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSumWith.Location = new System.Drawing.Point(200, 102);
            this.txtSumWith.Name = "txtSumWith";
            this.txtSumWith.ReadOnly = true;
            this.txtSumWith.Size = new System.Drawing.Size(130, 23);
            this.txtSumWith.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(15, 135);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 17);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Итого:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Location = new System.Drawing.Point(200, 132);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(130, 23);
            this.txtTotal.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(20, 660);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 40);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить заказ";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(190, 660);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 40);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить запись";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReport.Location = new System.Drawing.Point(360, 660);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(180, 40);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Сформировать отчёт";
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(820, 660);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OrdersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 720);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelCalc);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.lblComposition);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.grpLegend);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MinimumSize = new System.Drawing.Size(1000, 720);
            this.Name = "OrdersListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт заказов";
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.grpLegend.ResumeLayout(false);
            this.grpLegend.PerformLayout();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.panelCalc.ResumeLayout(false);
            this.panelCalc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.Panel pnlNew;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Panel pnlNotReady;
        private System.Windows.Forms.Label lblNotReady;
        private System.Windows.Forms.Panel pnlReady;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel pnlCanceled;
        private System.Windows.Forms.Label lblCanceled;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Label lblComposition;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.Panel panelCalc;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lblSumWithout;
        private System.Windows.Forms.TextBox txtSumWithout;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label lblSumWith;
        private System.Windows.Forms.TextBox txtSumWith;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnBack;
    }
}