namespace BoardGame_Store
{
    partial class LoginForm
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(324, 29);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Магазин настольных игр";
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(20, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(80, 80);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 9;
            this.pbLogo.TabStop = false;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubtitle.Location = new System.Drawing.Point(120, 70);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(204, 20);
            this.lblSubtitle.TabIndex = 8;
            this.lblSubtitle.Text = "Авторизуйтесь в системе";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblLogin.Location = new System.Drawing.Point(60, 140);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(55, 20);
            this.lblLogin.TabIndex = 7;
            this.lblLogin.Text = "Логин";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtLogin.Location = new System.Drawing.Point(60, 165);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(320, 26);
            this.txtLogin.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblPassword.Location = new System.Drawing.Point(60, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(67, 20);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPassword.Location = new System.Drawing.Point(60, 235);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(320, 26);
            this.txtPassword.TabIndex = 4;
            // 
            // lblCaptcha
            // 
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblCaptcha.Location = new System.Drawing.Point(56, 286);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(66, 20);
            this.lblCaptcha.TabIndex = 3;
            this.lblCaptcha.Text = "captcha";
            this.lblCaptcha.Visible = false;
            // 
            // txtCaptcha
            // 
            this.txtCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtCaptcha.Location = new System.Drawing.Point(136, 283);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(150, 26);
            this.txtCaptcha.TabIndex = 2;
            this.txtCaptcha.Visible = false;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(306, 286);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(49, 20);
            this.lblTimer.TabIndex = 1;
            this.lblTimer.Text = "00:00";
            this.lblTimer.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(125, 343);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 40);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(124, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 40);
            this.button1.TabIndex = 11;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 444);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button button1;
    }
}