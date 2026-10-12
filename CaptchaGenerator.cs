using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoardGame_Store
{
    public class CaptchaGenerator
    {
        private static readonly Random rnd = new Random();
        private const string Chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

        public int Width { get; set; } = 180;
        public int Height { get; set; } = 60;
        public int Length { get; set; } = 4;
        public string Text { get; private set; } = "";

        public Bitmap Generate()
        {
            Text = GenerateText();
            return DrawCaptcha();
        }

        public bool Validate(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return input.Trim().ToUpper() == Text.ToUpper();
        }

        private string GenerateText()
        {
            char[] r = new char[Length];
            for (int i = 0; i < Length; i++) r[i] = Chars[rnd.Next(Chars.Length)];
            return new string(r);
        }

        private Bitmap DrawCaptcha()
        {
            Bitmap bmp = new Bitmap(Width, Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.FromArgb(240, 244, 248));

                for (int i = 0; i < 8; i++)
                    g.DrawLine(new Pen(GetColor(120, 200), 1.5f),
                        rnd.Next(Width), rnd.Next(Height), rnd.Next(Width), rnd.Next(Height));

                for (int i = 0; i < 250; i++)
                    g.FillEllipse(new SolidBrush(GetColor(150, 220)),
                        rnd.Next(Width), rnd.Next(Height), 2, 2);

                int cw = Width / (Length + 1);
                int fs = Height - 18;

                for (int i = 0; i < Text.Length; i++)
                {
                    float angle = rnd.Next(-30, 30);
                    int x = 15 + i * cw + rnd.Next(-4, 4);
                    int y = 8 + rnd.Next(-4, 4);

                    using (Font font = new Font("Arial", fs, FontStyle.Bold))
                    {
                        GraphicsState st = g.Save();
                        g.TranslateTransform(x + cw / 2f, y + fs / 2f);
                        g.RotateTransform(angle);
                        g.TranslateTransform(-(x + cw / 2f), -(y + fs / 2f));
                        g.DrawString(Text[i].ToString(), font, new SolidBrush(GetColor(30, 100)), x, y);
                        g.Restore(st);
                    }
                }
            }
            return bmp;
        }

        private Color GetColor(int a, int b)
        {
            return Color.FromArgb(rnd.Next(a, b), rnd.Next(a, b), rnd.Next(a, b));
        }
    }
}