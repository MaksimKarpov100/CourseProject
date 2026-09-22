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
            this.panelTop = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.btnCatalogs = new System.Windows.Forms.Button();
            this.btnGames = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnDiscounts = new System.Windows.Forms.Button();
            this.btnSpecial = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelTop.Controls.Add(this.pbLogo);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblRole);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(720, 80);
            this.panelTop.TabIndex = 7;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.White;
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(620, 8);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(64, 64);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(180, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(306, 26);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Добро пожаловать, [ФИО]";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(320, 50);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(101, 20);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Роль: [Роль]";
            // 
            // btnCatalogs
            // 
            this.btnCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnCatalogs.Location = new System.Drawing.Point(50, 120);
            this.btnCatalogs.Name = "btnCatalogs";
            this.btnCatalogs.Size = new System.Drawing.Size(290, 60);
            this.btnCatalogs.TabIndex = 6;
            this.btnCatalogs.Text = "Справочники";
            this.btnCatalogs.UseVisualStyleBackColor = true;
            // 
            // btnGames
            // 
            this.btnGames.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnGames.Location = new System.Drawing.Point(380, 120);
            this.btnGames.Name = "btnGames";
            this.btnGames.Size = new System.Drawing.Size(290, 60);
            this.btnGames.TabIndex = 5;
            this.btnGames.Text = "Товары ";
            this.btnGames.UseVisualStyleBackColor = true;
            // 
            // btnOrders
            // 
            this.btnOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnOrders.Location = new System.Drawing.Point(50, 200);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(290, 60);
            this.btnOrders.TabIndex = 4;
            this.btnOrders.Text = "Учёт заказов";
            this.btnOrders.UseVisualStyleBackColor = true;
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDiscounts.Location = new System.Drawing.Point(380, 200);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(290, 60);
            this.btnDiscounts.TabIndex = 3;
            this.btnDiscounts.Text = "Скидки";
            this.btnDiscounts.UseVisualStyleBackColor = true;
            // 
            // btnSpecial
            // 
            this.btnSpecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnSpecial.Location = new System.Drawing.Point(50, 280);
            this.btnSpecial.Name = "btnSpecial";
            this.btnSpecial.Size = new System.Drawing.Size(290, 60);
            this.btnSpecial.TabIndex = 2;
            this.btnSpecial.Text = "Специальные возможности";
            this.btnSpecial.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnProfile.Location = new System.Drawing.Point(380, 280);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(290, 60);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "Профиль";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnExit.Location = new System.Drawing.Point(215, 360);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(290, 60);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 460);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnSpecial);
            this.Controls.Add(this.btnDiscounts);
            this.Controls.Add(this.btnOrders);
            this.Controls.Add(this.btnGames);
            this.Controls.Add(this.btnCatalogs);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главная форма (Администратор)";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnCatalogs;
        private System.Windows.Forms.Button btnGames;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnDiscounts;
        private System.Windows.Forms.Button btnSpecial;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnExit;
    }
}