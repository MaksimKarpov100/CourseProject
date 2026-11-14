using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BoardGame_Store
{
    public class CaptchaGenerator
    {
        private string currentCode = "";
        private Random rnd = new Random();

        public Image Generate()
        {
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            currentCode = "";

            for (int i = 0; i < 5; i++)
            {
                currentCode += chars[rnd.Next(chars.Length)];
            }

            int width = 200;
            int height = 60;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (LinearGradientBrush brush = new LinearGradientBrush(
                    new Rectangle(0, 0, width, height),
                    Color.FromArgb(240, 240, 240),
                    Color.FromArgb(210, 210, 210),
                    45f))
                {
                    g.FillRectangle(brush, 0, 0, width, height);
                }

                for (int i = 0; i < 400; i++)
                {
                    int x = rnd.Next(width);
                    int y = rnd.Next(height);
                    Color noiseColor = Color.FromArgb(rnd.Next(150, 255), rnd.Next(150, 255), rnd.Next(150, 255));
                    using (SolidBrush noiseBrush = new SolidBrush(noiseColor))
                    {
                        g.FillEllipse(noiseBrush, x, y, rnd.Next(1, 3), rnd.Next(1, 3));
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Pen curvePen = new Pen(Color.FromArgb(rnd.Next(50, 150), rnd.Next(50, 150), rnd.Next(50, 150)), rnd.Next(1, 3));
                    g.DrawBezier(curvePen,
                        new Point(rnd.Next(width), rnd.Next(height)),
                        new Point(rnd.Next(width), rnd.Next(height)),
                        new Point(rnd.Next(width), rnd.Next(height)),
                        new Point(rnd.Next(width), rnd.Next(height)));
                }

                int startX = 15;

                foreach (char c in currentCode)
                {
                    GraphicsState state = g.Save();
                    int offsetY = rnd.Next(-8, 8);
                    float angle = rnd.Next(-20, 20);
                    string[] fontNames = { "Arial", "Times New Roman", "Courier New", "Verdana" };
                    string fontName = fontNames[rnd.Next(fontNames.Length)];
                    int fontSize = rnd.Next(22, 28);

                    using (Font font = new Font(fontName, fontSize, FontStyle.Bold | FontStyle.Italic))
                    using (SolidBrush textBrush = new SolidBrush(Color.FromArgb(rnd.Next(0, 100), rnd.Next(0, 100), rnd.Next(0, 100))))
                    {
                        g.TranslateTransform(startX, height / 2 + offsetY);
                        g.RotateTransform(angle);
                        g.DrawString(c.ToString(), font, textBrush, -10, -20);
                    }
                    g.Restore(state);
                    startX += rnd.Next(30, 38);
                }

                for (int i = 0; i < 150; i++)
                {
                    int x = rnd.Next(width);
                    int y = rnd.Next(height);
                    Color noiseColor = Color.FromArgb(rnd.Next(100, 200), rnd.Next(100, 200), rnd.Next(100, 200));
                    using (SolidBrush noiseBrush = new SolidBrush(noiseColor))
                    {
                        g.FillEllipse(noiseBrush, x, y, 2, 2);
                    }
                }
            }

            return bmp;
        }

        public bool Validate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            return input.Trim().ToUpper() == currentCode;
        }
    }
}