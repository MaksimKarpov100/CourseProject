namespace BoardGame_Store
{
    partial class OrderAddForm
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
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).BeginInit();
            this.panelCalc.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(152, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Новый заказ";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(20, 60);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(106, 19);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Номер клиента";
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.Location = new System.Drawing.Point(130, 57);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(200, 25);
            this.cmbCustomer.TabIndex = 3;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(360, 60);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(124, 19);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Дата оформления";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(490, 57);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(180, 25);
            this.dtpDate.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 100);
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
            this.cmbStatus.Location = new System.Drawing.Point(130, 97);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbStatus.TabIndex = 7;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(320, 100);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(73, 19);
            this.lblDiscount.TabIndex = 8;
            this.lblDiscount.Text = "Скидка, %";
            // 
            // nudDiscount
            // 
            this.nudDiscount.Location = new System.Drawing.Point(430, 97);
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(80, 25);
            this.nudDiscount.TabIndex = 9;
            this.nudDiscount.ValueChanged += new System.EventHandler(this.nudDiscount_ValueChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(20, 135);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(151, 19);
            this.lblCount.TabIndex = 10;
            this.lblCount.Text = "Количество записей: 0";
            // 
            // lblGame
            // 
            this.lblGame.AutoSize = true;
            this.lblGame.Location = new System.Drawing.Point(20, 165);
            this.lblGame.Name = "lblGame";
            this.lblGame.Size = new System.Drawing.Size(46, 19);
            this.lblGame.TabIndex = 11;
            this.lblGame.Text = "Товар";
            // 
            // cmbGame
            // 
            this.cmbGame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGame.Location = new System.Drawing.Point(80, 162);
            this.cmbGame.Name = "cmbGame";
            this.cmbGame.Size = new System.Drawing.Size(200, 25);
            this.cmbGame.TabIndex = 12;
            this.cmbGame.SelectedIndexChanged += new System.EventHandler(this.cmbGame_SelectedIndexChanged);
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(300, 165);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(53, 19);
            this.lblQuantity.TabIndex = 13;
            this.lblQuantity.Text = "Кол-во";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(360, 162);
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(60, 25);
            this.nudQuantity.TabIndex = 14;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(440, 165);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(41, 19);
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Цена";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(490, 162);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(80, 25);
            this.txtPrice.TabIndex = 16;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(20, 200);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(140, 35);
            this.btnAddItem.TabIndex = 17;
            this.btnAddItem.Text = "Добавить товар";
            this.btnAddItem.UseVisualStyleBackColor = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteItem.ForeColor = System.Drawing.Color.White;
            this.btnDeleteItem.Location = new System.Drawing.Point(170, 200);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(140, 35);
            this.btnDeleteItem.TabIndex = 18;
            this.btnDeleteItem.Text = "Удалить товар";
            this.btnDeleteItem.UseVisualStyleBackColor = false;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // dgvContent
            // 
            this.dgvContent.AllowUserToAddRows = false;
            this.dgvContent.AllowUserToDeleteRows = false;
            this.dgvContent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContent.BackgroundColor = System.Drawing.Color.White;
            this.dgvContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvContent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContent.Location = new System.Drawing.Point(20, 245);
            this.dgvContent.Name = "dgvContent";
            this.dgvContent.ReadOnly = true;
            this.dgvContent.RowHeadersVisible = false;
            this.dgvContent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContent.Size = new System.Drawing.Size(626, 418);
            this.dgvContent.TabIndex = 19;
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
            this.panelCalc.Location = new System.Drawing.Point(652, 245);
            this.panelCalc.Name = "panelCalc";
            this.panelCalc.Size = new System.Drawing.Size(230, 418);
            this.panelCalc.TabIndex = 20;
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
            this.txtSumWith.Location = new System.Drawing.Point(10, 138);
            this.txtSumWith.Name = "txtSumWith";
            this.txtSumWith.ReadOnly = true;
            this.txtSumWith.Size = new System.Drawing.Size(210, 25);
            this.txtSumWith.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(3, 357);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(50, 19);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Итого";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(3, 390);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(210, 25);
            this.txtTotal.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(20, 669);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Добавить заказ";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // OrderAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 721);
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
            this.Controls.Add(this.nudDiscount);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новый заказ";
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContent)).EndInit();
            this.panelCalc.ResumeLayout(false);
            this.panelCalc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown nudDiscount;
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
    }
}