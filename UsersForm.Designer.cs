namespace BoardGame_Store
{
    partial class UsersForm
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRoleFilter = new System.Windows.Forms.Label();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.lblCount = new System.Windows.Forms.Label();
            this.panelPagination = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.lblPageSize = new System.Windows.Forms.Label();
            this.cmbPageSize = new System.Windows.Forms.ComboBox();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRoleEdit = new System.Windows.Forms.Label();
            this.cmbRoleEdit = new System.Windows.Forms.ComboBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.mtxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();

            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelEdit.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Text = "Управление пользователями";

            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Text = "[Роль] [ФИО]";

            this.panelFilters.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblRoleFilter);
            this.panelFilters.Controls.Add(this.cmbRoleFilter);
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Controls.Add(this.btnReset);
            this.panelFilters.Location = new System.Drawing.Point(15, 45);
            this.panelFilters.Size = new System.Drawing.Size(790, 50);

            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 15);
            this.lblSearch.Text = "Поиск";
            this.txtSearch.Location = new System.Drawing.Point(70, 12);
            this.txtSearch.Size = new System.Drawing.Size(200, 23);

            this.lblRoleFilter.AutoSize = true;
            this.lblRoleFilter.Location = new System.Drawing.Point(290, 15);
            this.lblRoleFilter.Text = "Роль";
            this.cmbRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleFilter.Items.AddRange(new object[] { "Все", "Администратор", "Товаровед", "Продавец" });
            this.cmbRoleFilter.Location = new System.Drawing.Point(340, 12);
            this.cmbRoleFilter.Size = new System.Drawing.Size(140, 24);

            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(490, 15);
            this.lblSort.Text = "Сортировать по:";
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] { "По ФИО", "По логину", "По роли" });
            this.cmbSort.Location = new System.Drawing.Point(610, 12);
            this.cmbSort.Size = new System.Drawing.Size(120, 24);

            this.btnReset.Location = new System.Drawing.Point(740, 10);
            this.btnReset.Size = new System.Drawing.Size(45, 30);
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;

            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(15, 105);
            this.dgvUsers.Size = new System.Drawing.Size(790, 220);
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 335);
            this.lblCount.Text = "Количество записей: [кол-во]";

            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cmbPageSize);
            this.panelPagination.Location = new System.Drawing.Point(15, 355);
            this.panelPagination.Size = new System.Drawing.Size(790, 40);

            this.btnFirst.Location = new System.Drawing.Point(0, 5);
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;

            this.btnPrev.Location = new System.Drawing.Point(60, 5);
            this.btnPrev.Size = new System.Drawing.Size(50, 30);
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;

            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(130, 12);
            this.lblPageInfo.Text = "Страница 1 из 1";

            this.btnNext.Location = new System.Drawing.Point(250, 5);
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;

            this.btnLast.Location = new System.Drawing.Point(310, 5);
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;

            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(400, 12);
            this.lblPageSize.Text = "Записей:";
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Items.AddRange(new object[] { "10", "25", "50", "100" });
            this.cmbPageSize.Location = new System.Drawing.Point(470, 8);
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);

            this.panelEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEdit.Controls.Add(this.lblFullName);
            this.panelEdit.Controls.Add(this.txtFullName);
            this.panelEdit.Controls.Add(this.lblLogin);
            this.panelEdit.Controls.Add(this.txtLogin);
            this.panelEdit.Controls.Add(this.lblPassword);
            this.panelEdit.Controls.Add(this.txtPassword);
            this.panelEdit.Controls.Add(this.lblRoleEdit);
            this.panelEdit.Controls.Add(this.cmbRoleEdit);
            this.panelEdit.Controls.Add(this.lblPhone);
            this.panelEdit.Controls.Add(this.mtxtPhone);
            this.panelEdit.Location = new System.Drawing.Point(15, 405);
            this.panelEdit.Size = new System.Drawing.Size(790, 90);

            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(10, 15);
            this.lblFullName.Text = "ФИО";
            this.txtFullName.Location = new System.Drawing.Point(70, 12);
            this.txtFullName.Size = new System.Drawing.Size(250, 23);

            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(340, 15);
            this.lblLogin.Text = "Логин";
            this.txtLogin.Location = new System.Drawing.Point(400, 12);
            this.txtLogin.Size = new System.Drawing.Size(180, 23);

            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(10, 55);
            this.lblPassword.Text = "Пароль";
            this.txtPassword.Location = new System.Drawing.Point(70, 52);
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(180, 23);

            this.lblRoleEdit.AutoSize = true;
            this.lblRoleEdit.Location = new System.Drawing.Point(280, 55);
            this.lblRoleEdit.Text = "Роль";
            this.cmbRoleEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleEdit.Items.AddRange(new object[] { "Администратор", "Товаровед", "Продавец" });
            this.cmbRoleEdit.Location = new System.Drawing.Point(340, 52);
            this.cmbRoleEdit.Size = new System.Drawing.Size(150, 24);

            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(510, 55);
            this.lblPhone.Text = "Телефон";
            this.mtxtPhone.Location = new System.Drawing.Point(580, 52);
            this.mtxtPhone.Mask = "+7 (000) 000-00-00";
            this.mtxtPhone.Size = new System.Drawing.Size(180, 23);

            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.lblHint);
            this.panelButtons.Controls.Add(this.btnBack);
            this.panelButtons.Location = new System.Drawing.Point(15, 505);
            this.panelButtons.Size = new System.Drawing.Size(790, 45);

            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnAdd.Size = new System.Drawing.Size(140, 35);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;

            this.btnEdit.Location = new System.Drawing.Point(150, 5);
            this.btnEdit.Size = new System.Drawing.Size(140, 35);
            this.btnEdit.Text = "Изменить запись";
            this.btnEdit.UseVisualStyleBackColor = true;

            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(320, 15);
            this.lblHint.Text = "Для удаления дважды щёлкните по строке";

            this.btnBack.Location = new System.Drawing.Point(680, 5);
            this.btnBack.Size = new System.Drawing.Size(110, 35);
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 565);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";

            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRoleFilter;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Panel panelPagination;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label lblPageSize;
        private System.Windows.Forms.ComboBox cmbPageSize;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRoleEdit;
        private System.Windows.Forms.ComboBox cmbRoleEdit;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.MaskedTextBox mtxtPhone;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnBack;
    }
}