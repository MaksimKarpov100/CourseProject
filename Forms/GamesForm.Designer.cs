namespace BoardGame_Store
{
    partial class GamesForm
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
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.dgvGames = new System.Windows.Forms.DataGridView();
            this.Фото = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.txtGameTitle = new System.Windows.Forms.TextBox();
            this.lblGameCategory = new System.Windows.Forms.Label();
            this.cmbGameCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnImageAdd = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(258, 26);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "Управление товарами";
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblCategory);
            this.panelFilters.Controls.Add(this.cmbCategory);
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Location = new System.Drawing.Point(15, 50);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(891, 60);
            this.panelFilters.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 20);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(52, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Text = "Поиск...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(310, 20);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 17);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(395, 17);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 24);
            this.cmbCategory.TabIndex = 3;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(595, 20);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(97, 17);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Сортировать:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] {
            "По названию",
            "По цене",
            "По остатку"});
            this.cmbSort.Location = new System.Drawing.Point(715, 17);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(160, 24);
            this.cmbSort.TabIndex = 5;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // dgvGames
            // 
            this.dgvGames.AllowUserToAddRows = false;
            this.dgvGames.AllowUserToDeleteRows = false;
            this.dgvGames.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Фото});
            this.dgvGames.Location = new System.Drawing.Point(15, 120);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            this.dgvGames.RowHeadersVisible = false;
            this.dgvGames.RowTemplate.Height = 90;
            this.dgvGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGames.Size = new System.Drawing.Size(891, 320);
            this.dgvGames.TabIndex = 7;
            this.dgvGames.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGames_CellDoubleClick);
            this.dgvGames.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGames_CellFormatting);
            this.dgvGames.SelectionChanged += new System.EventHandler(this.dgvGames_SelectionChanged);
            // 
            // Фото
            // 
            this.Фото.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Фото.HeaderText = "Фото";
            this.Фото.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Фото.Name = "Фото";
            this.Фото.ReadOnly = true;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 450);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(80, 17);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Записей: 0";
            // 
            // panelPagination
            // 
            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cmbPageSize);
            this.panelPagination.Location = new System.Drawing.Point(15, 475);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(891, 40);
            this.panelPagination.TabIndex = 5;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(300, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(45, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(350, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(45, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(410, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(115, 17);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(540, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(45, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(590, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(45, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(660, 12);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(68, 17);
            this.lblPageSize.TabIndex = 5;
            this.lblPageSize.Text = "Записей:";
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "25",
            "50",
            "100"});
            this.cmbPageSize.Location = new System.Drawing.Point(730, 8);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);
            this.cmbPageSize.TabIndex = 6;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.lblGameTitle);
            this.panelEdit.Controls.Add(this.txtGameTitle);
            this.panelEdit.Controls.Add(this.lblGameCategory);
            this.panelEdit.Controls.Add(this.cmbGameCategory);
            this.panelEdit.Controls.Add(this.lblPrice);
            this.panelEdit.Controls.Add(this.txtPrice);
            this.panelEdit.Controls.Add(this.lblStock);
            this.panelEdit.Controls.Add(this.nudStock);
            this.panelEdit.Controls.Add(this.lblDescription);
            this.panelEdit.Controls.Add(this.txtDescription);
            this.panelEdit.Controls.Add(this.btnImageAdd);
            this.panelEdit.Controls.Add(this.pbPreview);
            this.panelEdit.Location = new System.Drawing.Point(15, 525);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(891, 209);
            this.panelEdit.TabIndex = 4;
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Location = new System.Drawing.Point(10, 15);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(76, 17);
            this.lblGameTitle.TabIndex = 0;
            this.lblGameTitle.Text = "Название:";
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Location = new System.Drawing.Point(100, 12);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(280, 23);
            this.txtGameTitle.TabIndex = 1;
            // 
            // lblGameCategory
            // 
            this.lblGameCategory.AutoSize = true;
            this.lblGameCategory.Location = new System.Drawing.Point(400, 15);
            this.lblGameCategory.Name = "lblGameCategory";
            this.lblGameCategory.Size = new System.Drawing.Size(81, 17);
            this.lblGameCategory.TabIndex = 2;
            this.lblGameCategory.Text = "Категория:";
            // 
            // cmbGameCategory
            // 
            this.cmbGameCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameCategory.Location = new System.Drawing.Point(490, 12);
            this.cmbGameCategory.Name = "cmbGameCategory";
            this.cmbGameCategory.Size = new System.Drawing.Size(180, 24);
            this.cmbGameCategory.TabIndex = 3;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(10, 55);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(47, 17);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "Цена:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(100, 52);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 5;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(220, 55);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(67, 17);
            this.lblStock.TabIndex = 6;
            this.lblStock.Text = "Остаток:";
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(300, 52);
            this.nudStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(80, 23);
            this.nudStock.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 95);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 17);
            this.lblDescription.TabIndex = 8;
            this.lblDescription.Text = "Описание:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 92);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(570, 23);
            this.txtDescription.TabIndex = 9;
            // 
            // btnImageAdd
            // 
            this.btnImageAdd.Location = new System.Drawing.Point(736, 144);
            this.btnImageAdd.Name = "btnImageAdd";
            this.btnImageAdd.Size = new System.Drawing.Size(152, 35);
            this.btnImageAdd.TabIndex = 10;
            this.btnImageAdd.Text = "Загрузить картинку";
            this.btnImageAdd.Click += new System.EventHandler(this.btnImageAdd_Click);
            // 
            // pbPreview
            // 
            this.pbPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreview.Location = new System.Drawing.Point(736, 7);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(152, 131);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 11;
            this.pbPreview.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 740);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 42);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(182, 740);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(160, 42);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(787, 740);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(116, 42);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(357, 753);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(294, 17);
            this.lblHint.TabIndex = 0;
            this.lblHint.Text = "Для удаления дважды щёлкните по строке";
            // 
            // GamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 794);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvGames);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GamesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Управление товарами";
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.DataGridView dgvGames;
        private System.Windows.Forms.DataGridViewImageColumn colPhoto;
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
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.TextBox txtGameTitle;
        private System.Windows.Forms.Label lblGameCategory;
        private System.Windows.Forms.ComboBox cmbGameCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnImageAdd;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.DataGridViewImageColumn Фото;
    }
}