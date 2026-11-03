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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogsForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabCatalogs = new System.Windows.Forms.TabControl();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panelCatTop = new System.Windows.Forms.Panel();
            this.txtSearchCat = new System.Windows.Forms.TextBox();
            this.cmbSortCat = new System.Windows.Forms.ComboBox();
            this.panelCatBottom = new System.Windows.Forms.Panel();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.btnCatDelete = new System.Windows.Forms.Button();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelCustTop = new System.Windows.Forms.Panel();
            this.txtSearchCust = new System.Windows.Forms.TextBox();
            this.cmbSortCust = new System.Windows.Forms.ComboBox();
            this.panelCustBottom = new System.Windows.Forms.Panel();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.btnCustEdit = new System.Windows.Forms.Button();
            this.btnCustDelete = new System.Windows.Forms.Button();
            this.tabStatuses = new System.Windows.Forms.TabPage();
            this.dgvStatuses = new System.Windows.Forms.DataGridView();
            this.tabCatalogs.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelCatTop.SuspendLayout();
            this.panelCatBottom.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelCustTop.SuspendLayout();
            this.panelCustBottom.SuspendLayout();
            this.tabStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Справочники";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabCatalogs
            // 
            this.tabCatalogs.Controls.Add(this.tabCategories);
            this.tabCatalogs.Controls.Add(this.tabCustomers);
            this.tabCatalogs.Controls.Add(this.tabStatuses);
            this.tabCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCatalogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabCatalogs.Location = new System.Drawing.Point(0, 40);
            this.tabCatalogs.Name = "tabCatalogs";
            this.tabCatalogs.SelectedIndex = 0;
            this.tabCatalogs.Size = new System.Drawing.Size(900, 660);
            this.tabCatalogs.TabIndex = 0;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatTop);
            this.tabCategories.Controls.Add(this.panelCatBottom);
            this.tabCategories.Location = new System.Drawing.Point(4, 26);
            this.tabCategories.Name = "tabCategories";
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Size = new System.Drawing.Size(892, 630);
            this.tabCategories.TabIndex = 0;
            this.tabCategories.Text = "Категории";
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(3, 53);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(886, 514);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            // 
            // panelCatTop
            // 
            this.panelCatTop.Controls.Add(this.txtSearchCat);
            this.panelCatTop.Controls.Add(this.cmbSortCat);
            this.panelCatTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCatTop.Location = new System.Drawing.Point(3, 3);
            this.panelCatTop.Name = "panelCatTop";
            this.panelCatTop.Size = new System.Drawing.Size(886, 50);
            this.panelCatTop.TabIndex = 1;
            // 
            // txtSearchCat
            // 
            this.txtSearchCat.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCat.Name = "txtSearchCat";
            this.txtSearchCat.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCat.TabIndex = 0;
            this.txtSearchCat.Text = "Поиск...";
            this.txtSearchCat.TextChanged += new System.EventHandler(this.txtSearchCat_TextChanged);
            // 
            // cmbSortCat
            // 
            this.cmbSortCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortCat.Items.AddRange(new object[] {
            "По названию (А-Я)",
            "По названию (Я-А)"});
            this.cmbSortCat.Location = new System.Drawing.Point(320, 10);
            this.cmbSortCat.Name = "cmbSortCat";
            this.cmbSortCat.Size = new System.Drawing.Size(200, 25);
            this.cmbSortCat.TabIndex = 1;
            this.cmbSortCat.SelectedIndexChanged += new System.EventHandler(this.cmbSortCat_SelectedIndexChanged);
            // 
            // panelCatBottom
            // 
            this.panelCatBottom.Controls.Add(this.btnCatAdd);
            this.panelCatBottom.Controls.Add(this.btnCatEdit);
            this.panelCatBottom.Controls.Add(this.btnCatDelete);
            this.panelCatBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCatBottom.Location = new System.Drawing.Point(3, 567);
            this.panelCatBottom.Name = "panelCatBottom";
            this.panelCatBottom.Size = new System.Drawing.Size(886, 60);
            this.panelCatBottom.TabIndex = 2;
            // 
            // btnCatAdd
            // 
            this.btnCatAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCatAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatAdd.ForeColor = System.Drawing.Color.White;
            this.btnCatAdd.Location = new System.Drawing.Point(10, 10);
            this.btnCatAdd.Name = "btnCatAdd";
            this.btnCatAdd.Size = new System.Drawing.Size(150, 40);
            this.btnCatAdd.TabIndex = 0;
            this.btnCatAdd.Text = "Добавить";
            this.btnCatAdd.UseVisualStyleBackColor = false;
            this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);
            // 
            // btnCatEdit
            // 
            this.btnCatEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCatEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatEdit.ForeColor = System.Drawing.Color.White;
            this.btnCatEdit.Location = new System.Drawing.Point(170, 10);
            this.btnCatEdit.Name = "btnCatEdit";
            this.btnCatEdit.Size = new System.Drawing.Size(150, 40);
            this.btnCatEdit.TabIndex = 1;
            this.btnCatEdit.Text = "Изменить";
            this.btnCatEdit.UseVisualStyleBackColor = false;
            this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);
            // 
            // btnCatDelete
            // 
            this.btnCatDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnCatDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatDelete.ForeColor = System.Drawing.Color.White;
            this.btnCatDelete.Location = new System.Drawing.Point(330, 10);
            this.btnCatDelete.Name = "btnCatDelete";
            this.btnCatDelete.Size = new System.Drawing.Size(150, 40);
            this.btnCatDelete.TabIndex = 2;
            this.btnCatDelete.Text = "Удалить";
            this.btnCatDelete.UseVisualStyleBackColor = false;
            this.btnCatDelete.Click += new System.EventHandler(this.btnCatDelete_Click);
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustTop);
            this.tabCustomers.Controls.Add(this.panelCustBottom);
            this.tabCustomers.Location = new System.Drawing.Point(4, 26);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(892, 630);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Клиенты";
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 53);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(886, 514);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            // 
            // panelCustTop
            // 
            this.panelCustTop.Controls.Add(this.txtSearchCust);
            this.panelCustTop.Controls.Add(this.cmbSortCust);
            this.panelCustTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustTop.Location = new System.Drawing.Point(3, 3);
            this.panelCustTop.Name = "panelCustTop";
            this.panelCustTop.Size = new System.Drawing.Size(886, 50);
            this.panelCustTop.TabIndex = 1;
            // 
            // txtSearchCust
            // 
            this.txtSearchCust.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCust.Name = "txtSearchCust";
            this.txtSearchCust.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCust.TabIndex = 0;
            this.txtSearchCust.Text = "Поиск...";
            this.txtSearchCust.TextChanged += new System.EventHandler(this.txtSearchCust_TextChanged);
            // 
            // cmbSortCust
            // 
            this.cmbSortCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortCust.Items.AddRange(new object[] {
            "По ФИО (А-Я)",
            "По ФИО (Я-А)"});
            this.cmbSortCust.Location = new System.Drawing.Point(320, 10);
            this.cmbSortCust.Name = "cmbSortCust";
            this.cmbSortCust.Size = new System.Drawing.Size(200, 25);
            this.cmbSortCust.TabIndex = 1;
            this.cmbSortCust.SelectedIndexChanged += new System.EventHandler(this.cmbSortCust_SelectedIndexChanged);
            // 
            // panelCustBottom
            // 
            this.panelCustBottom.Controls.Add(this.btnCustAdd);
            this.panelCustBottom.Controls.Add(this.btnCustEdit);
            this.panelCustBottom.Controls.Add(this.btnCustDelete);
            this.panelCustBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCustBottom.Location = new System.Drawing.Point(3, 567);
            this.panelCustBottom.Name = "panelCustBottom";
            this.panelCustBottom.Size = new System.Drawing.Size(886, 60);
            this.panelCustBottom.TabIndex = 2;
            // 
            // btnCustAdd
            // 
            this.btnCustAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustAdd.ForeColor = System.Drawing.Color.White;
            this.btnCustAdd.Location = new System.Drawing.Point(10, 10);
            this.btnCustAdd.Name = "btnCustAdd";
            this.btnCustAdd.Size = new System.Drawing.Size(150, 40);
            this.btnCustAdd.TabIndex = 0;
            this.btnCustAdd.Text = "Добавить";
            this.btnCustAdd.UseVisualStyleBackColor = false;
            this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);
            // 
            // btnCustEdit
            // 
            this.btnCustEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCustEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustEdit.ForeColor = System.Drawing.Color.White;
            this.btnCustEdit.Location = new System.Drawing.Point(170, 10);
            this.btnCustEdit.Name = "btnCustEdit";
            this.btnCustEdit.Size = new System.Drawing.Size(150, 40);
            this.btnCustEdit.TabIndex = 1;
            this.btnCustEdit.Text = "Изменить";
            this.btnCustEdit.UseVisualStyleBackColor = false;
            this.btnCustEdit.Click += new System.EventHandler(this.btnCustEdit_Click);
            // 
            // btnCustDelete
            // 
            this.btnCustDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnCustDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustDelete.ForeColor = System.Drawing.Color.White;
            this.btnCustDelete.Location = new System.Drawing.Point(330, 10);
            this.btnCustDelete.Name = "btnCustDelete";
            this.btnCustDelete.Size = new System.Drawing.Size(150, 40);
            this.btnCustDelete.TabIndex = 2;
            this.btnCustDelete.Text = "Удалить";
            this.btnCustDelete.UseVisualStyleBackColor = false;
            this.btnCustDelete.Click += new System.EventHandler(this.btnCustDelete_Click);
            // 
            // tabStatuses
            // 
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Location = new System.Drawing.Point(4, 26);
            this.tabStatuses.Name = "tabStatuses";
            this.tabStatuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuses.Size = new System.Drawing.Size(892, 630);
            this.tabStatuses.TabIndex = 2;
            this.tabStatuses.Text = "Статусы";
            // 
            // dgvStatuses
            // 
            this.dgvStatuses.AllowUserToAddRows = false;
            this.dgvStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatuses.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatuses.Location = new System.Drawing.Point(3, 3);
            this.dgvStatuses.Name = "dgvStatuses";
            this.dgvStatuses.RowHeadersVisible = false;
            this.dgvStatuses.Size = new System.Drawing.Size(886, 624);
            this.dgvStatuses.TabIndex = 0;
            // 
            // CatalogsForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CatalogsForm";
            this.Load += new System.EventHandler(this.CatalogsForm_Load);
            this.tabCatalogs.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelCatTop.ResumeLayout(false);
            this.panelCatTop.PerformLayout();
            this.panelCatBottom.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelCustTop.ResumeLayout(false);
            this.panelCustTop.PerformLayout();
            this.panelCustBottom.ResumeLayout(false);
            this.tabStatuses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabCatalogs;

        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.Panel panelCatTop;
        private System.Windows.Forms.TextBox txtSearchCat;
        private System.Windows.Forms.ComboBox cmbSortCat;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panelCatBottom;
        private System.Windows.Forms.Button btnCatAdd;
        private System.Windows.Forms.Button btnCatEdit;
        private System.Windows.Forms.Button btnCatDelete;

        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.Panel panelCustTop;
        private System.Windows.Forms.TextBox txtSearchCust;
        private System.Windows.Forms.ComboBox cmbSortCust;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelCustBottom;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustEdit;
        private System.Windows.Forms.Button btnCustDelete;

        private System.Windows.Forms.TabPage tabStatuses;
        private System.Windows.Forms.DataGridView dgvStatuses;
    }
}