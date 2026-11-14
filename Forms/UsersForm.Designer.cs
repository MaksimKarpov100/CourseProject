namespace BoardGame_Store
{
    partial class UsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblRoleFilter = new System.Windows.Forms.Label();
            this.cmbRoleFilter = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
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
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.pnlLegAdmin = new System.Windows.Forms.Panel();
            this.lblLegAdmin = new System.Windows.Forms.Label();
            this.pnlLegManager = new System.Windows.Forms.Panel();
            this.lblLegManager = new System.Windows.Forms.Label();
            this.pnlLegSeller = new System.Windows.Forms.Panel();
            this.lblLegSeller = new System.Windows.Forms.Label();
            this.panelFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.panelPagination.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Управление пользователями";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelFilters
            // 
            this.panelFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFilters.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelFilters.Controls.Add(this.lblSearch);
            this.panelFilters.Controls.Add(this.txtSearch);
            this.panelFilters.Controls.Add(this.lblRoleFilter);
            this.panelFilters.Controls.Add(this.cmbRoleFilter);
            this.panelFilters.Controls.Add(this.lblSort);
            this.panelFilters.Controls.Add(this.cmbSort);
            this.panelFilters.Location = new System.Drawing.Point(12, 45);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(876, 50);
            this.panelFilters.TabIndex = 1;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSearch.Location = new System.Drawing.Point(10, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(47, 17);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Поиск";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSearch.Location = new System.Drawing.Point(70, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 24);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // lblRoleFilter
            // 
            this.lblRoleFilter.AutoSize = true;
            this.lblRoleFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRoleFilter.Location = new System.Drawing.Point(290, 15);
            this.lblRoleFilter.Name = "lblRoleFilter";
            this.lblRoleFilter.Size = new System.Drawing.Size(39, 17);
            this.lblRoleFilter.TabIndex = 2;
            this.lblRoleFilter.Text = "Роль";
            // 
            // cmbRoleFilter
            // 
            this.cmbRoleFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoleFilter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbRoleFilter.Items.AddRange(new object[] {
            "Все",
            "Администратор",
            "Товаровед",
            "Продавец"});
            this.cmbRoleFilter.Location = new System.Drawing.Point(340, 12);
            this.cmbRoleFilter.Name = "cmbRoleFilter";
            this.cmbRoleFilter.Size = new System.Drawing.Size(150, 24);
            this.cmbRoleFilter.TabIndex = 3;
            this.cmbRoleFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRoleFilter_SelectedIndexChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSort.Location = new System.Drawing.Point(520, 15);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(91, 17);
            this.lblSort.TabIndex = 4;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbSort.Items.AddRange(new object[] {
            "По ФИО",
            "По логину",
            "По роли"});
            this.cmbSort.Location = new System.Drawing.Point(620, 12);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(150, 24);
            this.cmbSort.TabIndex = 5;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.cmbSort_SelectedIndexChanged);
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dgvUsers.Location = new System.Drawing.Point(12, 105);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(876, 487);
            this.dgvUsers.TabIndex = 2;
            this.dgvUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
            this.dgvUsers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUsers_CellFormatting);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblCount.Location = new System.Drawing.Point(12, 607);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(157, 17);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Количество записей: 0";
            // 
            // panelPagination
            // 
            this.panelPagination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPagination.Controls.Add(this.btnFirst);
            this.panelPagination.Controls.Add(this.btnPrev);
            this.panelPagination.Controls.Add(this.lblPageInfo);
            this.panelPagination.Controls.Add(this.btnNext);
            this.panelPagination.Controls.Add(this.btnLast);
            this.panelPagination.Controls.Add(this.lblPageSize);
            this.panelPagination.Controls.Add(this.cmbPageSize);
            this.panelPagination.Location = new System.Drawing.Point(12, 632);
            this.panelPagination.Name = "panelPagination";
            this.panelPagination.Size = new System.Drawing.Size(876, 40);
            this.panelPagination.TabIndex = 4;
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnFirst.ForeColor = System.Drawing.Color.White;
            this.btnFirst.Location = new System.Drawing.Point(0, 5);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(50, 30);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatAppearance.BorderSize = 0;
            this.btnPrev.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(60, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 30);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPageInfo.Location = new System.Drawing.Point(130, 10);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(113, 17);
            this.lblPageInfo.TabIndex = 2;
            this.lblPageInfo.Text = "Страница 1 из 1";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(265, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 30);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold);
            this.btnLast.ForeColor = System.Drawing.Color.White;
            this.btnLast.Location = new System.Drawing.Point(321, 5);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(50, 30);
            this.btnLast.TabIndex = 4;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // lblPageSize
            // 
            this.lblPageSize.AutoSize = true;
            this.lblPageSize.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPageSize.Location = new System.Drawing.Point(400, 10);
            this.lblPageSize.Name = "lblPageSize";
            this.lblPageSize.Size = new System.Drawing.Size(65, 17);
            this.lblPageSize.TabIndex = 5;
            this.lblPageSize.Text = "Записей:";
            // 
            // cmbPageSize
            // 
            this.cmbPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPageSize.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cmbPageSize.Items.AddRange(new object[] {
            "10",
            "25",
            "50"});
            this.cmbPageSize.Location = new System.Drawing.Point(470, 7);
            this.cmbPageSize.Name = "cmbPageSize";
            this.cmbPageSize.Size = new System.Drawing.Size(60, 24);
            this.cmbPageSize.TabIndex = 6;
            this.cmbPageSize.SelectedIndexChanged += new System.EventHandler(this.cmbPageSize_SelectedIndexChanged);
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.btnAdd);
            this.panelButtons.Controls.Add(this.btnEdit);
            this.panelButtons.Controls.Add(this.btnDelete);
            this.panelButtons.Controls.Add(this.lblHint);
            this.panelButtons.Controls.Add(this.pnlLegAdmin);
            this.panelButtons.Controls.Add(this.lblLegAdmin);
            this.panelButtons.Controls.Add(this.pnlLegManager);
            this.panelButtons.Controls.Add(this.lblLegManager);
            this.panelButtons.Controls.Add(this.pnlLegSeller);
            this.panelButtons.Controls.Add(this.lblLegSeller);
            this.panelButtons.Location = new System.Drawing.Point(12, 682);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(876, 62);
            this.panelButtons.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(9, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 40);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(165, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(150, 40);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(321, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 40);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic);
            this.lblHint.ForeColor = System.Drawing.Color.Gray;
            this.lblHint.Location = new System.Drawing.Point(477, 5);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(182, 14);
            this.lblHint.TabIndex = 3;
            this.lblHint.Text = "Двойной клик - редактировать";
            // 
            // pnlLegAdmin
            // 
            this.pnlLegAdmin.BackColor = System.Drawing.Color.LightCoral;
            this.pnlLegAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegAdmin.Location = new System.Drawing.Point(480, 35);
            this.pnlLegAdmin.Name = "pnlLegAdmin";
            this.pnlLegAdmin.Size = new System.Drawing.Size(15, 15);
            this.pnlLegAdmin.TabIndex = 4;
            // 
            // lblLegAdmin
            // 
            this.lblLegAdmin.AutoSize = true;
            this.lblLegAdmin.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLegAdmin.Location = new System.Drawing.Point(500, 35);
            this.lblLegAdmin.Name = "lblLegAdmin";
            this.lblLegAdmin.Size = new System.Drawing.Size(96, 14);
            this.lblLegAdmin.TabIndex = 5;
            this.lblLegAdmin.Text = "Администратор";
            // 
            // pnlLegManager
            // 
            this.pnlLegManager.BackColor = System.Drawing.Color.LightYellow;
            this.pnlLegManager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegManager.Location = new System.Drawing.Point(600, 35);
            this.pnlLegManager.Name = "pnlLegManager";
            this.pnlLegManager.Size = new System.Drawing.Size(15, 15);
            this.pnlLegManager.TabIndex = 6;
            // 
            // lblLegManager
            // 
            this.lblLegManager.AutoSize = true;
            this.lblLegManager.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLegManager.Location = new System.Drawing.Point(621, 35);
            this.lblLegManager.Name = "lblLegManager";
            this.lblLegManager.Size = new System.Drawing.Size(68, 14);
            this.lblLegManager.TabIndex = 7;
            this.lblLegManager.Text = "Товаровед";
            // 
            // pnlLegSeller
            // 
            this.pnlLegSeller.BackColor = System.Drawing.Color.LightGreen;
            this.pnlLegSeller.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLegSeller.Location = new System.Drawing.Point(700, 35);
            this.pnlLegSeller.Name = "pnlLegSeller";
            this.pnlLegSeller.Size = new System.Drawing.Size(15, 15);
            this.pnlLegSeller.TabIndex = 8;
            // 
            // lblLegSeller
            // 
            this.lblLegSeller.AutoSize = true;
            this.lblLegSeller.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblLegSeller.Location = new System.Drawing.Point(720, 35);
            this.lblLegSeller.Name = "lblLegSeller";
            this.lblLegSeller.Size = new System.Drawing.Size(62, 14);
            this.lblLegSeller.TabIndex = 9;
            this.lblLegSeller.Text = "Продавец";
            // 
            // UsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 747);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelPagination);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.panelFilters);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Пользователи";
            this.Load += new System.EventHandler(this.UsersForm_Load);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.panelPagination.ResumeLayout(false);
            this.panelPagination.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblRoleFilter;
        private System.Windows.Forms.ComboBox cmbRoleFilter;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
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
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Panel pnlLegAdmin;
        private System.Windows.Forms.Label lblLegAdmin;
        private System.Windows.Forms.Panel pnlLegManager;
        private System.Windows.Forms.Label lblLegManager;
        private System.Windows.Forms.Panel pnlLegSeller;
        private System.Windows.Forms.Label lblLegSeller;
    }
}