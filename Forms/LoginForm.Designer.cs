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
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.lblCaptcha = new System.Windows.Forms.Label();
            this.pbCaptcha = new System.Windows.Forms.PictureBox();
            this.txtCaptcha = new System.Windows.Forms.TextBox();
            this.lblCaptchaHint = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnExitApp = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(120, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Board Game Store";

            // pbLogo
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(20, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(80, 80);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 1;
            this.pbLogo.TabStop = false;

            // lblSubtitle
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSubtitle.Location = new System.Drawing.Point(120, 55);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(200, 18);
            this.lblSubtitle.TabIndex = 2;
            this.lblSubtitle.Text = "Авторизуйтесь в системе";

            // lblLogin
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblLogin.Location = new System.Drawing.Point(40, 130);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(50, 18);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Логин";

            // txtLogin
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtLogin.Location = new System.Drawing.Point(40, 155);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(400, 24);
            this.txtLogin.TabIndex = 4;

            // lblPassword
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblPassword.Location = new System.Drawing.Point(40, 195);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 18);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Пароль";

            // txtPassword
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPassword.Location = new System.Drawing.Point(40, 220);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(360, 24);
            this.txtPassword.TabIndex = 6;

            // btnShowPassword
            this.btnShowPassword.Font = new System.Drawing.Font("Segoe UI Emoji", 11F);
            this.btnShowPassword.Location = new System.Drawing.Point(405, 219);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(35, 26);
            this.btnShowPassword.TabIndex = 7;
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.UseVisualStyleBackColor = true;

            // lblCaptcha
            this.lblCaptcha.AutoSize = true;
            this.lblCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblCaptcha.Location = new System.Drawing.Point(40, 265);
            this.lblCaptcha.Name = "lblCaptcha";
            this.lblCaptcha.Size = new System.Drawing.Size(100, 18);
            this.lblCaptcha.TabIndex = 8;
            this.lblCaptcha.Text = "Введите код:";
            this.lblCaptcha.Visible = false;

            // pbCaptcha
            this.pbCaptcha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCaptcha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCaptcha.Location = new System.Drawing.Point(40, 290);
            this.pbCaptcha.Name = "pbCaptcha";
            this.pbCaptcha.Size = new System.Drawing.Size(180, 60);
            this.pbCaptcha.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCaptcha.TabIndex = 9;
            this.pbCaptcha.TabStop = false;
            this.pbCaptcha.Visible = false;

            // txtCaptcha
            this.txtCaptcha.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtCaptcha.Location = new System.Drawing.Point(240, 305);
            this.txtCaptcha.Name = "txtCaptcha";
            this.txtCaptcha.Size = new System.Drawing.Size(200, 24);
            this.txtCaptcha.TabIndex = 10;
            this.txtCaptcha.Visible = false;

            // lblCaptchaHint
            this.lblCaptchaHint.AutoSize = true;
            this.lblCaptchaHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Italic);
            this.lblCaptchaHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCaptchaHint.Location = new System.Drawing.Point(40, 355);
            this.lblCaptchaHint.Name = "lblCaptchaHint";
            this.lblCaptchaHint.Size = new System.Drawing.Size(230, 13);
            this.lblCaptchaHint.TabIndex = 11;
            this.lblCaptchaHint.Text = "Кликните по картинке, чтобы обновить";
            this.lblCaptchaHint.Visible = false;

            // lblTimer
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimer.ForeColor = System.Drawing.Color.Red;
            this.lblTimer.Location = new System.Drawing.Point(240, 275);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(60, 20);
            this.lblTimer.TabIndex = 12;
            this.lblTimer.Text = "00:10";
            this.lblTimer.Visible = false;

            // lblError
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(40, 380);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 13;
            this.lblError.Visible = false;

            // btnLogin
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Location = new System.Drawing.Point(40, 410);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(400, 45);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = true;

            // btnSettings
            this.btnSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnSettings.Location = new System.Drawing.Point(40, 470);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(195, 38);
            this.btnSettings.TabIndex = 15;
            this.btnSettings.Text = "Настройки БД";
            this.btnSettings.UseVisualStyleBackColor = true;

            // btnExitApp
            this.btnExitApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnExitApp.Location = new System.Drawing.Point(245, 470);
            this.btnExitApp.Name = "btnExitApp";
            this.btnExitApp.Size = new System.Drawing.Size(195, 38);
            this.btnExitApp.TabIndex = 16;
            this.btnExitApp.Text = "Выход";
            this.btnExitApp.UseVisualStyleBackColor = true;

            // ============ ПОДПИСКИ ============
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            this.btnExitApp.Click += new System.EventHandler(this.btnExitApp_Click);
            this.pbCaptcha.Click += new System.EventHandler(this.pbCaptcha_Click);

            // LoginForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 540);
            this.Controls.Add(this.btnExitApp);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblCaptchaHint);
            this.Controls.Add(this.txtCaptcha);
            this.Controls.Add(this.pbCaptcha);
            this.Controls.Add(this.lblCaptcha);
            this.Controls.Add(this.btnShowPassword);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptcha)).EndInit();
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
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Label lblCaptcha;
        private System.Windows.Forms.PictureBox pbCaptcha;
        private System.Windows.Forms.TextBox txtCaptcha;
        private System.Windows.Forms.Label lblCaptchaHint;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnExitApp;
    }
}