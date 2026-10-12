namespace BoardGame_Store
{
    partial class DiscountsForm
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
            this.grpBySum = new System.Windows.Forms.GroupBox();
            this.lblSum1 = new System.Windows.Forms.Label();
            this.lblSum2 = new System.Windows.Forms.Label();
            this.lblSum3 = new System.Windows.Forms.Label();
            this.grpSeason = new System.Windows.Forms.GroupBox();
            this.lblSeason1 = new System.Windows.Forms.Label();
            this.lblSeason2 = new System.Windows.Forms.Label();
            this.grpRules = new System.Windows.Forms.GroupBox();
            this.lblRule1 = new System.Windows.Forms.Label();
            this.lblRule2 = new System.Windows.Forms.Label();
            this.lblRule3 = new System.Windows.Forms.Label();
            this.lblRule4 = new System.Windows.Forms.Label();
            this.grpExample = new System.Windows.Forms.GroupBox();
            this.lblExample = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();

            this.grpBySum.SuspendLayout();
            this.grpSeason.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.grpExample.SuspendLayout();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 26);
            this.lblTitle.Text = "Система скидок";

            // grpBySum
            this.grpBySum.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBySum.Controls.Add(this.lblSum1);
            this.grpBySum.Controls.Add(this.lblSum2);
            this.grpBySum.Controls.Add(this.lblSum3);
            this.grpBySum.Location = new System.Drawing.Point(20, 60);
            this.grpBySum.Name = "grpBySum";
            this.grpBySum.Size = new System.Drawing.Size(760, 110);
            this.grpBySum.TabIndex = 1;
            this.grpBySum.TabStop = false;
            this.grpBySum.Text = "Скидки по сумме заказа";

            this.lblSum1.AutoSize = true;
            this.lblSum1.Location = new System.Drawing.Point(20, 30);
            this.lblSum1.Size = new System.Drawing.Size(400, 17);

            this.lblSum2.AutoSize = true;
            this.lblSum2.Location = new System.Drawing.Point(20, 55);
            this.lblSum2.Size = new System.Drawing.Size(400, 17);

            this.lblSum3.AutoSize = true;
            this.lblSum3.Location = new System.Drawing.Point(20, 80);
            this.lblSum3.Size = new System.Drawing.Size(400, 17);

            // grpSeason
            this.grpSeason.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSeason.Controls.Add(this.lblSeason1);
            this.grpSeason.Controls.Add(this.lblSeason2);
            this.grpSeason.Location = new System.Drawing.Point(20, 180);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Size = new System.Drawing.Size(760, 90);
            this.grpSeason.TabIndex = 2;
            this.grpSeason.TabStop = false;
            this.grpSeason.Text = "Сезонные скидки";

            this.lblSeason1.AutoSize = true;
            this.lblSeason1.Location = new System.Drawing.Point(20, 30);
            this.lblSeason1.Size = new System.Drawing.Size(500, 17);

            this.lblSeason2.AutoSize = true;
            this.lblSeason2.Location = new System.Drawing.Point(20, 55);
            this.lblSeason2.Size = new System.Drawing.Size(500, 17);

            // grpRules
            this.grpRules.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRules.Controls.Add(this.lblRule1);
            this.grpRules.Controls.Add(this.lblRule2);
            this.grpRules.Controls.Add(this.lblRule3);
            this.grpRules.Controls.Add(this.lblRule4);
            this.grpRules.Location = new System.Drawing.Point(20, 280);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(760, 130);
            this.grpRules.TabIndex = 3;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "Правила применения скидок";

            this.lblRule1.AutoSize = true;
            this.lblRule1.Location = new System.Drawing.Point(20, 25);
            this.lblRule1.Size = new System.Drawing.Size(700, 17);

            this.lblRule2.AutoSize = true;
            this.lblRule2.Location = new System.Drawing.Point(20, 50);
            this.lblRule2.Size = new System.Drawing.Size(700, 17);

            this.lblRule3.AutoSize = true;
            this.lblRule3.Location = new System.Drawing.Point(20, 75);
            this.lblRule3.Size = new System.Drawing.Size(700, 17);

            this.lblRule4.AutoSize = true;
            this.lblRule4.Location = new System.Drawing.Point(20, 100);
            this.lblRule4.Size = new System.Drawing.Size(700, 17);

            // grpExample
            this.grpExample.Anchor = ((System.Windows.Forms.AnchorStyles)
                (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExample.Controls.Add(this.lblExample);
            this.grpExample.Location = new System.Drawing.Point(20, 420);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(760, 90);
            this.grpExample.TabIndex = 4;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "Пример расчёта";

            this.lblExample.AutoSize = true;
            this.lblExample.Location = new System.Drawing.Point(20, 25);
            this.lblExample.Size = new System.Drawing.Size(700, 50);

            // btnBack
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)
                ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(650, 525);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 40);
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // DiscountsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 580);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpExample);
            this.Controls.Add(this.grpRules);
            this.Controls.Add(this.grpSeason);
            this.Controls.Add(this.grpBySum);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "DiscountsForm";
            this.Text = "Система скидок";

            this.grpBySum.ResumeLayout(false);
            this.grpBySum.PerformLayout();
            this.grpSeason.ResumeLayout(false);
            this.grpSeason.PerformLayout();
            this.grpRules.ResumeLayout(false);
            this.grpRules.PerformLayout();
            this.grpExample.ResumeLayout(false);
            this.grpExample.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpBySum;
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
        private System.Windows.Forms.Button btnBack;
    }
}