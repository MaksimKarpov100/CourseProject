namespace BoardGame_Store
{
    partial class CatalogsForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.tabCatalogs = new System.Windows.Forms.TabControl();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panelCatEdit = new System.Windows.Forms.Panel();
            this.lblCatName = new System.Windows.Forms.Label();
            this.txtCatName = new System.Windows.Forms.TextBox();
            this.lblCatDesc = new System.Windows.Forms.Label();
            this.txtCatDesc = new System.Windows.Forms.TextBox();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.lblCatHint = new System.Windows.Forms.Label();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelCustEdit = new System.Windows.Forms.Panel();
            this.lblCustName = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.lblCustPhone = new System.Windows.Forms.Label();
            this.mtxtCustPhone = new System.Windows.Forms.MaskedTextBox();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.btnCustEdit = new System.Windows.Forms.Button();
            this.lblCustHint = new System.Windows.Forms.Label();
            this.tabStatuses = new System.Windows.Forms.TabPage();
            this.dgvStatuses = new System.Windows.Forms.DataGridView();
            this.lblStatusInfo = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();

            this.tabCatalogs.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelCatEdit.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelCustEdit.SuspendLayout();
            this.tabStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(160, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Справочники";

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(100, 19);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "[Роль] [ФИО]";

            // tabCatalogs
            this.tabCatalogs.Controls.Add(this.tabCategories);
            this.tabCatalogs.Controls.Add(this.tabCustomers);
            this.tabCatalogs.Controls.Add(this.tabStatuses);
            this.tabCatalogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabCatalogs.Location = new System.Drawing.Point(20, 45);
            this.tabCatalogs.Name = "tabCatalogs";
            this.tabCatalogs.SelectedIndex = 0;
            this.tabCatalogs.Size = new System.Drawing.Size(780, 460);
            this.tabCatalogs.TabIndex = 2;

            // tabCategories
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatEdit);
            this.tabCategories.Location = new System.Drawing.Point(4, 26);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Категории";

            // dgvCategories
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
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);

            // panelCatEdit
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

            // lblCatName
            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(15, 20);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(70, 19);
            this.lblCatName.TabIndex = 0;
            this.lblCatName.Text = "Название";

            // txtCatName
            this.txtCatName.Location = new System.Drawing.Point(100, 17);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(300, 25);
            this.txtCatName.TabIndex = 1;

            // lblCatDesc
            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(15, 55);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(75, 19);
            this.lblCatDesc.TabIndex = 2;
            this.lblCatDesc.Text = "Описание";

            // txtCatDesc
            this.txtCatDesc.Location = new System.Drawing.Point(100, 52);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(400, 25);
            this.txtCatDesc.TabIndex = 3;

            // btnCatAdd
            this.btnCatAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCatAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCatAdd.ForeColor = System.Drawing.Color.White;
            this.btnCatAdd.Location = new System.Drawing.Point(530, 15);
            this.btnCatAdd.Name = "btnCatAdd";
            this.btnCatAdd.Size = new System.Drawing.Size(100, 30);
            this.btnCatAdd.TabIndex = 4;
            this.btnCatAdd.Text = "Добавить";
            this.btnCatAdd.UseVisualStyleBackColor = false;
            this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);

            // btnCatEdit
            this.btnCatEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCatEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCatEdit.ForeColor = System.Drawing.Color.White;
            this.btnCatEdit.Location = new System.Drawing.Point(640, 15);
            this.btnCatEdit.Name = "btnCatEdit";
            this.btnCatEdit.Size = new System.Drawing.Size(100, 30);
            this.btnCatEdit.TabIndex = 5;
            this.btnCatEdit.Text = "Изменить";
            this.btnCatEdit.UseVisualStyleBackColor = false;
            this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);

            // lblCatHint
            this.lblCatHint.AutoSize = true;
            this.lblCatHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblCatHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCatHint.Location = new System.Drawing.Point(15, 95);
            this.lblCatHint.Name = "lblCatHint";
            this.lblCatHint.Size = new System.Drawing.Size(300, 13);
            this.lblCatHint.TabIndex = 6;
            this.lblCatHint.Text = "Для удаления дважды щёлкните по строке";

            // tabCustomers
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustEdit);
            this.tabCustomers.Location = new System.Drawing.Point(4, 26);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Клиенты";

            // dgvCustomers
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
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);

            // panelCustEdit
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

            // lblCustName
            this.lblCustName.AutoSize = true;
            this.lblCustName.Location = new System.Drawing.Point(15, 20);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(40, 19);
            this.lblCustName.TabIndex = 0;
            this.lblCustName.Text = "ФИО";

            // txtCustName
            this.txtCustName.Location = new System.Drawing.Point(100, 17);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(300, 25);
            this.txtCustName.TabIndex = 1;

            // lblCustPhone
            this.lblCustPhone.AutoSize = true;
            this.lblCustPhone.Location = new System.Drawing.Point(15, 55);
            this.lblCustPhone.Name = "lblCustPhone";
            this.lblCustPhone.Size = new System.Drawing.Size(65, 19);
            this.lblCustPhone.TabIndex = 2;
            this.lblCustPhone.Text = "Телефон";

            // mtxtCustPhone
            this.mtxtCustPhone.Location = new System.Drawing.Point(100, 52);
            this.mtxtCustPhone.Mask = "+7 (000) 000-00-00";
            this.mtxtCustPhone.Name = "mtxtCustPhone";
            this.mtxtCustPhone.Size = new System.Drawing.Size(200, 25);
            this.mtxtCustPhone.TabIndex = 3;

            // btnCustAdd
            this.btnCustAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCustAdd.ForeColor = System.Drawing.Color.White;
            this.btnCustAdd.Location = new System.Drawing.Point(530, 15);
            this.btnCustAdd.Name = "btnCustAdd";
            this.btnCustAdd.Size = new System.Drawing.Size(100, 30);
            this.btnCustAdd.TabIndex = 4;
            this.btnCustAdd.Text = "Добавить";
            this.btnCustAdd.UseVisualStyleBackColor = false;
            this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);

            // btnCustEdit
            this.btnCustEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCustEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCustEdit.ForeColor = System.Drawing.Color.White;
            this.btnCustEdit.Location = new System.Drawing.Point(640, 15);
            this.btnCustEdit.Name = "btnCustEdit";
            this.btnCustEdit.Size = new System.Drawing.Size(100, 30);
            this.btnCustEdit.TabIndex = 5;
            this.btnCustEdit.Text = "Изменить";
            this.btnCustEdit.UseVisualStyleBackColor = false;
            this.btnCustEdit.Click += new System.EventHandler(this.btnCustEdit_Click);

            // lblCustHint
            this.lblCustHint.AutoSize = true;
            this.lblCustHint.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblCustHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCustHint.Location = new System.Drawing.Point(15, 95);
            this.lblCustHint.Name = "lblCustHint";
            this.lblCustHint.Size = new System.Drawing.Size(300, 13);
            this.lblCustHint.TabIndex = 6;
            this.lblCustHint.Text = "Для удаления дважды щёлкните по строке";

            // tabStatuses
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Controls.Add(this.lblStatusInfo);
            this.tabStatuses.Location = new System.Drawing.Point(4, 26);
            this.tabStatuses.Name = "tabStatuses";
            this.tabStatuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuses.TabIndex = 2;
            this.tabStatuses.Text = "Статусы";

            // dgvStatuses
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

            // lblStatusInfo
            this.lblStatusInfo.AutoSize = true;
            this.lblStatusInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatusInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusInfo.Location = new System.Drawing.Point(15, 15);
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(500, 15);
            this.lblStatusInfo.TabIndex = 1;
            this.lblStatusInfo.Text = "Статусы фиксированные: Новый, Не готов, Готов, Отменён";

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(690, 515);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // CatalogsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 570);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatalogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";

            this.tabCatalogs.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelCatEdit.ResumeLayout(false);
            this.panelCatEdit.PerformLayout();
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelCustEdit.ResumeLayout(false);
            this.panelCustEdit.PerformLayout();
            this.tabStatuses.ResumeLayout(false);
            this.tabStatuses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TabControl tabCatalogs;
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
        private System.Windows.Forms.TabPage tabStatuses;
        private System.Windows.Forms.DataGridView dgvStatuses;
        private System.Windows.Forms.Label lblStatusInfo;
        private System.Windows.Forms.Button btnBack;
    }
}