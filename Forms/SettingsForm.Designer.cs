namespace BoardGame_Store
{
    partial class SettingsForm
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
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpImport = new System.Windows.Forms.GroupBox();
            this.lblImportHint = new System.Windows.Forms.Label();
            this.btnImportSql = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            this.grpConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.grpImport.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 26);
            this.lblTitle.Text = "Настройки приложения";

            // grpConnection
            this.grpConnection.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConnection.Controls.Add(this.lblServer);
            this.grpConnection.Controls.Add(this.txtServer);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.nudPort);
            this.grpConnection.Controls.Add(this.lblDatabase);
            this.grpConnection.Controls.Add(this.txtDatabase);
            this.grpConnection.Controls.Add(this.lblUser);
            this.grpConnection.Controls.Add(this.txtUser);
            this.grpConnection.Controls.Add(this.lblPassword);
            this.grpConnection.Controls.Add(this.txtPassword);
            this.grpConnection.Controls.Add(this.btnTest);
            this.grpConnection.Controls.Add(this.btnSave);
            this.grpConnection.Location = new System.Drawing.Point(20, 60);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(660, 260);
            this.grpConnection.TabIndex = 1;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Подключение к базе данных MySQL";

            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(20, 35);
            this.lblServer.Size = new System.Drawing.Size(60, 17);
            this.lblServer.Text = "Сервер:";

            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Location = new System.Drawing.Point(150, 32);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(490, 23);

            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(20, 70);
            this.lblPort.Size = new System.Drawing.Size(45, 17);
            this.lblPort.Text = "Порт:";

            this.nudPort.Location = new System.Drawing.Point(150, 68);
            this.nudPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            this.nudPort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(100, 23);
            this.nudPort.Value = new decimal(new int[] { 3306, 0, 0, 0 });

            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(20, 105);
            this.lblDatabase.Size = new System.Drawing.Size(90, 17);
            this.lblDatabase.Text = "База данных:";

            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Location = new System.Drawing.Point(150, 102);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(490, 23);

            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(20, 140);
            this.lblUser.Size = new System.Drawing.Size(100, 17);
            this.lblUser.Text = "Пользователь:";

            this.txtUser.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUser.Location = new System.Drawing.Point(150, 137);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(490, 23);

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 175);
            this.lblPassword.Size = new System.Drawing.Size(60, 17);
            this.lblPassword.Text = "Пароль:";

            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(150, 172);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(490, 23);

            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTest.Location = new System.Drawing.Point(150, 210);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(220, 35);
            this.btnTest.Text = "Проверить подключение";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);

            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(390, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(250, 35);
            this.btnSave.Text = "Сохранить настройки";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // grpImport
            this.grpImport.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImport.Controls.Add(this.lblImportHint);
            this.grpImport.Controls.Add(this.btnImportSql);
            this.grpImport.Location = new System.Drawing.Point(20, 330);
            this.grpImport.Name = "grpImport";
            this.grpImport.Size = new System.Drawing.Size(660, 120);
            this.grpImport.TabIndex = 2;
            this.grpImport.TabStop = false;
            this.grpImport.Text = "Импорт базы данных";

            this.lblImportHint.AutoSize = true;
            this.lblImportHint.ForeColor = System.Drawing.Color.Gray;
            this.lblImportHint.Location = new System.Drawing.Point(20, 30);
            this.lblImportHint.Size = new System.Drawing.Size(600, 17);
            this.lblImportHint.Text = "Выберите SQL-дамп для восстановления базы данных.";

            this.btnImportSql.Location = new System.Drawing.Point(20, 60);
            this.btnImportSql.Name = "btnImportSql";
            this.btnImportSql.Size = new System.Drawing.Size(300, 40);
            this.btnImportSql.Text = "Импортировать SQL-файл";
            this.btnImportSql.Click += new System.EventHandler(this.btnImportSql_Click);

            // btnCancel
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(550, 465);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.Text = "Закрыть";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // SettingsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpImport);
            this.Controls.Add(this.grpConnection);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(700, 520);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "SettingsForm";
            this.Text = "Настройки";

            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.grpImport.ResumeLayout(false);
            this.grpImport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpConnection;
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
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpImport;
        private System.Windows.Forms.Label lblImportHint;
        private System.Windows.Forms.Button btnImportSql;
        private System.Windows.Forms.Button btnCancel;
    }
}