namespace BoardGame_Store
{
    partial class MainFormManager
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
            this.btnGames = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 26);
            this.lblTitle.Text = "Board Game Store - Товаровед";

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(32, 55);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(119, 17);
            this.lblRole.Text = "Роль: Товаровед";

            // btnGames
            this.btnGames.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnGames.Location = new System.Drawing.Point(30, 100);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(290, 55);
            this.btnGames.TabIndex = 0;
            this.btnGames.Text = "Товары";
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);

            // btnOrders
            this.btnOrders.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOrders.Location = new System.Drawing.Point(340, 100);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(290, 55);
            this.btnOrders.TabIndex = 1;
            this.btnOrders.Text = "Учёт заказов";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);

            // btnExit
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnExit.Location = new System.Drawing.Point(180, 180);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(290, 55);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // MainFormManager
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 265);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(660, 265);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainFormManager";
            this.Text = "Главная форма (Товаровед)";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnExit;
    }
}