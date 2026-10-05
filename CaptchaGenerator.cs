using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoardGame_Store
{
    /// <summary>
    /// Генератор капчи: случайный текст + шум + линии + повороты символов.
    /// </summary>
    public class CaptchaGenerator
    {
        private static readonly Random rnd = new Random();
        public int Width { get; set; } = 150;

        public int Height { get; set; } = 50;

        public int Length { get; set; } = 4;

        public string Text { get; private set; } = "";

        private const string Chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        /// <summary>
        /// Генерирует новую капчу и возвращает изображение.
        /// </summary>
        public Bitmap Generate()
        {
            Text = GenerateText();
            return DrawCaptcha();
        }

        /// <summary>
        /// Проверяет введённый текст (без учёта регистра).
        /// </summary>
        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return input.Trim().ToUpper() == Text.ToUpper();
        }

        private string GenerateText()
        {
            char[] result = new char[Length];

            for (int i = 0; i < Length; i++)
                result[i] = Chars[rnd.Next(Chars.Length)];

            return new string(result);
        }

        private Bitmap DrawCaptcha()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                g.Clear(Color.WhiteSmoke);
                DrawNoiseLines(g);
                DrawNoiseDots(g);
                DrawText(g);
                g.DrawRectangle(new Pen(Color.Gray, 1), 0, 0, Width - 1, Height - 1);
            }
            return bmp;
        }

        private void DrawNoiseLines(Graphics g)
        {
            for (int i = 0; i < 6; i++)
            {
                int x1 = rnd.Next(Width);
                int y1 = rnd.Next(Height);
                int x2 = rnd.Next(Width);
                int y2 = rnd.Next(Height);

                using (Pen pen = new Pen(GetRandomColor(120, 200), 1.5f))
                {
                    g.DrawLine(pen, x1, y1, x2, y2);
                }
            }
        }

        private void DrawNoiseDots(Graphics g)
        {
            for (int i = 0; i < 200; i++)
            {
                int x = rnd.Next(Width);
                int y = rnd.Next(Height);

                using (Brush br = new SolidBrush(GetRandomColor(150, 220)))
                {
                    g.FillEllipse(br, x, y, 2, 2);
                }
            }
        }

        private void DrawText(Graphics g)
        {
            int charWidth = Width / (Length + 1);
            int fontSize = Height - 15;

            for (int i = 0; i < Text.Length; i++)
            {
                float angle = rnd.Next(-25, 25);
                int x = 15 + i * charWidth + rnd.Next(-3, 3);
                int y = 5 + rnd.Next(-3, 3);

                using (Font font = new Font("Arial", fontSize, FontStyle.Bold))
                {
                    GraphicsState state = g.Save();

                    g.TranslateTransform(x + charWidth / 2f, y + fontSize / 2f);
                    g.RotateTransform(angle);
                    g.TranslateTransform(-(x + charWidth / 2f), -(y + fontSize / 2f));

                    using (Brush brush = new SolidBrush(GetRandomColor(30, 100)))
                    {
                        g.DrawString(Text[i].ToString(), font, brush, x, y);
                    }

                    g.Restore(state);
                }
            }
        }

        private Color GetRandomColor(int min, int max)
        {
            int r = rnd.Next(min, max);
            int g = rnd.Next(min, max);
            int b = rnd.Next(min, max);
            return Color.FromArgb(r, g, b);
        }
    }
}