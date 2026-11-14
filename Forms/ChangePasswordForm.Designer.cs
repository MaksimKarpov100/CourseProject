namespace BoardGame_Store
{
    partial class ChangePasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePasswordForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblOld = new System.Windows.Forms.Label();
            this.txtOldPass = new System.Windows.Forms.TextBox();
            this.btnShowOld = new System.Windows.Forms.Button();
            this.lblNew = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.btnShowNew = new System.Windows.Forms.Button();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.btnShowConfirm = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Trebuchet MS", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Смена пароля";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOld
            // 
            this.lblOld.AutoSize = true;
            this.lblOld.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOld.Location = new System.Drawing.Point(30, 60);
            this.lblOld.Name = "lblOld";
            this.lblOld.Size = new System.Drawing.Size(109, 17);
            this.lblOld.TabIndex = 1;
            this.lblOld.Text = "Старый пароль:";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtOldPass.Location = new System.Drawing.Point(30, 85);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PasswordChar = '●';
            this.txtOldPass.Size = new System.Drawing.Size(250, 24);
            this.txtOldPass.TabIndex = 2;
            // 
            // btnShowOld
            // 
            this.btnShowOld.FlatAppearance.BorderSize = 0;
            this.btnShowOld.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowOld.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowOld.Location = new System.Drawing.Point(285, 77);
            this.btnShowOld.Name = "btnShowOld";
            this.btnShowOld.Size = new System.Drawing.Size(35, 36);
            this.btnShowOld.TabIndex = 3;
            this.btnShowOld.Text = "👁";
            this.btnShowOld.UseVisualStyleBackColor = true;
            this.btnShowOld.Click += new System.EventHandler(this.btnShowOld_Click);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblNew.Location = new System.Drawing.Point(30, 125);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(104, 17);
            this.lblNew.TabIndex = 4;
            this.lblNew.Text = "Новый пароль:";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNewPass.Location = new System.Drawing.Point(30, 150);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '●';
            this.txtNewPass.Size = new System.Drawing.Size(250, 24);
            this.txtNewPass.TabIndex = 5;
            // 
            // btnShowNew
            // 
            this.btnShowNew.FlatAppearance.BorderSize = 0;
            this.btnShowNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowNew.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowNew.Location = new System.Drawing.Point(285, 148);
            this.btnShowNew.Name = "btnShowNew";
            this.btnShowNew.Size = new System.Drawing.Size(35, 35);
            this.btnShowNew.TabIndex = 6;
            this.btnShowNew.Text = "👁";
            this.btnShowNew.UseVisualStyleBackColor = true;
            this.btnShowNew.Click += new System.EventHandler(this.btnShowNew_Click);
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblConfirm.Location = new System.Drawing.Point(30, 190);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(95, 17);
            this.lblConfirm.TabIndex = 7;
            this.lblConfirm.Text = "Подтвердите:";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtConfirmPass.Location = new System.Drawing.Point(30, 215);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.PasswordChar = '●';
            this.txtConfirmPass.Size = new System.Drawing.Size(250, 24);
            this.txtConfirmPass.TabIndex = 8;
            // 
            // btnShowConfirm
            // 
            this.btnShowConfirm.FlatAppearance.BorderSize = 0;
            this.btnShowConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowConfirm.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnShowConfirm.Location = new System.Drawing.Point(285, 213);
            this.btnShowConfirm.Name = "btnShowConfirm";
            this.btnShowConfirm.Size = new System.Drawing.Size(35, 27);
            this.btnShowConfirm.TabIndex = 9;
            this.btnShowConfirm.Text = "👁";
            this.btnShowConfirm.UseVisualStyleBackColor = true;
            this.btnShowConfirm.Click += new System.EventHandler(this.btnShowConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(30, 260);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(190, 260);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(350, 320);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnShowConfirm);
            this.Controls.Add(this.txtConfirmPass);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.btnShowNew);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.btnShowOld);
            this.Controls.Add(this.txtOldPass);
            this.Controls.Add(this.lblOld);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Tahoma", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangePasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Смена пароля";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblOld;
        private System.Windows.Forms.TextBox txtOldPass;
        private System.Windows.Forms.Button btnShowOld;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Button btnShowNew;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox txtConfirmPass;
        private System.Windows.Forms.Button btnShowConfirm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}