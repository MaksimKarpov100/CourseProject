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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.grpLegend.SuspendLayout();
            this.panelPagination.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.panelCalc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 26);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Учёт заказов";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(94, 17);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "[Роль] [ФИО]";
            // 
            // panelFilters
            // 
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
            this.panelFilters.Location = new System.Drawing.Point(15, 45);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(790, 75);
            this.panelFilters.TabIndex = 8;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(10, 10);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(100, 17);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "Номер заказа";
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(110, 7);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(90, 23);
            this.txtOrderNumber.TabIndex = 1;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(220, 10);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(76, 17);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "Выбрать с";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(300, 7);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(110, 23);
            this.dtpDateFrom.TabIndex = 3;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(420, 10);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(24, 17);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "по";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(450, 7);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(110, 23);
            this.dtpDateTo.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 45);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 17);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Статус заказа";
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
            this.cmbStatus.Location = new System.Drawing.Point(110, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(130, 24);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(260, 45);
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
            this.cmbSort.Location = new System.Drawing.Point(380, 42);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(150, 24);
            this.cmbSort.TabIndex = 9;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(700, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(80, 60);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(15, 130);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowHeadersVisible = false;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(790, 170);
            this.dgvOrders.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 305);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(203, 17);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Количество записей: [кол-во]";
            // 
            // grpLegend
            // 
            this.grpLegend.Controls.Add(this.pnlNew);
            this.grpLegend.Controls.Add(this.lblNew);
            this.grpLegend.Controls.Add(this.pnlNotReady);
            this.grpLegend.Controls.Add(this.lblNotReady);
            this.grpLegend.Controls.Add(this.pnlReady);
            this.grpLegend.Controls.Add(this.lblReady);
            this.grpLegend.Controls.Add(this.pnlCanceled);
            this.grpLegend.Controls.Add(this.lblCanceled);
            this.grpLegend.Location = new System.Drawing.Point(560, 306);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(245, 65);
            this.grpLegend.TabIndex = 5;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Легенда статусов";
            // 
            // pnlNew
            // 
            this.pnlNew.BackColor = System.Drawing.Color.LightYellow;
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
            this.pnlReady.BackColor = System.Drawing.Color.LightGreen;
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
            this.pnlCanceled.BackColor = System.Drawing.Color.LightCoral;
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
            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cmbPageSize);
            this.panelPagination.Location = new System.Drawing.Point(18, 325);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(530, 40);
            this.panelPagination.TabIndex = 4;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(0, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(60, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(130, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(115, 17);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(250, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(310, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(400, 12);
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
            this.cmbPageSize.Location = new System.Drawing.Point(470, 8);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);
            this.cmbPageSize.TabIndex = 6;
            // 
            // lblComposition
            // 
            this.lblComposition.AutoSize = true;
            this.lblComposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblComposition.Location = new System.Drawing.Point(15, 368);
            this.lblComposition.Name = "lblComposition";
            this.lblComposition.Size = new System.Drawing.Size(124, 18);
            this.lblComposition.TabIndex = 3;
            this.lblComposition.Text = "Состав заказа";
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(15, 390);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContent.Size = new System.Drawing.Size(530, 201);
            this.dgvContent.TabIndex = 2;
            // 
            // panelCalc
            // 
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
            this.panelCalc.Location = new System.Drawing.Point(560, 390);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Size = new System.Drawing.Size(245, 201);
            this.panelCalc.TabIndex = 1;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(10, 8);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(96, 17);
            this.lblDiscount.TabIndex = 0;
            this.lblDiscount.Text = "Скидка - [ ] %";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(130, 6);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(99, 23);
            this.nudDiscount.TabIndex = 1;
            // 
            // lblSumWithout
            // 
            this.lblSumWithout.AutoSize = true;
            this.lblSumWithout.Location = new System.Drawing.Point(11, 38);
            this.lblSumWithout.Name = "lblSumWithout";
            this.lblSumWithout.Size = new System.Drawing.Size(90, 17);
            this.lblSumWithout.TabIndex = 2;
            this.lblSumWithout.Text = "Без скидки -";
            // 
            // txtSumWithout
            // 
            this.txtSumWithout.Location = new System.Drawing.Point(129, 38);
            this.txtSumWithout.Name = "txtSumWithout";
            this.txtSumWithout.ReadOnly = true;
            this.txtSumWithout.Size = new System.Drawing.Size(100, 23);
            this.txtSumWithout.TabIndex = 3;
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(10, 70);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(64, 17);
            this.lblDiscountAmount.TabIndex = 4;
            this.lblDiscountAmount.Text = "Скидка -";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(129, 67);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(100, 23);
            this.txtDiscountAmount.TabIndex = 5;
            // 
            // lblSumWith
            // 
            this.lblSumWith.AutoSize = true;
            this.lblSumWith.Location = new System.Drawing.Point(11, 102);
            this.lblSumWith.Name = "lblSumWith";
            this.lblSumWith.Size = new System.Drawing.Size(91, 17);
            this.lblSumWith.TabIndex = 6;
            this.lblSumWith.Text = "Со скидкой -";
            // 
            // txtSumWith
            // 
            this.txtSumWith.Location = new System.Drawing.Point(129, 96);
            this.txtSumWith.Name = "txtSumWith";
            this.txtSumWith.ReadOnly = true;
            this.txtSumWith.Size = new System.Drawing.Size(100, 23);
            this.txtSumWith.TabIndex = 7;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(14, 138);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(62, 17);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "Итого -";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(129, 132);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(100, 23);
            this.txtTotal.TabIndex = 9;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnReport);
            this.panelButtons.Controls.Add(this.lblHint);
            this.panelButtons.Controls.Add(this.btnBack);
            this.panelButtons.Location = new System.Drawing.Point(15, 597);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(790, 59);
            this.panelButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(4, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(140, 50);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить заказ";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(150, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 51);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить запись";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(300, 5);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(160, 51);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Сформировать чек в Word 2016";
            this.btnReport.UseVisualStyleBackColor = true;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(480, 15);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(160, 34);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "Для удаления дважды \r\nщёлкните по строке";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(680, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 51);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // OrdersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 668);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelCalc);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.lblComposition);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.grpLegend);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
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
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnBack;
    }
}