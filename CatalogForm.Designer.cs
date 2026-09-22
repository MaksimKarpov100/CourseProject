namespace BoardGame_Store
{
    partial class CatalogForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.tabStatuses = new System.Windows.Forms.TabPage();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.dgvStatuses = new System.Windows.Forms.DataGridView();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.panelCustEdit = new System.Windows.Forms.Panel();
            this.lblCustHint = new System.Windows.Forms.Label();
            this.btnCustEdit = new System.Windows.Forms.Button();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.mtxtCustPhone = new System.Windows.Forms.MaskedTextBox();
            this.lblCustPhone = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.lblCustName = new System.Windows.Forms.Label();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.panelCatEdit = new System.Windows.Forms.Panel();
            this.lblCatHint = new System.Windows.Forms.Label();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.lblCatName = new System.Windows.Forms.Label();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.tabCatalogs = new System.Windows.Forms.TabControl();
            this.tabStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).BeginInit();
            this.tabCustomers.SuspendLayout();
            this.panelCustEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tabCategories.SuspendLayout();
            this.panelCatEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.tabCatalogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(158, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Справочники";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(94, 17);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "[Роль] [ФИО]";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(690, 515);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // tabStatuses
            // 
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Controls.Add(this.lblStatusInfo);
            this.tabStatuses.Location = new System.Drawing.Point(4, 25);
            this.tabStatuses.Name = "tabStatuses";
            this.tabStatuses.Size = new System.Drawing.Size(772, 431);
            this.tabStatuses.TabIndex = 3;
            this.tabStatuses.Text = "Статусы";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = true;
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblStatusInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusInfo.Location = new System.Drawing.Point(15, 15);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(402, 17);
            this.lblStatusInfo.TabIndex = 1;
            this.lblStatusInfo.Text = "Статусы фиксированные: Новый, Не готов, Готов, Отменён";
            // 
            // dgvStatuses
            // 
            this.dgvStatuses.AllowUserToAddRows = false;
            this.dgvStatuses.AllowUserToDeleteRows = false;
            this.dgvStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatuses.Location = new System.Drawing.Point(10, 50);
            this.dgvStatuses.Name = "dgvStatuses";
            this.dgvStatuses.ReadOnly = true;
            this.dgvStatuses.RowHeadersVisible = false;
            this.dgvStatuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatuses.Size = new System.Drawing.Size(750, 360);
            this.dgvStatuses.TabIndex = 0;
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustEdit);
            this.tabCustomers.Location = new System.Drawing.Point(4, 25);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Size = new System.Drawing.Size(772, 431);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Клиенты";
            // 
            // panelCustEdit
            // 
            this.panelCustEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCustEdit.Controls.Add(this.lblCustName);
            this.panelCustEdit.Controls.Add(this.txtCustName);
            this.panelCustEdit.Controls.Add(this.lblCustPhone);
            this.panelCustEdit.Controls.Add(this.mtxtCustPhone);
            this.panelCustEdit.Controls.Add(this.btnCustAdd);
            this.panelCustEdit.Controls.Add(this.btnCustEdit);
            this.panelCustEdit.Controls.Add(this.lblCustHint);
            this.panelCustEdit.Location = new System.Drawing.Point(10, 280);
            this.panelCustEdit.Name = "panelCustEdit";
            this.panelCustEdit.Size = new System.Drawing.Size(750, 130);
            this.panelCustEdit.TabIndex = 1;
            // 
            // lblCustHint
            // 
            this.lblCustHint.AutoSize = true;
            this.lblCustHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCustHint.Location = new System.Drawing.Point(15, 95);
            this.lblCustHint.Name = "lblCustHint";
            this.lblCustHint.Size = new System.Drawing.Size(294, 17);
            this.lblCustHint.TabIndex = 6;
            this.lblCustHint.Text = "Для удаления дважды щёлкните по строке";
            // 
            // btnCustEdit
            // 
            this.btnCustEdit.Location = new System.Drawing.Point(640, 15);
            this.btnCustEdit.Name = "btnCustEdit";
            this.btnCustEdit.Size = new System.Drawing.Size(100, 30);
            this.btnCustEdit.TabIndex = 5;
            this.btnCustEdit.Text = "Изменить";
            this.btnCustEdit.UseVisualStyleBackColor = true;
            // 
            // btnCustAdd
            // 
            this.btnCustAdd.Location = new System.Drawing.Point(530, 15);
            this.btnCustAdd.Name = "btnCustAdd";
            this.btnCustAdd.Size = new System.Drawing.Size(100, 30);
            this.btnCustAdd.TabIndex = 4;
            this.btnCustAdd.Text = "Добавить";
            this.btnCustAdd.UseVisualStyleBackColor = true;
            // 
            // mtxtCustPhone
            // 
            this.mtxtCustPhone.Location = new System.Drawing.Point(100, 52);
            this.mtxtCustPhone.Mask = "+7 (000) 000-00-00";
            this.mtxtCustPhone.Name = "mtxtCustPhone";
            this.mtxtCustPhone.Size = new System.Drawing.Size(200, 23);
            this.mtxtCustPhone.TabIndex = 3;
            // 
            // lblCustPhone
            // 
            this.lblCustPhone.AutoSize = true;
            this.lblCustPhone.Location = new System.Drawing.Point(15, 55);
            this.lblCustPhone.Name = "lblCustPhone";
            this.lblCustPhone.Size = new System.Drawing.Size(68, 17);
            this.lblCustPhone.TabIndex = 2;
            this.lblCustPhone.Text = "Телефон";
            // 
            // txtCustName
            // 
            this.txtCustName.Location = new System.Drawing.Point(100, 17);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(300, 23);
            this.txtCustName.TabIndex = 1;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.Location = new System.Drawing.Point(15, 20);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(42, 17);
            this.lblCustName.TabIndex = 0;
            this.lblCustName.Text = "ФИО";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(10, 10);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(750, 260);
            this.dgvCustomers.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatEdit);
            this.tabCategories.Location = new System.Drawing.Point(4, 25);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Size = new System.Drawing.Size(772, 431);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Категории";
            // 
            // panelCatEdit
            // 
            this.panelCatEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCatEdit.Controls.Add(this.lblCatName);
            this.panelCatEdit.Controls.Add(this.txtCatName);
            this.panelCatEdit.Controls.Add(this.lblCatDesc);
            this.panelCatEdit.Controls.Add(this.txtCatDesc);
            this.panelCatEdit.Controls.Add(this.btnCatAdd);
            this.panelCatEdit.Controls.Add(this.btnCatEdit);
            this.panelCatEdit.Controls.Add(this.lblCatHint);
            this.panelCatEdit.Location = new System.Drawing.Point(10, 280);
            this.panelCatEdit.Name = "panelCatEdit";
            this.panelCatEdit.Size = new System.Drawing.Size(750, 130);
            this.panelCatEdit.TabIndex = 1;
            // 
            // lblCatHint
            // 
            this.lblCatHint.AutoSize = true;
            this.lblCatHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCatHint.Location = new System.Drawing.Point(15, 95);
            this.lblCatHint.Name = "lblCatHint";
            this.lblCatHint.Size = new System.Drawing.Size(294, 17);
            this.lblCatHint.TabIndex = 6;
            this.lblCatHint.Text = "Для удаления дважды щёлкните по строке";
            // 
            // btnCatEdit
            // 
            this.btnCatEdit.Location = new System.Drawing.Point(640, 15);
            this.btnCatEdit.Name = "btnCatEdit";
            this.btnCatEdit.Size = new System.Drawing.Size(100, 30);
            this.btnCatEdit.TabIndex = 5;
            this.btnCatEdit.Text = "Изменить";
            this.btnCatEdit.UseVisualStyleBackColor = true;
            // 
            // btnCatAdd
            // 
            this.btnCatAdd.Location = new System.Drawing.Point(530, 15);
            this.btnCatAdd.Name = "btnCatAdd";
            this.btnCatAdd.Size = new System.Drawing.Size(100, 30);
            this.btnCatAdd.TabIndex = 4;
            this.btnCatAdd.Text = "Добавить";
            this.btnCatAdd.UseVisualStyleBackColor = true;
            // 
            // txtCatDesc
            // 
            this.txtCatDesc.Location = new System.Drawing.Point(100, 52);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(400, 23);
            this.txtCatDesc.TabIndex = 3;
            // 
            // lblCatDesc
            // 
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(15, 55);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(74, 17);
            this.lblCatDesc.TabIndex = 2;
            this.lblCatDesc.Text = "Описание";
            // 
            // txtCatName
            // 
            this.txtCatName.Location = new System.Drawing.Point(100, 17);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(300, 23);
            this.txtCatName.TabIndex = 1;
            // 
            // lblCatName
            // 
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(15, 20);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(72, 17);
            this.lblCatName.TabIndex = 0;
            this.lblCatName.Text = "Название";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Location = new System.Drawing.Point(10, 10);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(750, 260);
            this.dgvCategories.TabIndex = 0;
            // 
            // tabCatalogs
            // 
            this.tabCatalogs.Controls.Add(this.tabCategories);
            this.tabCatalogs.Controls.Add(this.tabCustomers);
            this.tabCatalogs.Controls.Add(this.tabStatuses);
            this.tabCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabCatalogs.Location = new System.Drawing.Point(20, 45);
            this.tabCatalogs.Name = "tabCatalogs";
            this.tabCatalogs.SelectedIndex = 0;
            this.tabCatalogs.Size = new System.Drawing.Size(780, 460);
            this.tabCatalogs.TabIndex = 1;
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 570);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CatalogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.tabStatuses.ResumeLayout(false);
            this.tabStatuses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.tabCustomers.ResumeLayout(false);
            this.panelCustEdit.ResumeLayout(false);
            this.panelCustEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tabCategories.ResumeLayout(false);
            this.panelCatEdit.ResumeLayout(false);
            this.panelCatEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.tabCatalogs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TabPage tabStatuses;
        private System.Windows.Forms.DataGridView dgvStatuses;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelCustEdit;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label lblCustPhone;
        private System.Windows.Forms.MaskedTextBox mtxtCustPhone;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustEdit;
        private System.Windows.Forms.Label lblCustHint;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panelCatEdit;
        private System.Windows.Forms.Label lblCatName;
        private System.Windows.Forms.TextBox txtCatName;
        private System.Windows.Forms.Label lblCatDesc;
        private System.Windows.Forms.TextBox txtCatDesc;
        private System.Windows.Forms.Button btnCatAdd;
        private System.Windows.Forms.Button btnCatEdit;
        private System.Windows.Forms.Label lblCatHint;
        private System.Windows.Forms.TabControl tabCatalogs;
    }
}