namespace BoardGame_Store
{
    partial class MainFormSeller
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
            this.btnViewGames = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(342, 26);
            this.lblTitle.Text = "Board Game Store - Продавец";

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(32, 55);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(113, 17);
            this.lblRole.Text = "Роль: Продавец";

            // btnViewGames
            this.btnViewGames.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnViewGames.Location = new System.Drawing.Point(30, 100);
            this.btnViewGames.Name = "btnViewGames";
            this.btnViewGames.Size = new System.Drawing.Size(290, 55);
            this.btnViewGames.TabIndex = 0;
            this.btnViewGames.Text = "Просмотр товаров";
            this.btnViewGames.Click += new System.EventHandler(this.btnViewGames_Click);

            // btnNewOrder
            this.btnNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnNewOrder.Location = new System.Drawing.Point(340, 100);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.Size = new System.Drawing.Size(290, 55);
            this.btnNewOrder.TabIndex = 1;
            this.btnNewOrder.Text = "Новый заказ";
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);

            // btnCustomers
            this.btnCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCustomers.Location = new System.Drawing.Point(30, 165);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(290, 55);
            this.btnCustomers.TabIndex = 2;
            this.btnCustomers.Text = "Клиенты";
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);

            // btnOrders
            this.btnOrders.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOrders.Location = new System.Drawing.Point(340, 165);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(290, 55);
            this.btnOrders.TabIndex = 3;
            this.btnOrders.Text = "Учёт заказов";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            // btnExit
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnExit.Location = new System.Drawing.Point(180, 240);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(290, 55);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // MainFormSeller
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 325);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnCustomers);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnViewGames);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(660, 325);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainFormSeller";
            this.Text = "Главная форма (Продавец)";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnViewGames;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnExit;
    }
}