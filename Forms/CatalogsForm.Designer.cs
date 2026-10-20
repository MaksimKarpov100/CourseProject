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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.panelCatButtons = new System.Windows.Forms.Panel();
            this.btnCatDelete = new System.Windows.Forms.Button();
            this.btnCatEdit = new System.Windows.Forms.Button();
            this.btnCatAdd = new System.Windows.Forms.Button();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.panelCustButtons = new System.Windows.Forms.Panel();
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
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.TabIndex = 0;
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
            this.tabCatalogs.TabIndex = 1;
            // 
            // tabCategories
            // 
            this.tabCategories.Controls.Add(this.dgvCategories);
            this.tabCategories.Controls.Add(this.panelCatButtons);
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
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(3, 3);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(886, 564);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellDoubleClick);
            // 
            // panelCatButtons
            // 
            this.panelCatButtons.Controls.Add(this.btnCatDelete);
            this.panelCatButtons.Controls.Add(this.btnCatEdit);
            this.panelCatButtons.Controls.Add(this.btnCatAdd);
            this.panelCatButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCatButtons.Location = new System.Drawing.Point(3, 567);
            this.panelCatButtons.Name = "panelCatButtons";
            this.panelCatButtons.Size = new System.Drawing.Size(886, 60);
            this.panelCatButtons.TabIndex = 1;
            // 
            // btnCatDelete
            // 
            this.btnCatDelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // btnCatEdit
            // 
            this.btnCatEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // btnCatAdd
            // 
            this.btnCatAdd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.dgvCustomers);
            this.tabCustomers.Controls.Add(this.panelCustButtons);
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
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(886, 564);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellDoubleClick);
            // 
            // panelCustButtons
            // 
            this.panelCustButtons.Controls.Add(this.btnCustDelete);
            this.panelCustButtons.Controls.Add(this.btnCustEdit);
            this.panelCustButtons.Controls.Add(this.btnCustAdd);
            this.panelCustButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelCustButtons.Location = new System.Drawing.Point(3, 567);
            this.panelCustButtons.Name = "panelCustButtons";
            this.panelCustButtons.Size = new System.Drawing.Size(886, 60);
            this.panelCustButtons.TabIndex = 1;
            // 
            // btnCustDelete
            // 
            this.btnCustDelete.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // btnCustEdit
            // 
            this.btnCustEdit.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            // btnCustAdd
            // 
            this.btnCustAdd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
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
            this.dgvStatuses.AllowUserToDeleteRows = false;
            this.dgvStatuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatuses.BackgroundColor = System.Drawing.Color.White;
            this.dgvStatuses.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStatuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatuses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStatuses.Location = new System.Drawing.Point(3, 3);
            this.dgvStatuses.Name = "dgvStatuses";
            this.dgvStatuses.ReadOnly = true;
            this.dgvStatuses.RowHeadersVisible = false;
            this.dgvStatuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatuses.Size = new System.Drawing.Size(886, 624);
            this.dgvStatuses.TabIndex = 0;
            // 
            // CatalogsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.tabCatalogs);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "CatalogsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справочники";
            this.Load += new System.EventHandler(this.CatalogsForm_Load);
            this.tabCatalogs.ResumeLayout(false);
            this.tabCategories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelCatButtons.ResumeLayout(false);
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panelCustButtons.ResumeLayout(false);
            this.tabStatuses.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatuses)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabCatalogs;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel panelCatButtons;
        private System.Windows.Forms.Button btnCatAdd;
        private System.Windows.Forms.Button btnCatEdit;
        private System.Windows.Forms.Button btnCatDelete;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel panelCustButtons;
        private System.Windows.Forms.Button btnCustAdd;
        private System.Windows.Forms.Button btnCustEdit;
        private System.Windows.Forms.Button btnCustDelete;
        private System.Windows.Forms.TabPage tabStatuses;
        private System.Windows.Forms.DataGridView dgvStatuses;
    }
}