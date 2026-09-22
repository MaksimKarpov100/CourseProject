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
            this.lblRole = new System.Windows.Forms.Label();

            // Группа 1 — скидки по сумме
            this.grpBySum = new System.Windows.Forms.GroupBox();
            this.lblSum1 = new System.Windows.Forms.Label();
            this.lblSum2 = new System.Windows.Forms.Label();
            this.lblSum3 = new System.Windows.Forms.Label();

            // Группа 2 — сезонные скидки
            this.grpSeason = new System.Windows.Forms.GroupBox();
            this.lblSeason1 = new System.Windows.Forms.Label();
            this.lblSeason2 = new System.Windows.Forms.Label();

            // Группа 3 — правила применения
            this.grpRules = new System.Windows.Forms.GroupBox();
            this.lblRule1 = new System.Windows.Forms.Label();
            this.lblRule2 = new System.Windows.Forms.Label();
            this.lblRule3 = new System.Windows.Forms.Label();
            this.lblRule4 = new System.Windows.Forms.Label();

            // Примеры
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
            this.lblTitle.Location = new System.Drawing.Point(280, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(220, 26);
            this.lblTitle.Text = "Система скидок";

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRole.Location = new System.Drawing.Point(640, 15);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(130, 17);
            this.lblRole.Text = "[Роль] [ФИО]";

            // === Группа «Скидки по сумме заказа» ===
            this.grpBySum.Text = "Скидки по сумме заказа";
            this.grpBySum.Location = new System.Drawing.Point(20, 55);
            this.grpBySum.Name = "grpBySum";
            this.grpBySum.Size = new System.Drawing.Size(780, 110);

            this.lblSum1.AutoSize = true;
            this.lblSum1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSum1.Location = new System.Drawing.Point(20, 30);
            this.lblSum1.Name = "lblSum1";
            this.lblSum1.Size = new System.Drawing.Size(430, 18);
            this.lblSum1.Text = "• Сумма заказа от 2 000 ₽  —  скидка 5%";

            this.lblSum2.AutoSize = true;
            this.lblSum2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSum2.Location = new System.Drawing.Point(20, 55);
            this.lblSum2.Name = "lblSum2";
            this.lblSum2.Size = new System.Drawing.Size(430, 18);
            this.lblSum2.Text = "• Сумма заказа от 5 000 ₽  —  скидка 10%";

            this.lblSum3.AutoSize = true;
            this.lblSum3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSum3.Location = new System.Drawing.Point(20, 80);
            this.lblSum3.Name = "lblSum3";
            this.lblSum3.Size = new System.Drawing.Size(430, 18);
            this.lblSum3.Text = "• Сумма заказа от 10 000 ₽ —  скидка 15%";

            this.grpBySum.Controls.Add(this.lblSum1);
            this.grpBySum.Controls.Add(this.lblSum2);
            this.grpBySum.Controls.Add(this.lblSum3);

            // === Группа «Сезонные скидки» ===
            this.grpSeason.Text = "Сезонные скидки (по периоду)";
            this.grpSeason.Location = new System.Drawing.Point(20, 175);
            this.grpSeason.Name = "grpSeason";
            this.grpSeason.Size = new System.Drawing.Size(780, 90);

            this.lblSeason1.AutoSize = true;
            this.lblSeason1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSeason1.Location = new System.Drawing.Point(20, 30);
            this.lblSeason1.Name = "lblSeason1";
            this.lblSeason1.Size = new System.Drawing.Size(500, 18);
            this.lblSeason1.Text = "• 🎄 Новогодняя скидка   —  15%   (с 20 по 31 декабря)";

            this.lblSeason2.AutoSize = true;
            this.lblSeason2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblSeason2.Location = new System.Drawing.Point(20, 55);
            this.lblSeason2.Name = "lblSeason2";
            this.lblSeason2.Size = new System.Drawing.Size(500, 18);
            this.lblSeason2.Text = "• 🌷 Скидка к 8 марта   —  10%   (с 7 по 9 марта)";

            this.grpSeason.Controls.Add(this.lblSeason1);
            this.grpSeason.Controls.Add(this.lblSeason2);

            // === Группа «Правила применения» ===
            this.grpRules.Text = "Правила применения скидок";
            this.grpRules.Location = new System.Drawing.Point(20, 275);
            this.grpRules.Name = "grpRules";
            this.grpRules.Size = new System.Drawing.Size(780, 130);

            this.lblRule1.AutoSize = true;
            this.lblRule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRule1.Location = new System.Drawing.Point(20, 25);
            this.lblRule1.Name = "lblRule1";
            this.lblRule1.Size = new System.Drawing.Size(720, 17);
            this.lblRule1.Text = "1. Скидка рассчитывается автоматически при оформлении заказа — вручную продавец её не вводит.";

            this.lblRule2.AutoSize = true;
            this.lblRule2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRule2.Location = new System.Drawing.Point(20, 50);
            this.lblRule2.Name = "lblRule2";
            this.lblRule2.Size = new System.Drawing.Size(720, 17);
            this.lblRule2.Text = "2. Если подходит несколько правил — применяется наибольшая скидка.";

            this.lblRule3.AutoSize = true;
            this.lblRule3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRule3.Location = new System.Drawing.Point(20, 75);
            this.lblRule3.Name = "lblRule3";
            this.lblRule3.Size = new System.Drawing.Size(720, 17);
            this.lblRule3.Text = "3. Если ни одно правило не подходит — скидка равна 0%.";

            this.lblRule4.AutoSize = true;
            this.lblRule4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblRule4.Location = new System.Drawing.Point(20, 100);
            this.lblRule4.Name = "lblRule4";
            this.lblRule4.Size = new System.Drawing.Size(720, 17);
            this.lblRule4.Text = "4. Все применённые скидки сохраняются в базе данных для отчётов по выручке.";

            this.grpRules.Controls.Add(this.lblRule1);
            this.grpRules.Controls.Add(this.lblRule2);
            this.grpRules.Controls.Add(this.lblRule3);
            this.grpRules.Controls.Add(this.lblRule4);

            // === Пример расчёта ===
            this.grpExample.Text = "Пример расчёта скидки";
            this.grpExample.Location = new System.Drawing.Point(20, 415);
            this.grpExample.Name = "grpExample";
            this.grpExample.Size = new System.Drawing.Size(780, 80);

            this.lblExample.AutoSize = true;
            this.lblExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblExample.Location = new System.Drawing.Point(20, 25);
            this.lblExample.Name = "lblExample";
            this.lblExample.Size = new System.Drawing.Size(740, 40);
            this.lblExample.Text =
                "Пример: заказ на сумму 6 000 ₽ в декабре.\r\n" +
                "Скидка от 5 000 ₽ = 10%, новогодняя = 15%. Применяется 15%.\r\n" +
                "Сумма скидки: 6 000 × 0,15 = 900 ₽.  Итого к оплате: 5 100 ₽.";

            this.grpExample.Controls.Add(this.lblExample);

            // btnBack
            this.btnBack.Location = new System.Drawing.Point(680, 505);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 40);
            this.btnBack.Text = "В меню";
            this.btnBack.UseVisualStyleBackColor = true;

            // DiscountsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 560);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.grpExample);
            this.Controls.Add(this.grpRules);
            this.Controls.Add(this.grpSeason);
            this.Controls.Add(this.grpBySum);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DiscountsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label lblRole;

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