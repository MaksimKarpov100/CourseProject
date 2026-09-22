namespace BoardGame_Store
{
    partial class GameForm
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
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvGames = new System.Windows.Forms.DataGridView();
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
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.lblPlayers = new System.Windows.Forms.Label();
            this.nudMinPlayers = new System.Windows.Forms.NumericUpDown();
            this.nudMaxPlayers = new System.Windows.Forms.NumericUpDown();
            this.lblAge = new System.Windows.Forms.Label();
            this.cmbAge = new System.Windows.Forms.ComboBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnImageAdd = new System.Windows.Forms.Button();
            this.btnImageDelete = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGames)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(300, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(258, 26);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Управление товарами";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(94, 17);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "[Роль] [ФИО]";
            // 
            // panelFilters
            // 
            this.panelFilters.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblCategory);
            this.panelFilters.Controls.Add(this.cmbCategory);
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Controls.Add(this.btnReset);
            this.panelFilters.Location = new System.Drawing.Point(15, 45);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(846, 50);
            this.panelFilters.TabIndex = 8;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(10, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(48, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(70, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 23);
            this.txtSearch.TabIndex = 1;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(290, 15);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(77, 17);
            this.lblCategory.TabIndex = 2;
            this.lblCategory.Text = "Категория";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] {
            "Все"});
            this.cmbCategory.Location = new System.Drawing.Point(370, 12);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(150, 24);
            this.cmbCategory.TabIndex = 3;
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(530, 15);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(117, 17);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Сортировать по:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Items.AddRange(new object[] {
            "По названию",
            "По цене",
            "По остатку"});
            this.cmbSort.Location = new System.Drawing.Point(650, 12);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(130, 24);
            this.cmbSort.TabIndex = 5;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(785, 10);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(0, 0);
            this.btnReset.TabIndex = 6;
            // 
            // dgvGames
            // 
            this.dgvGames.AllowUserToAddRows = false;
            this.dgvGames.AllowUserToDeleteRows = false;
            this.dgvGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGames.Location = new System.Drawing.Point(15, 105);
            this.dgvGames.Name = "dgvGames";
            this.dgvGames.ReadOnly = true;
            this.dgvGames.RowHeadersVisible = false;
            this.dgvGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGames.Size = new System.Drawing.Size(846, 170);
            this.dgvGames.TabIndex = 7;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(15, 285);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(203, 17);
            this.lblCount.TabIndex = 6;
            this.lblCount.Text = "Количество записей: [кол-во]";
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
            this.panelPagination.Location = new System.Drawing.Point(15, 305);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(846, 40);
            this.panelPagination.TabIndex = 5;
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(0, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(60, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new System.Drawing.Point(130, 12);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(115, 17);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(250, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(310, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Location = new System.Drawing.Point(400, 12);
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
            this.cmbPageSize.Location = new System.Drawing.Point(470, 8);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);
            this.cmbPageSize.TabIndex = 6;
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelEdit.Controls.Add(this.lblGameTitle);
            this.panelEdit.Controls.Add(this.txtGameTitle);
            this.panelEdit.Controls.Add(this.lblGameCategory);
            this.panelEdit.Controls.Add(this.cmbGameCategory);
            this.panelEdit.Controls.Add(this.lblDescription);
            this.panelEdit.Controls.Add(this.txtDescription);
            this.panelEdit.Controls.Add(this.lblPrice);
            this.panelEdit.Controls.Add(this.txtPrice);
            this.panelEdit.Controls.Add(this.lblStock);
            this.panelEdit.Controls.Add(this.nudStock);
            this.panelEdit.Controls.Add(this.lblPlayers);
            this.panelEdit.Controls.Add(this.nudMinPlayers);
            this.panelEdit.Controls.Add(this.nudMaxPlayers);
            this.panelEdit.Controls.Add(this.lblAge);
            this.panelEdit.Controls.Add(this.cmbAge);
            this.panelEdit.Location = new System.Drawing.Point(15, 355);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(680, 160);
            this.panelEdit.TabIndex = 4;
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Location = new System.Drawing.Point(10, 15);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(72, 17);
            this.lblGameTitle.TabIndex = 0;
            this.lblGameTitle.Text = "Название";
            // 
            // txtGameTitle
            // 
            this.txtGameTitle.Location = new System.Drawing.Point(90, 12);
            this.txtGameTitle.Name = "txtGameTitle";
            this.txtGameTitle.Size = new System.Drawing.Size(250, 23);
            this.txtGameTitle.TabIndex = 1;
            // 
            // lblGameCategory
            // 
            this.lblGameCategory.AutoSize = true;
            this.lblGameCategory.Location = new System.Drawing.Point(360, 15);
            this.lblGameCategory.Name = "lblGameCategory";
            this.lblGameCategory.Size = new System.Drawing.Size(77, 17);
            this.lblGameCategory.TabIndex = 2;
            this.lblGameCategory.Text = "Категория";
            // 
            // cmbGameCategory
            // 
            this.cmbGameCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGameCategory.Location = new System.Drawing.Point(440, 12);
            this.cmbGameCategory.Name = "cmbGameCategory";
            this.cmbGameCategory.Size = new System.Drawing.Size(160, 24);
            this.cmbGameCategory.TabIndex = 3;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(10, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(74, 17);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Описание";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(90, 52);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(510, 50);
            this.txtDescription.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(10, 120);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(43, 17);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Цена";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(90, 117);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 7;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(210, 120);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(63, 17);
            this.lblStock.TabIndex = 8;
            this.lblStock.Text = "Остаток";
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(280, 117);
            this.nudStock.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(70, 23);
            this.nudStock.TabIndex = 9;
            // 
            // lblPlayers
            // 
            this.lblPlayers.AutoSize = true;
            this.lblPlayers.Location = new System.Drawing.Point(370, 120);
            this.lblPlayers.Name = "lblPlayers";
            this.lblPlayers.Size = new System.Drawing.Size(54, 17);
            this.lblPlayers.TabIndex = 10;
            this.lblPlayers.Text = "Игроки";
            // 
            // nudMinPlayers
            // 
            this.nudMinPlayers.Location = new System.Drawing.Point(440, 117);
            this.nudMinPlayers.Name = "nudMinPlayers";
            this.nudMinPlayers.Size = new System.Drawing.Size(50, 23);
            this.nudMinPlayers.TabIndex = 11;
            // 
            // nudMaxPlayers
            // 
            this.nudMaxPlayers.Location = new System.Drawing.Point(500, 117);
            this.nudMaxPlayers.Name = "nudMaxPlayers";
            this.nudMaxPlayers.Size = new System.Drawing.Size(50, 23);
            this.nudMaxPlayers.TabIndex = 12;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(560, 120);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(44, 17);
            this.lblAge.TabIndex = 13;
            this.lblAge.Text = "Возр.";
            // 
            // cmbAge
            // 
            this.cmbAge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAge.Items.AddRange(new object[] {
            "6+",
            "8+",
            "12+",
            "16+",
            "18+"});
            this.cmbAge.Location = new System.Drawing.Point(605, 117);
            this.cmbAge.Name = "cmbAge";
            this.cmbAge.Size = new System.Drawing.Size(60, 24);
            this.cmbAge.TabIndex = 14;
            // 
            // pbImage
            // 
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(701, 355);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(160, 120);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            // 
            // btnImageAdd
            // 
            this.btnImageAdd.Location = new System.Drawing.Point(701, 484);
            this.btnImageAdd.Name = "btnImageAdd";
            this.btnImageAdd.Size = new System.Drawing.Size(84, 30);
            this.btnImageAdd.TabIndex = 2;
            this.btnImageAdd.Text = "Картинка +";
            this.btnImageAdd.UseVisualStyleBackColor = true;
            // 
            // btnImageDelete
            // 
            this.btnImageDelete.Location = new System.Drawing.Point(786, 480);
            this.btnImageDelete.Name = "btnImageDelete";
            this.btnImageDelete.Size = new System.Drawing.Size(75, 30);
            this.btnImageDelete.TabIndex = 1;
            this.btnImageDelete.Text = "Удалить";
            this.btnImageDelete.UseVisualStyleBackColor = true;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.lblHint);
            this.panelButtons.Controls.Add(this.btnBack);
            this.panelButtons.Location = new System.Drawing.Point(15, 520);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(846, 45);
            this.panelButtons.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(130, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(120, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(280, 15);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(294, 17);
            this.lblHint.TabIndex = 2;
            this.lblHint.Text = "Для удаления дважды щёлкните по строке";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(768, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 35);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 580);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.btnImageDelete);
            this.Controls.Add(this.btnImageAdd);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvGames);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GameForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.nudMinPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
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
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvGames;
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
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.Label lblPlayers;
        private System.Windows.Forms.NumericUpDown nudMinPlayers;
        private System.Windows.Forms.NumericUpDown nudMaxPlayers;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.ComboBox cmbAge;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnImageAdd;
        private System.Windows.Forms.Button btnImageDelete;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnBack;
    }
}