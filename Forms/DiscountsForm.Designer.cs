namespace BoardGame_Store
{
    partial class DiscountsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscountsForm));

            // Главный контейнер, который поделит форму на 4 равные части
            this.mainTable = new System.Windows.Forms.TableLayoutPanel();

            this.grpSum = new System.Windows.Forms.GroupBox();
            this.lblSum3 = new System.Windows.Forms.Label();
            this.lblSum2 = new System.Windows.Forms.Label();
            this.lblSum1 = new System.Windows.Forms.Label();

            this.grpSeason = new System.Windows.Forms.GroupBox();
            this.lblSeason2 = new System.Windows.Forms.Label();
            this.lblSeason1 = new System.Windows.Forms.Label();

            this.grpRules = new System.Windows.Forms.GroupBox();
            this.lblRule4 = new System.Windows.Forms.Label();
            this.lblRule3 = new System.Windows.Forms.Label();
            this.lblRule2 = new System.Windows.Forms.Label();
            this.lblRule1 = new System.Windows.Forms.Label();

            this.grpExample = new System.Windows.Forms.GroupBox();
            this.lblExample = new System.Windows.Forms.Label();

            this.mainTable.SuspendLayout();
            this.grpSum.SuspendLayout();
            this.grpSeason.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.grpExample.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTable
            // 
            this.mainTable.ColumnCount = 1;
            this.mainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTable.Controls.Add(this.grpSum, 0, 0);
            this.mainTable.Controls.Add(this.grpSeason, 0, 1);
            this.mainTable.Controls.Add(this.grpRules, 0, 2);
            this.mainTable.Controls.Add(this.grpExample, 0, 3);
            this.mainTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTable.Location = new System.Drawing.Point(0, 0);
            this.mainTable.Name = "mainTable";
            this.mainTable.Padding = new System.Windows.Forms.Padding(15);
            this.mainTable.RowCount = 4;
            // Делаем все строки равными по 25%
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainTable.Size = new System.Drawing.Size(500, 500);
            this.mainTable.TabIndex = 0;

            // 
            // grpSum
            // 
            this.grpSum.Controls.Add(this.lblSum3);
            this.grpSum.Controls.Add(this.lblSum2);
            this.grpSum.Controls.Add(this.lblSum1);
            this.grpSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSum.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.grpSum.Name = "grpSum";
            this.grpSum.Padding = new System.Windows.Forms.Padding(10);
            this.grpSum.TabIndex = 0;
            this.grpSum.TabStop = false;
            this.grpSum.Text = "Скидки от суммы заказа";

            // 
            // lblSum1, lblSum2, lblSum3
            // 
            this.lblSum1.AutoSize = true;
            this.lblSum1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSum1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSum1.Location = new System.Drawing.Point(10, 25);
            this.lblSum1.Name = "lblSum1";
            this.lblSum1.Size = new System.Drawing.Size(100, 20);
            this.lblSum1.TabIndex = 0;

            this.lblSum2.AutoSize = true;
            this.lblSum2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSum2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSum2.Location = new System.Drawing.Point(10, 50);
            this.lblSum2.Name = "lblSum2";
            this.lblSum2.Size = new System.Drawing.Size(100, 20);
            this.lblSum2.TabIndex = 1;

            this.lblSum3.AutoSize = true;
            this.lblSum3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSum3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSum3.Location = new System.Drawing.Point(10, 75);
            this.lblSum3.Name = "lblSum3";
            this.lblSum3.Size = new System.Drawing.Size(100, 20);
            this.lblSum3.TabIndex = 2;

            // 
            // grpSeason
            // 
            this.grpSeason.Controls.Add(this.lblSeason2);
            this.grpSeason.Controls.Add(this.lblSeason1);
            this.grpSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSeason.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Padding = new System.Windows.Forms.Padding(10);
            this.grpSeason.TabIndex = 1;
            this.grpSeason.TabStop = false;
            this.grpSeason.Text = "Праздничные скидки";

            this.lblSeason1.AutoSize = true;
            this.lblSeason1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeason1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSeason1.Location = new System.Drawing.Point(10, 25);
            this.lblSeason1.Name = "lblSeason1";
            this.lblSeason1.Size = new System.Drawing.Size(100, 20);
            this.lblSeason1.TabIndex = 0;

            this.lblSeason2.AutoSize = true;
            this.lblSeason2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeason2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblSeason2.Location = new System.Drawing.Point(10, 50);
            this.lblSeason2.Name = "lblSeason2";
            this.lblSeason2.Size = new System.Drawing.Size(100, 20);
            this.lblSeason2.TabIndex = 1;

            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.lblRule4);
            this.grpRules.Controls.Add(this.lblRule3);
            this.grpRules.Controls.Add(this.lblRule2);
            this.grpRules.Controls.Add(this.lblRule1);
            this.grpRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRules.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.grpRules.Name = "grpRules";
            this.grpRules.Padding = new System.Windows.Forms.Padding(10);
            this.grpRules.TabIndex = 2;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Правила применения";

            this.lblRule1.AutoSize = true;
            this.lblRule1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRule1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRule1.Location = new System.Drawing.Point(10, 25);
            this.lblRule1.Name = "lblRule1";
            this.lblRule1.Size = new System.Drawing.Size(100, 20);
            this.lblRule1.TabIndex = 0;

            this.lblRule2.AutoSize = true;
            this.lblRule2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRule2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRule2.Location = new System.Drawing.Point(10, 50);
            this.lblRule2.Name = "lblRule2";
            this.lblRule2.Size = new System.Drawing.Size(100, 20);
            this.lblRule2.TabIndex = 1;

            this.lblRule3.AutoSize = true;
            this.lblRule3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRule3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRule3.Location = new System.Drawing.Point(10, 75);
            this.lblRule3.Name = "lblRule3";
            this.lblRule3.Size = new System.Drawing.Size(100, 20);
            this.lblRule3.TabIndex = 2;

            this.lblRule4.AutoSize = true;
            this.lblRule4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRule4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblRule4.Location = new System.Drawing.Point(10, 100);
            this.lblRule4.Name = "lblRule4";
            this.lblRule4.Size = new System.Drawing.Size(100, 20);
            this.lblRule4.TabIndex = 3;

            // 
            // grpExample
            // 
            this.grpExample.Controls.Add(this.lblExample);
            this.grpExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpExample.Font = new System.Drawing.Font("Trebuchet MS", 11F, System.Drawing.FontStyle.Bold);
            this.grpExample.Name = "grpExample";
            this.grpExample.Padding = new System.Windows.Forms.Padding(10);
            this.grpExample.TabIndex = 3;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "Пример расчета";

            this.lblExample.AutoSize = true;
            this.lblExample.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExample.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblExample.Location = new System.Drawing.Point(10, 25);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(100, 100);
            this.lblExample.TabIndex = 0;

            // 
            // DiscountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.Add(this.mainTable);
            this.Font = new System.Drawing.Font("Tahoma", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ControlBox = false;
            this.MaximizeBox = true; 
            this.MinimumSize = new System.Drawing.Size(500, 450); 
            this.Name = "DiscountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Система скидок";
            this.Load += new System.EventHandler(this.DiscountsForm_Load);
            this.Resize += new System.EventHandler(this.DiscountsForm_Resize); 

            this.mainTable.ResumeLayout(false);
            this.grpSum.ResumeLayout(false);
            this.grpSum.PerformLayout();
            this.grpSeason.ResumeLayout(false);
            this.grpSeason.PerformLayout();
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            this.grpExample.ResumeLayout(false);
            this.grpExample.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TableLayoutPanel mainTable;
        private System.Windows.Forms.GroupBox grpSum;
        private System.Windows.Forms.Label lblSum1;
        private System.Windows.Forms.Label lblSum2;
        private System.Windows.Forms.Label lblSum3;
        private System.Windows.Forms.GroupBox grpSeason;
        private System.Windows.Forms.Label lblSeason1;
        private System.Windows.Forms.Label lblSeason2;
        private System.Windows.Forms.GroupBox grpRules;
        private System.Windows.Forms.Label lblRule1;
        private System.Windows.Forms.Label lblRule2;
        private System.Windows.Forms.Label lblRule3;
        private System.Windows.Forms.Label lblRule4;
        private System.Windows.Forms.GroupBox grpExample;
        private System.Windows.Forms.Label lblExample;
    }
}