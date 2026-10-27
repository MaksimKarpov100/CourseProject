namespace BoardGame_Store
{
    partial class CatalogsForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabCatalogs = new System.Windows.Forms.TabControl();
            this.tabCategories = new System.Windows.Forms.TabPage();
            this.txtSearchCat = new System.Windows.Forms.TextBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panelCatButtons = new System.Windows.Forms.Panel();
            this.btnCatPrev = new System.Windows.Forms.Button();
            this.lblPageCat = new System.Windows.Forms.Label();
            this.btnCatNext = new System.Windows.Forms.Button();
            this.btnCatDelete = new System.Windows.Forms.Button();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.txtSearchCust = new System.Windows.Forms.TextBox();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelCustButtons = new System.Windows.Forms.Panel();
            this.btnCustPrev = new System.Windows.Forms.Button();
            this.lblPageCust = new System.Windows.Forms.Label();
            this.btnCustNext = new System.Windows.Forms.Button();
            this.btnCustDelete = new System.Windows.Forms.Button();
            this.btnCustEdit = new System.Windows.Forms.Button();
            this.btnCustAdd = new System.Windows.Forms.Button();
            this.tabStatuses = new System.Windows.Forms.TabPage();
            this.dgvStatuses = new System.Windows.Forms.DataGridView();
            this.tabCatalogs.SuspendLayout();
            this.tabCategories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelCatButtons.SuspendLayout();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panelCustButtons.SuspendLayout();
            this.tabStatuses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
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
            this.tabCatalogs.Size = new System.Drawing.Size(900, 660);
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.txtSearchCat);
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatButtons);
            this.tabCategories.Padding = new System.Windows.Forms.Padding(3);
            this.tabCategories.Text = "Категории";
            // 
            // txtSearchCat
            // 
            this.txtSearchCat.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCat.Name = "txtSearchCat";
            this.txtSearchCat.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCat.Text = "Поиск...";
            this.txtSearchCat.TextChanged += new System.EventHandler(this.txtSearchCat_TextChanged);
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White; // БЕЛЫЙ ФОН
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None; // БЕЗ РАМОК
            this.dgvCategories.RowHeadersVisible = false; // БЕЗ СЕРЫХ КОЛОНОК СЛЕВА
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Location = new System.Drawing.Point(10, 45);
            this.dgvCategories.Size = new System.Drawing.Size(872, 520);
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            // 
            // panelCatButtons
            // 
            this.panelCatButtons.Controls.Add(this.btnCatPrev);
            this.panelCatButtons.Controls.Add(this.lblPageCat);
            this.panelCatButtons.Controls.Add(this.btnCatNext);
            this.panelCatButtons.Controls.Add(this.btnCatDelete);
            this.panelCatButtons.Controls.Add(this.btnCatEdit);
            this.panelCatButtons.Controls.Add(this.btnCatAdd);
            this.panelCatButtons.Location = new System.Drawing.Point(10, 570);
            this.panelCatButtons.Size = new System.Drawing.Size(872, 50);
            // 
            // btnCatAdd
            // 
            this.btnCatAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCatAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatAdd.ForeColor = System.Drawing.Color.White;
            this.btnCatAdd.Location = new System.Drawing.Point(0, 5); this.btnCatAdd.Size = new System.Drawing.Size(150, 40);
            this.btnCatAdd.Text = "Добавить"; this.btnCatAdd.Click += new System.EventHandler(this.btnCatAdd_Click);
            // 
            // btnCatEdit
            // 
            this.btnCatEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCatEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatEdit.ForeColor = System.Drawing.Color.White;
            this.btnCatEdit.Location = new System.Drawing.Point(160, 5); this.btnCatEdit.Size = new System.Drawing.Size(150, 40);
            this.btnCatEdit.Text = "Изменить"; this.btnCatEdit.Click += new System.EventHandler(this.btnCatEdit_Click);
            // 
            // btnCatDelete
            // 
            this.btnCatDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnCatDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatDelete.ForeColor = System.Drawing.Color.White;
            this.btnCatDelete.Location = new System.Drawing.Point(320, 5); this.btnCatDelete.Size = new System.Drawing.Size(150, 40);
            this.btnCatDelete.Text = "Удалить"; this.btnCatDelete.Click += new System.EventHandler(this.btnCatDelete_Click);
            // 
            // btnCatPrev
            // 
            this.btnCatPrev.Location = new System.Drawing.Point(550, 10); this.btnCatPrev.Size = new System.Drawing.Size(40, 30);
            this.btnCatPrev.Text = "<"; this.btnCatPrev.Click += new System.EventHandler(this.btnCatPrev_Click);
            // 
            // lblPageCat
            // 
            this.lblPageCat.Location = new System.Drawing.Point(600, 15); this.lblPageCat.AutoSize = true; this.lblPageCat.Text = "Страница 1";
            // 
            // btnCatNext
            // 
            this.btnCatNext.Location = new System.Drawing.Point(700, 10); this.btnCatNext.Size = new System.Drawing.Size(40, 30);
            this.btnCatNext.Text = ">"; this.btnCatNext.Click += new System.EventHandler(this.btnCatNext_Click);
            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.txtSearchCust);
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustButtons);
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Text = "Клиенты";
            // 
            // txtSearchCust
            // 
            this.txtSearchCust.Location = new System.Drawing.Point(10, 10);
            this.txtSearchCust.Size = new System.Drawing.Size(300, 25);
            this.txtSearchCust.Text = "Поиск...";
            this.txtSearchCust.TextChanged += new System.EventHandler(this.txtSearchCust_TextChanged);
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Location = new System.Drawing.Point(10, 45);
            this.dgvCustomers.Size = new System.Drawing.Size(872, 520);
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            // 
            // panelCustButtons
            // 
            this.panelCustButtons.Controls.Add(this.btnCustPrev);
            this.panelCustButtons.Controls.Add(this.lblPageCust);
            this.panelCustButtons.Controls.Add(this.btnCustNext);
            this.panelCustButtons.Controls.Add(this.btnCustDelete);
            this.panelCustButtons.Controls.Add(this.btnCustEdit);
            this.panelCustButtons.Controls.Add(this.btnCustAdd);
            this.panelCustButtons.Location = new System.Drawing.Point(10, 570);
            this.panelCustButtons.Size = new System.Drawing.Size(872, 50);
            // 
            // btnCustAdd
            // 
            this.btnCustAdd.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCustAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustAdd.ForeColor = System.Drawing.Color.White;
            this.btnCustAdd.Location = new System.Drawing.Point(0, 5); this.btnCustAdd.Size = new System.Drawing.Size(150, 40);
            this.btnCustAdd.Text = "Добавить"; this.btnCustAdd.Click += new System.EventHandler(this.btnCustAdd_Click);
            // 
            // btnCustEdit
            // 
            this.btnCustEdit.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCustEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustEdit.ForeColor = System.Drawing.Color.White;
            this.btnCustEdit.Location = new System.Drawing.Point(160, 5); this.btnCustEdit.Size = new System.Drawing.Size(150, 40);
            this.btnCustEdit.Text = "Изменить"; this.btnCustEdit.Click += new System.EventHandler(this.btnCustEdit_Click);
            // 
            // btnCustDelete
            // 
            this.btnCustDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnCustDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustDelete.ForeColor = System.Drawing.Color.White;
            this.btnCustDelete.Location = new System.Drawing.Point(320, 5); this.btnCustDelete.Size = new System.Drawing.Size(150, 40);
            this.btnCustDelete.Text = "Удалить"; this.btnCustDelete.Click += new System.EventHandler(this.btnCustDelete_Click);
            // 
            // btnCustPrev
            // 
            this.btnCustPrev.Location = new System.Drawing.Point(550, 10); this.btnCustPrev.Size = new System.Drawing.Size(40, 30);
            this.btnCustPrev.Text = "<"; this.btnCustPrev.Click += new System.EventHandler(this.btnCustPrev_Click);
            // 
            // lblPageCust
            // 
            this.lblPageCust.Location = new System.Drawing.Point(600, 15); this.lblPageCust.AutoSize = true; this.lblPageCust.Text = "Страница 1";
            // 
            // btnCustNext
            // 
            this.btnCustNext.Location = new System.Drawing.Point(700, 10); this.btnCustNext.Size = new System.Drawing.Size(40, 30);
            this.btnCustNext.Text = ">"; this.btnCustNext.Click += new System.EventHandler(this.btnCustNext_Click);
            // 
            // tabStatuses
            // 
            this.tabStatuses.Controls.Add(this.dgvStatuses);
            this.tabStatuses.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatuses.Text = "Статусы";
            // 
            // dgvStatuses
            // 
            this.dgvStatuses.AllowUserToAddRows = false;
            this.dgvStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatuses.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatuses.RowHeadersVisible = false;
            this.dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // CatalogsForm
            // 
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblTitle);
            this.Load += new System.EventHandler(this.CatalogsForm_Load);
            this.tabCatalogs.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            this.tabCategories.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelCatButtons.ResumeLayout(false);
            this.panelCatButtons.PerformLayout();
            this.tabCustomers.ResumeLayout(false);
            this.tabCustomers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelCustButtons.ResumeLayout(false);
            this.panelCustButtons.PerformLayout();
            this.tabStatuses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabCatalogs;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TextBox txtSearchCat;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panelCatButtons;
        private System.Windows.Forms.Button btnCatAdd;
        private System.Windows.Forms.Button btnCatEdit;
        private System.Windows.Forms.Button btnCatDelete;
        private System.Windows.Forms.Button btnCatPrev;
        private System.Windows.Forms.Label lblPageCat;
        private System.Windows.Forms.Button btnCatNext;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.TextBox txtSearchCust;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelCustButtons;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustEdit;
        private System.Windows.Forms.Button btnCustDelete;
        private System.Windows.Forms.Button btnCustPrev;
        private System.Windows.Forms.Label lblPageCust;
        private System.Windows.Forms.Button btnCustNext;
        private System.Windows.Forms.TabPage tabStatuses;
        private System.Windows.Forms.DataGridView dgvStatuses;
    }
}