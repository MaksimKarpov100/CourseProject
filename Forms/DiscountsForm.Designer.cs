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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpBySum = new System.Windows.Forms.GroupBox();
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
            this.grpBySum.SuspendLayout();
            this.grpSeason.SuspendLayout();
            this.grpRules.SuspendLayout();
            this.grpExample.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTitle.Location = new System.Drawing.Point(280, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(228, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Система скидок";
            // 
            // grpBySum
            // 
            this.grpBySum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBySum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpBySum.Controls.Add(this.lblSum3);
            this.grpBySum.Controls.Add(this.lblSum2);
            this.grpBySum.Controls.Add(this.lblSum1);
            this.grpBySum.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpBySum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(160)))));
            this.grpBySum.Location = new System.Drawing.Point(25, 65);
            this.grpBySum.Name = "grpBySum";
            this.grpBySum.Size = new System.Drawing.Size(744, 120);
            this.grpBySum.TabIndex = 2;
            this.grpBySum.TabStop = false;
            this.grpBySum.Text = "🛒 Скидки по сумме заказа";
            // 
            // lblSum3
            // 
            this.lblSum3.AutoSize = true;
            this.lblSum3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSum3.ForeColor = System.Drawing.Color.Black;
            this.lblSum3.Location = new System.Drawing.Point(25, 85);
            this.lblSum3.Name = "lblSum3";
            this.lblSum3.Size = new System.Drawing.Size(294, 20);
            this.lblSum3.TabIndex = 2;
            this.lblSum3.Text = "• Сумма заказа от 10 000 ₽ — скидка 15%";
            // 
            // lblSum2
            // 
            this.lblSum2.AutoSize = true;
            this.lblSum2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSum2.ForeColor = System.Drawing.Color.Black;
            this.lblSum2.Location = new System.Drawing.Point(25, 55);
            this.lblSum2.Name = "lblSum2";
            this.lblSum2.Size = new System.Drawing.Size(286, 20);
            this.lblSum2.TabIndex = 1;
            this.lblSum2.Text = "• Сумма заказа от 5 000 ₽ — скидка 10%";
            // 
            // lblSum1
            // 
            this.lblSum1.AutoSize = true;
            this.lblSum1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSum1.ForeColor = System.Drawing.Color.Black;
            this.lblSum1.Location = new System.Drawing.Point(25, 25);
            this.lblSum1.Name = "lblSum1";
            this.lblSum1.Size = new System.Drawing.Size(278, 20);
            this.lblSum1.TabIndex = 0;
            this.lblSum1.Text = "• Сумма заказа от 2 000 ₽ — скидка 5%";
            // 
            // grpSeason
            // 
            this.grpSeason.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSeason.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpSeason.Controls.Add(this.lblSeason2);
            this.grpSeason.Controls.Add(this.lblSeason1);
            this.grpSeason.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSeason.ForeColor = System.Drawing.Color.Green;
            this.grpSeason.Location = new System.Drawing.Point(25, 195);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Size = new System.Drawing.Size(744, 95);
            this.grpSeason.TabIndex = 3;
            this.grpSeason.TabStop = false;
            this.grpSeason.Text = "🎉 Сезонные скидки";
            // 
            // lblSeason2
            // 
            this.lblSeason2.AutoSize = true;
            this.lblSeason2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSeason2.ForeColor = System.Drawing.Color.Black;
            this.lblSeason2.Location = new System.Drawing.Point(25, 55);
            this.lblSeason2.Name = "lblSeason2";
            this.lblSeason2.Size = new System.Drawing.Size(300, 20);
            this.lblSeason2.TabIndex = 1;
            this.lblSeason2.Text = "• Скидка к 8 марта — 10% (с 7 по 9 марта)";
            // 
            // lblSeason1
            // 
            this.lblSeason1.AutoSize = true;
            this.lblSeason1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSeason1.ForeColor = System.Drawing.Color.Black;
            this.lblSeason1.Location = new System.Drawing.Point(25, 25);
            this.lblSeason1.Name = "lblSeason1";
            this.lblSeason1.Size = new System.Drawing.Size(349, 20);
            this.lblSeason1.TabIndex = 0;
            this.lblSeason1.Text = "• Новогодняя скидка — 15% (с 20 по 31 декабря)";
            // 
            // grpRules
            // 
            this.grpRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRules.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grpRules.Controls.Add(this.lblRule4);
            this.grpRules.Controls.Add(this.lblRule3);
            this.grpRules.Controls.Add(this.lblRule2);
            this.grpRules.Controls.Add(this.lblRule1);
            this.grpRules.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpRules.ForeColor = System.Drawing.Color.DarkRed;
            this.grpRules.Location = new System.Drawing.Point(25, 300);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(744, 140);
            this.grpRules.TabIndex = 4;
            this.grpRules.TabStop = false;
            this.grpRules.Text = "📋 Правила применения";
            // 
            // lblRule4
            // 
            this.lblRule4.AutoSize = true;
            this.lblRule4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRule4.ForeColor = System.Drawing.Color.Black;
            this.lblRule4.Location = new System.Drawing.Point(25, 105);
            this.lblRule4.Name = "lblRule4";
            this.lblRule4.Size = new System.Drawing.Size(371, 19);
            this.lblRule4.TabIndex = 3;
            this.lblRule4.Text = "4. Все скидки сохраняются в БД для отчётов по выручке.";
            // 
            // lblRule3
            // 
            this.lblRule3.AutoSize = true;
            this.lblRule3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRule3.ForeColor = System.Drawing.Color.Black;
            this.lblRule3.Location = new System.Drawing.Point(25, 78);
            this.lblRule3.Name = "lblRule3";
            this.lblRule3.Size = new System.Drawing.Size(380, 19);
            this.lblRule3.TabIndex = 2;
            this.lblRule3.Text = "3. Если ни одно правило не подходит — скидка равна 0%.";
            // 
            // lblRule2
            // 
            this.lblRule2.AutoSize = true;
            this.lblRule2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRule2.ForeColor = System.Drawing.Color.Black;
            this.lblRule2.Location = new System.Drawing.Point(25, 51);
            this.lblRule2.Name = "lblRule2";
            this.lblRule2.Size = new System.Drawing.Size(470, 19);
            this.lblRule2.TabIndex = 1;
            this.lblRule2.Text = "2. Если подходит несколько правил — применяется наибольшая скидка.";
            // 
            // lblRule1
            // 
            this.lblRule1.AutoSize = true;
            this.lblRule1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRule1.ForeColor = System.Drawing.Color.Black;
            this.lblRule1.Location = new System.Drawing.Point(25, 24);
            this.lblRule1.Name = "lblRule1";
            this.lblRule1.Size = new System.Drawing.Size(433, 19);
            this.lblRule1.TabIndex = 0;
            this.lblRule1.Text = "1. Скидка рассчитывается автоматически при оформлении заказа.";
            // 
            // grpExample
            // 
            this.grpExample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpExample.BackColor = System.Drawing.Color.LightYellow;
            this.grpExample.Controls.Add(this.lblExample);
            this.grpExample.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpExample.ForeColor = System.Drawing.Color.Orange;
            this.grpExample.Location = new System.Drawing.Point(25, 450);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(744, 121);
            this.grpExample.TabIndex = 5;
            this.grpExample.TabStop = false;
            this.grpExample.Text = "💡 Пример расчёта";
            // 
            // lblExample
            // 
            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExample.ForeColor = System.Drawing.Color.Black;
            this.lblExample.Location = new System.Drawing.Point(25, 30);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(536, 19);
            this.lblExample.TabIndex = 0;
            this.lblExample.Text = "Пример: заказ на 6 000 ₽ в декабре. Скидка 15% = 900 ₽. Итого к оплате: 5 100 ₽.";
            // 
            // DiscountsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(794, 608);
            this.Controls.Add(this.grpExample);
            this.Controls.Add(this.grpRules);
            this.Controls.Add(this.grpSeason);
            this.Controls.Add(this.grpBySum);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}