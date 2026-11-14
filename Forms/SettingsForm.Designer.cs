namespace BoardGame_Store
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.btnShowPassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.panelImport = new System.Windows.Forms.Panel();
            this.btnBrowseSql = new System.Windows.Forms.Button();
            this.txtImportPath = new System.Windows.Forms.TextBox();
            this.lblImportPath = new System.Windows.Forms.Label();
            this.lblImportTitle = new System.Windows.Forms.Label();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnImportSql = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.panelConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.panelImport.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(550, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Настройки системы";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelConnection
            // 
            this.panelConnection.BackColor = System.Drawing.Color.White;
            this.panelConnection.Controls.Add(this.btnShowPassword);
            this.panelConnection.Controls.Add(this.txtPassword);
            this.panelConnection.Controls.Add(this.lblPassword);
            this.panelConnection.Controls.Add(this.txtUser);
            this.panelConnection.Controls.Add(this.lblUser);
            this.panelConnection.Controls.Add(this.txtDatabase);
            this.panelConnection.Controls.Add(this.lblDatabase);
            this.panelConnection.Controls.Add(this.nudPort);
            this.panelConnection.Controls.Add(this.lblPort);
            this.panelConnection.Controls.Add(this.txtServer);
            this.panelConnection.Controls.Add(this.lblServer);
            this.panelConnection.Location = new System.Drawing.Point(12, 52);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(526, 248);
            this.panelConnection.TabIndex = 1;
            this.panelConnection.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // btnShowPassword
            // 
            this.btnShowPassword.BackColor = System.Drawing.Color.White;
            this.btnShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowPassword.FlatAppearance.BorderSize = 0;
            this.btnShowPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowPassword.Location = new System.Drawing.Point(456, 173);
            this.btnShowPassword.Name = "btnShowPassword";
            this.btnShowPassword.Size = new System.Drawing.Size(30, 35);
            this.btnShowPassword.TabIndex = 10;
            this.btnShowPassword.Text = "👁";
            this.btnShowPassword.UseVisualStyleBackColor = false;
            this.btnShowPassword.Click += new System.EventHandler(this.btnShowPassword_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPassword.Location = new System.Drawing.Point(140, 180);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(310, 25);
            this.txtPassword.TabIndex = 9;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblPassword.Location = new System.Drawing.Point(20, 183);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 17);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtUser.Location = new System.Drawing.Point(140, 140);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(310, 25);
            this.txtUser.TabIndex = 7;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUser.ForeColor = System.Drawing.Color.DimGray;
            this.lblUser.Location = new System.Drawing.Point(20, 143);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(103, 17);
            this.lblUser.TabIndex = 6;
            this.lblUser.Text = "Пользователь:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabase.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtDatabase.Location = new System.Drawing.Point(140, 100);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(310, 25);
            this.txtDatabase.TabIndex = 5;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDatabase.ForeColor = System.Drawing.Color.DimGray;
            this.lblDatabase.Location = new System.Drawing.Point(20, 103);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(94, 17);
            this.lblDatabase.TabIndex = 4;
            this.lblDatabase.Text = "База данных:";
            // 
            // nudPort
            // 
            this.nudPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPort.Font = new System.Drawing.Font("Tahoma", 11F);
            this.nudPort.Location = new System.Drawing.Point(140, 60);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(100, 25);
            this.nudPort.TabIndex = 3;
            this.nudPort.Value = new decimal(new int[] {
            3306,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPort.ForeColor = System.Drawing.Color.DimGray;
            this.lblPort.Location = new System.Drawing.Point(20, 63);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(46, 17);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Порт:";
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtServer.Location = new System.Drawing.Point(140, 20);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(310, 25);
            this.txtServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblServer.ForeColor = System.Drawing.Color.DimGray;
            this.lblServer.Location = new System.Drawing.Point(20, 23);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(59, 17);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Сервер:";
            // 
            // panelImport
            // 
            this.panelImport.BackColor = System.Drawing.Color.White;
            this.panelImport.Controls.Add(this.btnBrowseSql);
            this.panelImport.Controls.Add(this.txtImportPath);
            this.panelImport.Controls.Add(this.lblImportPath);
            this.panelImport.Controls.Add(this.lblImportTitle);
            this.panelImport.Location = new System.Drawing.Point(12, 306);
            this.panelImport.Name = "panelImport";
            this.panelImport.Size = new System.Drawing.Size(526, 96);
            this.panelImport.TabIndex = 2;
            this.panelImport.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            // 
            // btnBrowseSql
            // 
            this.btnBrowseSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowseSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseSql.FlatAppearance.BorderSize = 0;
            this.btnBrowseSql.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnBrowseSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseSql.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowseSql.ForeColor = System.Drawing.Color.White;
            this.btnBrowseSql.Location = new System.Drawing.Point(380, 46);
            this.btnBrowseSql.Name = "btnBrowseSql";
            this.btnBrowseSql.Size = new System.Drawing.Size(70, 26);
            this.btnBrowseSql.TabIndex = 3;
            this.btnBrowseSql.Text = "Обзор...";
            this.btnBrowseSql.UseVisualStyleBackColor = false;
            this.btnBrowseSql.Click += new System.EventHandler(this.btnBrowseSql_Click);
            // 
            // txtImportPath
            // 
            this.txtImportPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.txtImportPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImportPath.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtImportPath.Location = new System.Drawing.Point(140, 47);
            this.txtImportPath.Name = "txtImportPath";
            this.txtImportPath.ReadOnly = true;
            this.txtImportPath.Size = new System.Drawing.Size(230, 24);
            this.txtImportPath.TabIndex = 2;
            // 
            // lblImportPath
            // 
            this.lblImportPath.AutoSize = true;
            this.lblImportPath.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblImportPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblImportPath.Location = new System.Drawing.Point(20, 50);
            this.lblImportPath.Name = "lblImportPath";
            this.lblImportPath.Size = new System.Drawing.Size(119, 17);
            this.lblImportPath.TabIndex = 1;
            this.lblImportPath.Text = "Файл SQL-дампа:";
            // 
            // lblImportTitle
            // 
            this.lblImportTitle.AutoSize = true;
            this.lblImportTitle.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.lblImportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblImportTitle.Location = new System.Drawing.Point(20, 10);
            this.lblImportTitle.Name = "lblImportTitle";
            this.lblImportTitle.Size = new System.Drawing.Size(228, 20);
            this.lblImportTitle.TabIndex = 0;
            this.lblImportTitle.Text = "Восстановление базы данных";
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnSave);
            this.panelBottom.Controls.Add(this.btnImportSql);
            this.panelBottom.Controls.Add(this.btnTest);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 414);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(550, 60);
            this.panelBottom.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(438, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 47);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(332, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 47);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnImportSql
            // 
            this.btnImportSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnImportSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportSql.FlatAppearance.BorderSize = 0;
            this.btnImportSql.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnImportSql.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSql.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnImportSql.ForeColor = System.Drawing.Color.White;
            this.btnImportSql.Location = new System.Drawing.Point(170, 7);
            this.btnImportSql.Name = "btnImportSql";
            this.btnImportSql.Size = new System.Drawing.Size(156, 47);
            this.btnImportSql.TabIndex = 1;
            this.btnImportSql.Text = "Импортировать БД";
            this.btnImportSql.UseVisualStyleBackColor = false;
            this.btnImportSql.Click += new System.EventHandler(this.btnImportSql_Click);
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnTest.ForeColor = System.Drawing.Color.White;
            this.btnTest.Location = new System.Drawing.Point(3, 7);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(161, 47);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Проверить соединение";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 474);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelImport);
            this.Controls.Add(this.panelConnection);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки БД";
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.panelImport.ResumeLayout(false);
            this.panelImport.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnShowPassword;
        private System.Windows.Forms.Panel panelImport;
        private System.Windows.Forms.Label lblImportTitle;
        private System.Windows.Forms.Label lblImportPath;
        private System.Windows.Forms.TextBox txtImportPath;
        private System.Windows.Forms.Button btnBrowseSql;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnImportSql;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}