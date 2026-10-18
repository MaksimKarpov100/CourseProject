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

            for (int i = 0; i < 4; i++)
            {
                currentCode += chars[rnd.Next(chars.Length)];
            }

            Bitmap bmp = new Bitmap(180, 50);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Font font = new Font("Arial", 22, FontStyle.Bold);
            g.DrawString(currentCode, font, Brushes.Black, 15, 8);

            for (int i = 0; i < 6; i++)
            {
                Pen pen = new Pen(Color.LightGray, 1);

                int x1 = rnd.Next(180);
                int y1 = rnd.Next(50);
                int x2 = rnd.Next(180);
                int y2 = rnd.Next(50);

                g.DrawLine(pen, x1, y1, x2, y2);
            }

            g.Dispose();

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