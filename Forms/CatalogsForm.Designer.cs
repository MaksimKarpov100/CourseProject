namespace BoardGame_Store
{
    partial class CatalogsForm
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

            // ============== lblTitle ==============
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(180, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Справочники";

            // ============== tabCatalogs ==============
            this.tabCatalogs.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right));
            this.tabCatalogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabCatalogs.Location = new System.Drawing.Point(20, 55);
            this.tabCatalogs.Name = "tabCatalogs";
            this.tabCatalogs.SelectedIndex = 0;
            this.tabCatalogs.Size = new System.Drawing.Size(960, 530);
            this.tabCatalogs.TabIndex = 1;
            this.tabCatalogs.Controls.Add(this.tabCategories);
            this.tabCatalogs.Controls.Add(this.tabCustomers);
            this.tabCatalogs.Controls.Add(this.tabStatuses);

            // ============== tabCategories ==============
            this.tabCategories.BackColor = System.Drawing.Color.White;
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatEdit);
            this.tabCategories.Location = new System.Drawing.Point(4, 26);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(952, 500);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Категории";

            // dgvCategories (сначала — заполняет всё)
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(3, 3);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowTemplate.Height = 32;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // panelCatEdit (прижат к низу)
            this.panelCatEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCatEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCatEdit.Height = 130;
            this.panelCatEdit.Controls.Add(this.lblCatName);
            this.panelCatEdit.Controls.Add(this.txtCatName);
            this.panelCatEdit.Controls.Add(this.lblCatDesc);
            this.panelCatEdit.Controls.Add(this.txtCatDesc);
            this.panelCatEdit.Controls.Add(this.btnCatAdd);
            this.panelCatEdit.Controls.Add(this.btnCatEdit);
            this.panelCatEdit.Controls.Add(this.lblCatHint);
            this.panelCatEdit.Name = "panelCatEdit";
            this.panelCatEdit.TabIndex = 1;

            this.lblCatName.AutoSize = true;
            this.lblCatName.Location = new System.Drawing.Point(20, 25);
            this.lblCatName.Name = "lblCatName";
            this.lblCatName.Size = new System.Drawing.Size(72, 17);
            this.lblCatName.Text = "Название:";

            this.txtCatName.Location = new System.Drawing.Point(120, 22);
            this.txtCatName.Name = "txtCatName";
            this.txtCatName.Size = new System.Drawing.Size(300, 23);
            this.txtCatName.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));

            this.lblCatDesc.AutoSize = true;
            this.lblCatDesc.Location = new System.Drawing.Point(20, 65);
            this.lblCatDesc.Name = "lblCatDesc";
            this.lblCatDesc.Size = new System.Drawing.Size(72, 17);
            this.lblCatDesc.Text = "Описание:";

            this.txtCatDesc.Location = new System.Drawing.Point(120, 62);
            this.txtCatDesc.Name = "txtCatDesc";
            this.txtCatDesc.Size = new System.Drawing.Size(500, 23);
            this.txtCatDesc.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.btnCatAdd.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatAdd.Location = new System.Drawing.Point(620, 15);
            this.btnCatAdd.Name = "btnCatAdd";
            this.btnCatAdd.Size = new System.Drawing.Size(160, 40);
            this.btnCatAdd.TabIndex = 4;
            this.btnCatAdd.Text = "Добавить";
            this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);

            this.btnCatEdit.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCatEdit.Location = new System.Drawing.Point(790, 15);
            this.btnCatEdit.Name = "btnCatEdit";
            this.btnCatEdit.Size = new System.Drawing.Size(160, 40);
            this.btnCatEdit.TabIndex = 5;
            this.btnCatEdit.Text = "Изменить";
            this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);

            this.lblCatHint.AutoSize = true;
            this.lblCatHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCatHint.Location = new System.Drawing.Point(20, 100);
            this.lblCatHint.Name = "lblCatHint";
            this.lblCatHint.Size = new System.Drawing.Size(280, 17);
            this.lblCatHint.Text = "Для удаления дважды щёлкните по строке";

            // ============== tabCustomers ==============
            this.tabCustomers.BackColor = System.Drawing.Color.White;
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustEdit);
            this.tabCustomers.Location = new System.Drawing.Point(4, 26);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(952, 500);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Клиенты";

            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 32;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            this.panelCustEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCustEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCustEdit.Height = 130;
            this.panelCustEdit.Controls.Add(this.lblCustName);
            this.panelCustEdit.Controls.Add(this.txtCustName);
            this.panelCustEdit.Controls.Add(this.lblCustPhone);
            this.panelCustEdit.Controls.Add(this.mtxtCustPhone);
            this.panelCustEdit.Controls.Add(this.btnCustAdd);
            this.panelCustEdit.Controls.Add(this.btnCustEdit);
            this.panelCustEdit.Controls.Add(this.lblCustHint);
            this.panelCustEdit.Name = "panelCustEdit";
            this.panelCustEdit.TabIndex = 1;

            this.lblCustName.AutoSize = true;
            this.lblCustName.Location = new System.Drawing.Point(20, 25);
            this.lblCustName.Size = new System.Drawing.Size(39, 17);
            this.lblCustName.Text = "ФИО:";

            this.txtCustName.Location = new System.Drawing.Point(120, 22);
            this.txtCustName.Size = new System.Drawing.Size(300, 23);
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));

            this.lblCustPhone.AutoSize = true;
            this.lblCustPhone.Location = new System.Drawing.Point(20, 65);
            this.lblCustPhone.Size = new System.Drawing.Size(64, 17);
            this.lblCustPhone.Text = "Телефон:";

            this.mtxtCustPhone.Location = new System.Drawing.Point(120, 62);
            this.mtxtCustPhone.Mask = "+7 (000) 000-00-00";
            this.mtxtCustPhone.Size = new System.Drawing.Size(200, 23);

            this.btnCustAdd.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustAdd.Location = new System.Drawing.Point(620, 15);
            this.btnCustAdd.Size = new System.Drawing.Size(160, 40);
            this.btnCustAdd.Text = "Добавить";
            this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);

            this.btnCustEdit.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustEdit.Location = new System.Drawing.Point(790, 15);
            this.btnCustEdit.Size = new System.Drawing.Size(160, 40);
            this.btnCustEdit.Text = "Изменить";
            this.btnCustEdit.Click += new System.EventHandler(this.btnCustEdit_Click);

            this.lblCustHint.AutoSize = true;
            this.lblCustHint.ForeColor = System.Drawing.Color.Gray;
            this.lblCustHint.Location = new System.Drawing.Point(20, 100);
            this.lblCustHint.Size = new System.Drawing.Size(280, 17);
            this.lblCustHint.Text = "Для удаления дважды щёлкните по строке";

            // ============== tabStatuses ==============
            this.tabStatuses.BackColor = System.Drawing.Color.White;
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Controls.Add(this.lblStatusInfo);
            this.tabStatuses.Location = new System.Drawing.Point(4, 26);
            this.tabStatuses.Name = "tabStatuses";
            this.tabStatuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuses.Size = new System.Drawing.Size(952, 500);
            this.tabStatuses.TabIndex = 2;
            this.tabStatuses.Text = "Статусы";

            this.lblStatusInfo.AutoSize = true;
            this.lblStatusInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblStatusInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatusInfo.Height = 35;
            this.lblStatusInfo.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.lblStatusInfo.Text = "Статусы фиксированные: Новый, Не готов, Готов, Отменён";
            this.lblStatusInfo.Name = "lblStatusInfo";

            this.dgvStatuses.AllowUserToAddRows = false;
            this.dgvStatuses.AllowUserToDeleteRows = false;
            this.dgvStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatuses.ReadOnly = true;
            this.dgvStatuses.RowHeadersVisible = false;
            this.dgvStatuses.RowTemplate.Height = 32;
            this.dgvStatuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatuses.Name = "dgvStatuses";
            this.dgvStatuses.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // ============== btnBack ==============
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(800, 600);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ============== ПОДПИСКИ ==============
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);

            // ============== Форма ==============
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 665);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(1000, 665);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "CatalogsForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
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