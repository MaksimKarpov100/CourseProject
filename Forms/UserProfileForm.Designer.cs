namespace BoardGame_Store
{
    partial class UserProfileForm
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
            this.pbAvatar = new System.Windows.Forms.PictureBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).BeginInit();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(200, 15);
            this.lblTitle.Text = "Профиль пользователя";

            this.pbAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbAvatar.Location = new System.Drawing.Point(20, 20);
            this.pbAvatar.Size = new System.Drawing.Size(120, 120);
            this.pbAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(170, 60);
            this.lblFullName.Text = "ФИО";
            this.txtFullName.Location = new System.Drawing.Point(260, 57);
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new System.Drawing.Size(280, 23);

            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(170, 100);
            this.lblLogin.Text = "Логин";
            this.txtLogin.Location = new System.Drawing.Point(260, 97);
            this.txtLogin.ReadOnly = true;
            this.txtLogin.Size = new System.Drawing.Size(280, 23);

            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(170, 140);
            this.lblRole.Text = "Роль";
            this.txtRole.Location = new System.Drawing.Point(260, 137);
            this.txtRole.ReadOnly = true;
            this.txtRole.Size = new System.Drawing.Size(280, 23);

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(170, 180);
            this.lblPhone.Text = "Телефон";
            this.txtPhone.Location = new System.Drawing.Point(260, 177);
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size(280, 23);

            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(20, 220);
            this.lblNewPassword.Text = "Новый пароль";
            this.txtNewPassword.Location = new System.Drawing.Point(20, 245);
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(250, 23);

            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(290, 220);
            this.lblConfirmPassword.Text = "Подтверждение";
            this.txtConfirmPassword.Location = new System.Drawing.Point(290, 245);
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(250, 23);

            this.btnChangePassword.Location = new System.Drawing.Point(20, 290);
            this.btnChangePassword.Size = new System.Drawing.Size(200, 40);
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = true;

            this.btnClose.Location = new System.Drawing.Point(340, 290);
            this.btnClose.Size = new System.Drawing.Size(200, 40);
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 350);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.pbAvatar);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UserProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Профиль";
            ((System.ComponentModel.ISupportInitialize)(this.pbAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbAvatar;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRole;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnClose;
    }
}