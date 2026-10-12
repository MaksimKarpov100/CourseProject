namespace BoardGame_Store
{
    partial class MainFormAdmin
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnDiscounts = new System.Windows.Forms.Button();
            this.btnSpecial = new System.Windows.Forms.Button();
            this.btnCatalogs = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(404, 26);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Board Game Store - Администратор";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.Gray;
            this.lblRole.Location = new System.Drawing.Point(32, 55);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(151, 17);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Роль: Администратор";
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnUsers.Location = new System.Drawing.Point(30, 95);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(290, 55);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnGames
            // 
            this.btnGames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnGames.Location = new System.Drawing.Point(340, 95);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(290, 55);
            this.btnGames.TabIndex = 1;
            this.btnGames.Text = "Товары ";
            this.btnGames.Click += new System.EventHandler(this.btnGames_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOrders.Location = new System.Drawing.Point(30, 160);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(290, 55);
            this.btnOrders.TabIndex = 2;
            this.btnOrders.Text = "Учёт заказов";
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDiscounts.Location = new System.Drawing.Point(340, 160);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(290, 55);
            this.btnDiscounts.TabIndex = 3;
            this.btnDiscounts.Text = "Скидки";
            this.btnDiscounts.Click += new System.EventHandler(this.btnDiscounts_Click);
            // 
            // btnSpecial
            // 
            this.btnSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSpecial.Location = new System.Drawing.Point(30, 225);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(290, 55);
            this.btnSpecial.TabIndex = 4;
            this.btnSpecial.Text = "Специальные возможности";
            this.btnSpecial.Click += new System.EventHandler(this.btnSpecial_Click);
            // 
            // btnCatalogs
            // 
            this.btnCatalogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCatalogs.Location = new System.Drawing.Point(340, 225);
            this.btnCatalogs.Name = "btnCatalogs";
            this.btnCatalogs.Size = new System.Drawing.Size(290, 55);
            this.btnCatalogs.TabIndex = 5;
            this.btnCatalogs.Text = "Справочники";
            this.btnCatalogs.Click += new System.EventHandler(this.btnCatalogs_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnProfile.Location = new System.Drawing.Point(30, 290);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(290, 55);
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Профиль";
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnExit.Location = new System.Drawing.Point(340, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(290, 55);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Выход";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 375);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnCatalogs);
            this.Controls.Add(this.btnSpecial);
            this.Controls.Add(this.btnDiscounts);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.MinimumSize = new System.Drawing.Size(660, 375);
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма (Администратор)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnDiscounts;
        private System.Windows.Forms.Button btnSpecial;
        private System.Windows.Forms.Button btnCatalogs;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnExit;
    }
}