namespace BoardGame_Store
{
    partial class OrderEditForm
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblCompletion = new System.Windows.Forms.Label();
            this.dtpCompletion = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
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
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.grpLegend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.panelCalc.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(203, 26);
            this.lblTitle.Text = "Просмотр заказа";

            // lblRole
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(650, 22);
            this.lblRole.Size = new System.Drawing.Size(94, 17);
            this.lblRole.Text = "[Роль] [ФИО]";

            // lblCustomer
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(20, 60);
            this.lblCustomer.Size = new System.Drawing.Size(56, 17);
            this.lblCustomer.Text = "Клиент";

            // cmbCustomer
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Location = new System.Drawing.Point(130, 57);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(220, 24);

            // lblDate
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(380, 60);
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.Text = "Дата";

            // dtpDate
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(440, 57);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 23);

            // lblCompletion
            this.lblCompletion.AutoSize = true;
            this.lblCompletion.Location = new System.Drawing.Point(380, 100);
            this.lblCompletion.Size = new System.Drawing.Size(91, 17);
            this.lblCompletion.Text = "Дата выпол.";

            // dtpCompletion
            this.dtpCompletion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCompletion.Location = new System.Drawing.Point(480, 97);
            this.dtpCompletion.Name = "dtpCompletion";
            this.dtpCompletion.Size = new System.Drawing.Size(180, 23);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
            this.lblStatus.Size = new System.Drawing.Size(53, 17);
            this.lblStatus.Text = "Статус";

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(130, 97);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 24);

            // lblDiscount
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(20, 135);
            this.lblDiscount.Size = new System.Drawing.Size(96, 17);
            this.lblDiscount.Text = "Скидка - [ ] %";

            // nudDiscount
            this.nudDiscount.Location = new System.Drawing.Point(130, 132);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(80, 23);
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(380, 135);
            this.lblAddress.Size = new System.Drawing.Size(112, 17);
            this.lblAddress.Text = "Адрес доставки";

            // txtAddress
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(500, 132);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(280, 23);

            // grpLegend
            this.grpLegend.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLegend.Controls.Add(this.pnlNew);
            this.grpLegend.Controls.Add(this.lblNew);
            this.grpLegend.Controls.Add(this.pnlNotReady);
            this.grpLegend.Controls.Add(this.lblNotReady);
            this.grpLegend.Controls.Add(this.pnlReady);
            this.grpLegend.Controls.Add(this.lblReady);
            this.grpLegend.Controls.Add(this.pnlCanceled);
            this.grpLegend.Controls.Add(this.lblCanceled);
            this.grpLegend.Location = new System.Drawing.Point(20, 170);
            this.grpLegend.Name = "grpLegend";
            this.grpLegend.Size = new System.Drawing.Size(760, 55);
            this.grpLegend.TabIndex = 13;
            this.grpLegend.TabStop = false;
            this.grpLegend.Text = "Легенда статусов";

            this.pnlNew.BackColor = System.Drawing.Color.LightYellow;
            this.pnlNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNew.Location = new System.Drawing.Point(10, 22);
            this.pnlNew.Size = new System.Drawing.Size(15, 15);

            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(30, 22);
            this.lblNew.Size = new System.Drawing.Size(51, 17);
            this.lblNew.Text = "Новый";

            this.pnlNotReady.BackColor = System.Drawing.Color.White;
            this.pnlNotReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNotReady.Location = new System.Drawing.Point(120, 22);
            this.pnlNotReady.Size = new System.Drawing.Size(15, 15);

            this.lblNotReady.AutoSize = true;
            this.lblNotReady.Location = new System.Drawing.Point(140, 22);
            this.lblNotReady.Size = new System.Drawing.Size(65, 17);
            this.lblNotReady.Text = "Не готов";

            this.pnlReady.BackColor = System.Drawing.Color.LightGreen;
            this.pnlReady.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReady.Location = new System.Drawing.Point(250, 22);
            this.pnlReady.Size = new System.Drawing.Size(15, 15);

            this.lblReady.AutoSize = true;
            this.lblReady.Location = new System.Drawing.Point(270, 22);
            this.lblReady.Size = new System.Drawing.Size(46, 17);
            this.lblReady.Text = "Готов";

            this.pnlCanceled.BackColor = System.Drawing.Color.LightCoral;
            this.pnlCanceled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCanceled.Location = new System.Drawing.Point(370, 22);
            this.pnlCanceled.Size = new System.Drawing.Size(15, 15);

            this.lblCanceled.AutoSize = true;
            this.lblCanceled.Location = new System.Drawing.Point(390, 22);
            this.lblCanceled.Size = new System.Drawing.Size(67, 17);
            this.lblCanceled.Text = "Отменён";

            // lblCount
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 240);
            this.lblCount.Size = new System.Drawing.Size(160, 17);
            this.lblCount.Text = "Количество записей: 0";

            // lblGame
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(20, 270);
            this.lblGame.Size = new System.Drawing.Size(48, 17);
            this.lblGame.Text = "Товар";

            // cmbGame
            this.cmbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGame.Location = new System.Drawing.Point(80, 267);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(250, 24);
            this.cmbGame.SelectedIndexChanged += new System.EventHandler(this.cmbGame_SelectedIndexChanged);

            // lblQuantity
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(350, 270);
            this.lblQuantity.Size = new System.Drawing.Size(53, 17);
            this.lblQuantity.Text = "Кол-во";

            // nudQuantity
            this.nudQuantity.Location = new System.Drawing.Point(410, 267);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(60, 23);

            // lblPrice
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(490, 270);
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.Text = "Цена";

            // txtPrice
            this.txtPrice.Location = new System.Drawing.Point(540, 267);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(80, 23);

            // btnAddItem
            this.btnAddItem.Location = new System.Drawing.Point(20, 305);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(140, 35);
            this.btnAddItem.Text = "Добавить товар";
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);

            // btnDeleteItem
            this.btnDeleteItem.Location = new System.Drawing.Point(170, 305);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(140, 35);
            this.btnDeleteItem.Text = "Удалить товар";
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);

            // dgvContent
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(20, 350);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.RowTemplate.Height = 30;
            this.dgvContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContent.Size = new System.Drawing.Size(590, 220);
            this.dgvContent.TabIndex = 3;
            this.dgvContent.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // panelCalc
            this.panelCalc.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCalc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCalc.Controls.Add(this.lblSumWithout);
            this.panelCalc.Controls.Add(this.txtSumWithout);
            this.panelCalc.Controls.Add(this.lblDiscountAmount);
            this.panelCalc.Controls.Add(this.txtDiscountAmount);
            this.panelCalc.Controls.Add(this.lblSumWith);
            this.panelCalc.Controls.Add(this.txtSumWith);
            this.panelCalc.Controls.Add(this.lblTotal);
            this.panelCalc.Controls.Add(this.txtTotal);
            this.panelCalc.Location = new System.Drawing.Point(625, 350);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Size = new System.Drawing.Size(190, 220);
            this.panelCalc.TabIndex = 2;

            this.lblSumWithout.AutoSize = true;
            this.lblSumWithout.Location = new System.Drawing.Point(10, 15);
            this.lblSumWithout.Size = new System.Drawing.Size(90, 17);
            this.lblSumWithout.Text = "Без скидки -";

            this.txtSumWithout.Location = new System.Drawing.Point(10, 38);
            this.txtSumWithout.ReadOnly = true;
            this.txtSumWithout.Size = new System.Drawing.Size(170, 23);

            this.lblDiscountAmount.AutoSize = true;
            this.lblDiscountAmount.Location = new System.Drawing.Point(10, 70);
            this.lblDiscountAmount.Size = new System.Drawing.Size(64, 17);
            this.lblDiscountAmount.Text = "Скидка -";

            this.txtDiscountAmount.Location = new System.Drawing.Point(10, 93);
            this.txtDiscountAmount.ReadOnly = true;
            this.txtDiscountAmount.Size = new System.Drawing.Size(170, 23);

            this.lblSumWith.AutoSize = true;
            this.lblSumWith.Location = new System.Drawing.Point(10, 125);
            this.lblSumWith.Size = new System.Drawing.Size(91, 17);
            this.lblSumWith.Text = "Со скидкой -";

            this.txtSumWith.Location = new System.Drawing.Point(10, 148);
            this.txtSumWith.ReadOnly = true;
            this.txtSumWith.Size = new System.Drawing.Size(170, 23);

            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(10, 180);
            this.lblTotal.Size = new System.Drawing.Size(51, 17);
            this.lblTotal.Text = "Итого";

            this.txtTotal.Location = new System.Drawing.Point(10, 197);
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(170, 23);

            // btnSave
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(20, 580);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.Text = "Сохранить";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnBack
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(635, 580);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 40);
            this.btnBack.Text = "В меню";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // OrderEditForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 640);
            this.Controls.Add(this.btnBack);
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
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpCompletion);
            this.Controls.Add(this.lblCompletion);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(840, 640);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "OrderEditForm";
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
        private System.Windows.Forms.Label lblCompletion;
        private System.Windows.Forms.DateTimePicker dtpCompletion;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
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
        private System.Windows.Forms.Button btnBack;
    }
}