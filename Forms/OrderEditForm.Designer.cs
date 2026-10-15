namespace BoardGame_Store
{
    partial class OrderEditForm
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
            this.lblRole = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.lblCompletion = new System.Windows.Forms.Label();
            this.dtpCompletion = new System.Windows.Forms.DateTimePicker();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.grpLegend = new System.Windows.Forms.GroupBox();
            this.pnlNew = new System.Windows.Forms.Panel();
            this.lblNew = new System.Windows.Forms.Label();
            this.pnlNotReady = new System.Windows.Forms.Panel();
            this.lblNotReady = new System.Windows.Forms.Label();
            this.pnlReady = new System.Windows.Forms.Panel();
            this.lblReady = new System.Windows.Forms.Label();
            this.pnlCanceled = new System.Windows.Forms.Panel();
            this.lblCanceled = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblGame = new System.Windows.Forms.Label();
            this.cmbGame = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.dgvContent = new System.Windows.Forms.DataGridView();
            this.panelCalc = new System.Windows.Forms.Panel();
            this.lblSumWithout = new System.Windows.Forms.Label();
            this.txtSumWithout = new System.Windows.Forms.TextBox();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.txtDiscountAmount = new System.Windows.Forms.TextBox();
            this.lblSumWith = new System.Windows.Forms.Label();
            this.txtSumWith = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.grpLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.panelCalc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(260, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(198, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Просмотр заказа";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRole.Location = new System.Drawing.Point(620, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(90, 19);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "[Роль] [ФИО]";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(20, 55);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(106, 19);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Номер клиента";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Location = new System.Drawing.Point(130, 52);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(200, 25);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 95);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(124, 19);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Дата оформления";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(150, 92);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 25);
            this.dtpDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(400, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(50, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Статус";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] {
            "Новый",
            "Не готов",
            "Готов",
            "Отменён"});
            this.cmbStatus.Location = new System.Drawing.Point(460, 52);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(400, 95);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(73, 19);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "Скидка, %";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(510, 92);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(80, 25);
            this.nudDiscount.TabIndex = 9;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            // 
            // lblCompletion
            // 
            this.lblCompletion.AutoSize = true;
            this.lblCompletion.Location = new System.Drawing.Point(20, 130);
            this.lblCompletion.Name = "lblCompletion";
            this.lblCompletion.Size = new System.Drawing.Size(121, 19);
            this.lblCompletion.TabIndex = 10;
            this.lblCompletion.Text = "Дата выполнения";
            // 
            // dtpCompletion
            // 
            this.dtpCompletion.Location = new System.Drawing.Point(150, 127);
            this.dtpCompletion.Name = "dtpCompletion";
            this.dtpCompletion.Size = new System.Drawing.Size(180, 25);
            this.dtpCompletion.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(400, 130);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(47, 19);
            this.lblAddress.TabIndex = 12;
            this.lblAddress.Text = "Адрес";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(460, 127);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(330, 25);
            this.txtAddress.TabIndex = 13;
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
            this.grpLegend.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpLegend.Location = new System.Drawing.Point(20, 160);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(300, 72);
            this.grpLegend.TabIndex = 14;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Легенда статусов";
            // 
            // pnlNew
            // 
            this.pnlNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(205)))));
            this.pnlNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNew.Location = new System.Drawing.Point(12, 25);
            this.pnlNew.Name = "pnlNew";
            this.pnlNew.Size = new System.Drawing.Size(15, 15);
            this.pnlNew.TabIndex = 0;
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNew.Location = new System.Drawing.Point(32, 25);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(43, 13);
            this.lblNew.TabIndex = 1;
            this.lblNew.Text = "Новый";
            // 
            // pnlNotReady
            // 
            this.pnlNotReady.BackColor = System.Drawing.Color.White;
            this.pnlNotReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNotReady.Location = new System.Drawing.Point(140, 25);
            this.pnlNotReady.Name = "pnlNotReady";
            this.pnlNotReady.Size = new System.Drawing.Size(15, 15);
            this.pnlNotReady.TabIndex = 2;
            // 
            // lblNotReady
            // 
            this.lblNotReady.AutoSize = true;
            this.lblNotReady.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblNotReady.Location = new System.Drawing.Point(160, 25);
            this.lblNotReady.Name = "lblNotReady";
            this.lblNotReady.Size = new System.Drawing.Size(54, 13);
            this.lblNotReady.TabIndex = 3;
            this.lblNotReady.Text = "Не готов";
            // 
            // pnlReady
            // 
            this.pnlReady.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(237)))), ((int)(((byte)(218)))));
            this.pnlReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReady.Location = new System.Drawing.Point(12, 48);
            this.pnlReady.Name = "pnlReady";
            this.pnlReady.Size = new System.Drawing.Size(15, 15);
            this.pnlReady.TabIndex = 4;
            // 
            // lblReady
            // 
            this.lblReady.AutoSize = true;
            this.lblReady.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblReady.Location = new System.Drawing.Point(32, 48);
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(37, 13);
            this.lblReady.TabIndex = 5;
            this.lblReady.Text = "Готов";
            // 
            // pnlCanceled
            // 
            this.pnlCanceled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(215)))), ((int)(((byte)(218)))));
            this.pnlCanceled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanceled.Location = new System.Drawing.Point(140, 48);
            this.pnlCanceled.Name = "pnlCanceled";
            this.pnlCanceled.Size = new System.Drawing.Size(15, 15);
            this.pnlCanceled.TabIndex = 6;
            // 
            // lblCanceled
            // 
            this.lblCanceled.AutoSize = true;
            this.lblCanceled.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCanceled.Location = new System.Drawing.Point(160, 48);
            this.lblCanceled.Name = "lblCanceled";
            this.lblCanceled.Size = new System.Drawing.Size(55, 13);
            this.lblCanceled.TabIndex = 7;
            this.lblCanceled.Text = "Отменён";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 245);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(151, 19);
            this.lblCount.TabIndex = 15;
            this.lblCount.Text = "Количество записей: 0";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(20, 275);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(46, 19);
            this.lblGame.TabIndex = 16;
            this.lblGame.Text = "Товар";
            // 
            // cmbGame
            // 
            this.cmbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGame.Location = new System.Drawing.Point(80, 272);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(200, 25);
            this.cmbGame.TabIndex = 17;
            this.cmbGame.SelectedIndexChanged += new System.EventHandler(this.cmbGame_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(300, 275);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 19);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "Кол-во";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(360, 272);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(60, 25);
            this.nudQuantity.TabIndex = 19;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(440, 275);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 19);
            this.lblPrice.TabIndex = 20;
            this.lblPrice.Text = "Цена";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(490, 272);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(80, 25);
            this.txtPrice.TabIndex = 21;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(20, 310);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(140, 35);
            this.btnAddItem.TabIndex = 22;
            this.btnAddItem.Text = "Добавить товар";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.Location = new System.Drawing.Point(170, 310);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(140, 35);
            this.btnDeleteItem.TabIndex = 23;
            this.btnDeleteItem.Text = "Удалить товар";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(20, 355);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContent.Size = new System.Drawing.Size(550, 233);
            this.dgvContent.TabIndex = 24;
            // 
            // panelCalc
            // 
            this.panelCalc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCalc.Controls.Add(this.lblSumWithout);
            this.panelCalc.Controls.Add(this.txtSumWithout);
            this.panelCalc.Controls.Add(this.lblDiscountAmount);
            this.panelCalc.Controls.Add(this.txtDiscountAmount);
            this.panelCalc.Controls.Add(this.lblSumWith);
            this.panelCalc.Controls.Add(this.txtSumWith);
            this.panelCalc.Controls.Add(this.lblTotal);
            this.panelCalc.Controls.Add(this.txtTotal);
            this.panelCalc.Location = new System.Drawing.Point(580, 355);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Size = new System.Drawing.Size(230, 233);
            this.panelCalc.TabIndex = 25;
            // 
            // lblSumWithout
            // 
            this.lblSumWithout.AutoSize = true;
            this.lblSumWithout.Location = new System.Drawing.Point(10, 15);
            this.lblSumWithout.Name = "lblSumWithout";
            this.lblSumWithout.Size = new System.Drawing.Size(78, 19);
            this.lblSumWithout.TabIndex = 0;
            this.lblSumWithout.Text = "Без скидки";
            // 
            // txtSumWithout
            // 
            this.txtSumWithout.Location = new System.Drawing.Point(10, 38);
            this.txtSumWithout.Name = "txtSumWithout";
            this.txtSumWithout.ReadOnly = true;
            this.txtSumWithout.Size = new System.Drawing.Size(210, 25);
            this.txtSumWithout.TabIndex = 1;
            // 
            // lblDiscountAmount
            // 
            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(10, 65);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(88, 19);
            this.lblDiscountAmount.TabIndex = 2;
            this.lblDiscountAmount.Text = "Скидка, руб.";
            // 
            // txtDiscountAmount
            // 
            this.txtDiscountAmount.Location = new System.Drawing.Point(10, 88);
            this.txtDiscountAmount.Name = "txtDiscountAmount";
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(210, 25);
            this.txtDiscountAmount.TabIndex = 3;
            // 
            // lblSumWith
            // 
            this.lblSumWith.AutoSize = true;
            this.lblSumWith.Location = new System.Drawing.Point(10, 115);
            this.lblSumWith.Name = "lblSumWith";
            this.lblSumWith.Size = new System.Drawing.Size(82, 19);
            this.lblSumWith.TabIndex = 4;
            this.lblSumWith.Text = "Со скидкой";
            // 
            // txtSumWith
            // 
            this.txtSumWith.Location = new System.Drawing.Point(10, 137);
            this.txtSumWith.Name = "txtSumWith";
            this.txtSumWith.ReadOnly = true;
            this.txtSumWith.Size = new System.Drawing.Size(210, 25);
            this.txtSumWith.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(10, 173);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 19);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Итого";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(10, 195);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(210, 25);
            this.txtTotal.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 40);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Изменить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(180, 594);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(180, 40);
            this.btnPrint.TabIndex = 27;
            this.btnPrint.Text = "Распечатать чек";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(630, 603);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(170, 40);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // OrderEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 646);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panelCalc);
            this.Controls.Add(this.dgvContent);
            this.Controls.Add(this.btnDeleteItem);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.cmbGame);
            this.Controls.Add(this.lblGame);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.grpLegend);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.dtpCompletion);
            this.Controls.Add(this.lblCompletion);
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Просмотр заказа";
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.grpLegend.ResumeLayout(false);
            this.grpLegend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.panelCalc.ResumeLayout(false);
            this.panelCalc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
        private System.Windows.Forms.Label lblCompletion;
        private System.Windows.Forms.DateTimePicker dtpCompletion;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox grpLegend;
        private System.Windows.Forms.Panel pnlNew;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Panel pnlNotReady;
        private System.Windows.Forms.Label lblNotReady;
        private System.Windows.Forms.Panel pnlReady;
        private System.Windows.Forms.Label lblReady;
        private System.Windows.Forms.Panel pnlCanceled;
        private System.Windows.Forms.Label lblCanceled;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblGame;
        private System.Windows.Forms.ComboBox cmbGame;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.DataGridView dgvContent;
        private System.Windows.Forms.Panel panelCalc;
        private System.Windows.Forms.Label lblSumWithout;
        private System.Windows.Forms.TextBox txtSumWithout;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.TextBox txtDiscountAmount;
        private System.Windows.Forms.Label lblSumWith;
        private System.Windows.Forms.TextBox txtSumWith;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnBack;
    }
}