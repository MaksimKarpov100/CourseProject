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
            this.tabCatalogs = new System.Windows.Forms.TabControl();

            // Категории
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.panelCatTop = new System.Windows.Forms.Panel();
            this.txtSearchCat = new System.Windows.Forms.TextBox();
            this.cmbSortCat = new System.Windows.Forms.ComboBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panelCatBottom = new System.Windows.Forms.Panel();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.btnCatDelete = new System.Windows.Forms.Button();

            // Клиенты
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.panelCustTop = new System.Windows.Forms.Panel();
            this.txtSearchCust = new System.Windows.Forms.TextBox();
            this.cmbSortCust = new System.Windows.Forms.ComboBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelCustBottom = new System.Windows.Forms.Panel();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.btnCustEdit = new System.Windows.Forms.Button();
            this.btnCustDelete = new System.Windows.Forms.Button();

            // Статусы
            this.tabStatuses = new System.Windows.Forms.TabPage();
            this.dgvStatuses = new System.Windows.Forms.DataGridView();

            this.tabCatalogs.SuspendLayout();
            this.tabCategories.SuspendLayout();
            this.panelCatTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelCatBottom.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            this.panelCustTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelCustBottom.SuspendLayout();
            this.tabStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.Text = "Справочники";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // tabCatalogs
            this.tabCatalogs.Controls.Add(this.tabCategories);
            this.tabCatalogs.Controls.Add(this.tabCustomers);
            this.tabCatalogs.Controls.Add(this.tabStatuses);
            this.tabCatalogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCatalogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabCatalogs.Location = new System.Drawing.Point(0, 40);
            this.tabCatalogs.Size = new System.Drawing.Size(900, 660);

            // --- ВКЛАДКА КАТЕГОРИИ ---
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatTop);
            this.tabCategories.Controls.Add(this.panelCatBottom);
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Text = "Категории";

            // panelCatTop
            this.panelCatTop.Controls.Add(this.txtSearchCat);
            this.panelCatTop.Controls.Add(this.cmbSortCat);
            this.panelCatTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCatTop.Location = new System.Drawing.Point(3, 3);
            this.panelCatTop.Size = new System.Drawing.Size(890, 50);

            // txtSearchCat
            this.txtSearchCat.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCat.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCat.Text = "Поиск...";
            this.txtSearchCat.TextChanged += new System.EventHandler(this.txtSearchCat_TextChanged);

            // cmbSortCat
            this.cmbSortCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortCat.Location = new System.Drawing.Point(320, 10);
            this.cmbSortCat.Size = new System.Drawing.Size(200, 25);
            this.cmbSortCat.Items.AddRange(new object[] { "По названию (А-Я)", "По названию (Я-А)" });
            this.cmbSortCat.SelectedIndex = 0;
            this.cmbSortCat.SelectedIndexChanged += new System.EventHandler(this.cmbSortCat_SelectedIndexChanged);

            // dgvCategories
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);

            // panelCatBottom
            this.panelCatBottom.Controls.Add(this.btnCatAdd);
            this.panelCatBottom.Controls.Add(this.btnCatEdit);
            this.panelCatBottom.Controls.Add(this.btnCatDelete);
            this.panelCatBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCatBottom.Location = new System.Drawing.Point(3, 597);
            this.panelCatBottom.Size = new System.Drawing.Size(890, 60);

            this.btnCatAdd.BackColor = System.Drawing.Color.SeaGreen; this.btnCatAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCatAdd.ForeColor = System.Drawing.Color.White; this.btnCatAdd.Location = new System.Drawing.Point(10, 10); this.btnCatAdd.Size = new System.Drawing.Size(150, 40); this.btnCatAdd.Text = "Добавить"; this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);
            this.btnCatEdit.BackColor = System.Drawing.Color.SteelBlue; this.btnCatEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCatEdit.ForeColor = System.Drawing.Color.White; this.btnCatEdit.Location = new System.Drawing.Point(170, 10); this.btnCatEdit.Size = new System.Drawing.Size(150, 40); this.btnCatEdit.Text = "Изменить"; this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);
            this.btnCatDelete.BackColor = System.Drawing.Color.Firebrick; this.btnCatDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCatDelete.ForeColor = System.Drawing.Color.White; this.btnCatDelete.Location = new System.Drawing.Point(330, 10); this.btnCatDelete.Size = new System.Drawing.Size(150, 40); this.btnCatDelete.Text = "Удалить"; this.btnCatDelete.Click += new System.EventHandler(this.btnCatDelete_Click);

            // --- ВКЛАДКА КЛИЕНТЫ ---
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustTop);
            this.tabCustomers.Controls.Add(this.panelCustBottom);
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Text = "Клиенты";

            // panelCustTop
            this.panelCustTop.Controls.Add(this.txtSearchCust);
            this.panelCustTop.Controls.Add(this.cmbSortCust);
            this.panelCustTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustTop.Location = new System.Drawing.Point(3, 3);
            this.panelCustTop.Size = new System.Drawing.Size(890, 50);

            // txtSearchCust
            this.txtSearchCust.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCust.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCust.Text = "Поиск...";
            this.txtSearchCust.TextChanged += new System.EventHandler(this.txtSearchCust_TextChanged);

            // cmbSortCust
            this.cmbSortCust.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortCust.Location = new System.Drawing.Point(320, 10);
            this.cmbSortCust.Size = new System.Drawing.Size(200, 25);
            this.cmbSortCust.Items.AddRange(new object[] { "По ФИО (А-Я)", "По ФИО (Я-А)" });
            this.cmbSortCust.SelectedIndex = 0;
            this.cmbSortCust.SelectedIndexChanged += new System.EventHandler(this.cmbSortCust_SelectedIndexChanged);

            // dgvCustomers
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);

            // panelCustBottom
            this.panelCustBottom.Controls.Add(this.btnCustAdd);
            this.panelCustBottom.Controls.Add(this.btnCustEdit);
            this.panelCustBottom.Controls.Add(this.btnCustDelete);
            this.panelCustBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCustBottom.Location = new System.Drawing.Point(3, 597);
            this.panelCustBottom.Size = new System.Drawing.Size(890, 60);

            this.btnCustAdd.BackColor = System.Drawing.Color.SeaGreen; this.btnCustAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCustAdd.ForeColor = System.Drawing.Color.White; this.btnCustAdd.Location = new System.Drawing.Point(10, 10); this.btnCustAdd.Size = new System.Drawing.Size(150, 40); this.btnCustAdd.Text = "Добавить"; this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);
            this.btnCustEdit.BackColor = System.Drawing.Color.SteelBlue; this.btnCustEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCustEdit.ForeColor = System.Drawing.Color.White; this.btnCustEdit.Location = new System.Drawing.Point(170, 10); this.btnCustEdit.Size = new System.Drawing.Size(150, 40); this.btnCustEdit.Text = "Изменить"; this.btnCustEdit.Click += new System.EventHandler(this.btnCustEdit_Click);
            this.btnCustDelete.BackColor = System.Drawing.Color.Firebrick; this.btnCustDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat; this.btnCustDelete.ForeColor = System.Drawing.Color.White; this.btnCustDelete.Location = new System.Drawing.Point(330, 10); this.btnCustDelete.Size = new System.Drawing.Size(150, 40); this.btnCustDelete.Text = "Удалить"; this.btnCustDelete.Click += new System.EventHandler(this.btnCustDelete_Click);

            // --- ВКЛАДКА СТАТУСЫ ---
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuses.Text = "Статусы";

            // dgvStatuses
            this.dgvStatuses.AllowUserToAddRows = false;
            this.dgvStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatuses.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatuses.RowHeadersVisible = false;

            // CatalogsForm
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblTitle);
            this.Load += new System.EventHandler(this.CatalogsForm_Load);

            this.tabCatalogs.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.panelCatTop.ResumeLayout(false);
            this.panelCatTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelCatBottom.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            this.panelCustTop.ResumeLayout(false);
            this.panelCustTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
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