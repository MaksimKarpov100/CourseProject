using System.Windows.Forms; // <-- ЭТА СТРОКА ОБЯЗАТЕЛЬНА

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
            this.grpSum.SuspendLayout();
            this.grpSeason.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.grpExample.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSum
            // 
            this.grpSum.Controls.Add(this.lblSum3);
            this.grpSum.Controls.Add(this.lblSum2);
            this.grpSum.Controls.Add(this.lblSum1);
            this.grpSum.Location = new System.Drawing.Point(20, 20);
            this.grpSum.Name = "grpSum";
            this.grpSum.Size = new System.Drawing.Size(400, 100);
            this.grpSum.TabIndex = 0;
            this.grpSum.TabStop = false;
            this.grpSum.Text = "Скидки от суммы заказа";
            // 
            // lblSum3
            // 
            this.lblSum3.AutoSize = true;
            this.lblSum3.Location = new System.Drawing.Point(15, 75);
            this.lblSum3.Name = "lblSum3";
            this.lblSum3.Size = new System.Drawing.Size(0, 15);
            this.lblSum3.TabIndex = 2;
            // 
            // lblSum2
            // 
            this.lblSum2.AutoSize = true;
            this.lblSum2.Location = new System.Drawing.Point(15, 50);
            this.lblSum2.Name = "lblSum2";
            this.lblSum2.Size = new System.Drawing.Size(0, 15);
            this.lblSum2.TabIndex = 1;
            // 
            // lblSum1
            // 
            this.lblSum1.AutoSize = true;
            this.lblSum1.Location = new System.Drawing.Point(15, 25);
            this.lblSum1.Name = "lblSum1";
            this.lblSum1.Size = new System.Drawing.Size(0, 15);
            this.lblSum1.TabIndex = 0;
            // 
            // grpSeason
            // 
            this.grpSeason.Controls.Add(this.lblSeason2);
            this.grpSeason.Controls.Add(this.lblSeason1);
            this.grpSeason.Location = new System.Drawing.Point(20, 130);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Size = new System.Drawing.Size(400, 80);
            this.grpSeason.TabIndex = 1;
            this.grpSeason.TabStop = false;
            this.grpSeason.Text = "Праздничные скидки";
            // 
            // lblSeason2
            // 
            this.lblSeason2.AutoSize = true;
            this.lblSeason2.Location = new System.Drawing.Point(15, 50);
            this.lblSeason2.Name = "lblSeason2";
            this.lblSeason2.Size = new System.Drawing.Size(0, 15);
            this.lblSeason2.TabIndex = 1;
            // 
            // lblSeason1
            // 
            this.lblSeason1.AutoSize = true;
            this.lblSeason1.Location = new System.Drawing.Point(15, 25);
            this.lblSeason1.Name = "lblSeason1";
            this.lblSeason1.Size = new System.Drawing.Size(0, 15);
            this.lblSeason1.TabIndex = 0;
            // 
            // grpRules
            // 
            this.grpRules.Controls.Add(this.lblRule4);
            this.grpRules.Controls.Add(this.lblRule3);
            this.grpRules.Controls.Add(this.lblRule2);
            this.grpRules.Controls.Add(this.lblRule1);
            this.grpRules.Location = new System.Drawing.Point(20, 220);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(400, 120);
            this.grpRules.TabIndex = 2;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Правила применения";
            // 
            // lblRule4
            // 
            this.lblRule4.AutoSize = true;
            this.lblRule4.Location = new System.Drawing.Point(15, 95);
            this.lblRule4.Name = "lblRule4";
            this.lblRule4.Size = new System.Drawing.Size(0, 15);
            this.lblRule4.TabIndex = 3;
            // 
            // lblRule3
            // 
            this.lblRule3.AutoSize = true;
            this.lblRule3.Location = new System.Drawing.Point(15, 75);
            this.lblRule3.Name = "lblRule3";
            this.lblRule3.Size = new System.Drawing.Size(0, 15);
            this.lblRule3.TabIndex = 2;
            // 
            // lblRule2
            // 
            this.lblRule2.AutoSize = true;
            this.lblRule2.Location = new System.Drawing.Point(15, 50);
            this.lblRule2.Name = "lblRule2";
            this.lblRule2.Size = new System.Drawing.Size(0, 15);
            this.lblRule2.TabIndex = 1;
            // 
            // lblRule1
            // 
            this.lblRule1.AutoSize = true;
            this.lblRule1.Location = new System.Drawing.Point(15, 25);
            this.lblRule1.Name = "lblRule1";
            this.lblRule1.Size = new System.Drawing.Size(0, 15);
            this.lblRule1.TabIndex = 0;
            // 
            // grpExample
            // 
            this.grpExample.Controls.Add(this.lblExample);
            this.grpExample.Location = new System.Drawing.Point(20, 350);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(400, 80);
            this.grpExample.TabIndex = 3;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "Пример расчета";
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(15, 25);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(0, 15);
            this.lblExample.TabIndex = 0;
            // 
            // DiscountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 450);
            this.Controls.Add(this.grpExample);
            this.Controls.Add(this.grpRules);
            this.Controls.Add(this.grpSeason);
            this.Controls.Add(this.grpSum);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "DiscountsForm";
            this.Text = "Система скидок";
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