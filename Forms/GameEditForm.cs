using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging; 
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BoardGame_Store
{
    public partial class GameEditForm : Form
    {
        private int gameId = 0;
        private byte[] imageBytes = null; 

        public GameEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавление товара";
        }

        public GameEditForm(int id)
        {
            InitializeComponent();
            this.gameId = id;
            lblTitle.Text = "Редактирование товара";
        }

        private void GameEditForm_Load(object sender, EventArgs e)
        {
            LoadCategories();
            if (gameId > 0) LoadGameData();
        }

        private void LoadCategories()
        {
            try
            {
                string sql = "SELECT category_id, category_name FROM categories ORDER BY category_name";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql);
                cmbCategory.DataSource = dt;
                cmbCategory.DisplayMember = "category_name";
                cmbCategory.ValueMember = "category_id";
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки категорий: " + ex.Message); }
        }

        private void LoadGameData()
        {
            try
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@id", gameId);

                string sql = "SELECT title, price, stock_quantity, category_id, image_data FROM board_games WHERE game_id=@id";
                DataTable dt = DatabaseHelper.ExecuteQuery(sql, parameters);

                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["title"].ToString();
                    txtPrice.Text = dt.Rows[0]["price"].ToString();
                    txtStock.Text = dt.Rows[0]["stock_quantity"].ToString();
                    cmbCategory.SelectedValue = dt.Rows[0]["category_id"];

                    if (dt.Rows[0]["image_data"] != DBNull.Value)
                    {
                        imageBytes = (byte[])dt.Rows[0]["image_data"];
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbImage.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        try { pbImage.Image = Image.FromFile("Resources/picture.png"); } catch { }
                    }
                }
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка загрузки данных: " + ex.Message); }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool isDigit = char.IsDigit(e.KeyChar);
            bool isControl = char.IsControl(e.KeyChar);
            bool isSeparator = (e.KeyChar == ',' || e.KeyChar == '.');
            if (!isDigit && !isControl && !isSeparator) e.Handled = true;
            if (isSeparator && (txtPrice.Text.Contains(",") || txtPrice.Text.Contains("."))) e.Handled = true;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);

                    long hardLimitMb = 15; 
                    long thresholdMb = 5; 

                    long hardLimitBytes = hardLimitMb * 1024 * 1024;
                    long thresholdBytes = thresholdMb * 1024 * 1024;

                    if (fileInfo.Length > hardLimitBytes)
                    {
                        MessageHelper.ShowWarning($"Файл слишком большой ({fileInfo.Length / 1024 / 1024} МБ). Максимально допустимый размер — {hardLimitMb} МБ.");
                        return;
                    }

                    string newFileName = Guid.NewGuid().ToString() + ".jpg";

                    if (fileInfo.Length >= thresholdBytes)
                    {
                        using (Image originalImage = Image.FromFile(ofd.FileName))
                        {
                            long targetSizeBytes = 2 * 1024 * 1024; 
                            int maxWidth = 800;
                            int maxHeight = 800;

                            imageBytes = CompressImage(originalImage, maxWidth, maxHeight, targetSizeBytes);

                            using (MemoryStream ms = new MemoryStream(imageBytes))
                            {
                                pbImage.Image = Image.FromStream(ms);
                            }

                            long newSizeKb = imageBytes.Length / 1024;
                            MessageHelper.ShowInfo($"Изображение было сжато (исходный файл был больше {thresholdMb} МБ).\n" +
                                                   $"Автоматическое имя: {newFileName}\n" +
                                                   $"Вес: {fileInfo.Length / 1024} КБ -> {newSizeKb} КБ.");
                        }
                    }
                    else
                    {
                        imageBytes = File.ReadAllBytes(ofd.FileName);
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            pbImage.Image = Image.FromStream(ms);
                        }
                        MessageHelper.ShowInfo($"Изображение успешно загружено.\nАвтоматическое имя: {newFileName}");
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageHelper.ShowError("Ошибка: Файл поврежден или не является изображением.");
                }
                catch (Exception ex)
                {
                    MessageHelper.ShowError("Ошибка загрузки картинки: " + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(title)) { MessageHelper.ShowWarning("Введите название игры!"); return; }
            if (ValidationHelper.IsValidGameTitle(title) == false) { MessageHelper.ShowWarning("Недопустимые символы в названии!"); return; }
            if (cmbCategory.SelectedIndex == -1) { MessageHelper.ShowWarning("Выберите категорию!"); return; }

            decimal price = 0;
            if (!decimal.TryParse(txtPrice.Text, out price) || price < 0 || price > 10000) { MessageHelper.ShowWarning("Некорректная цена!"); return; }

            int stock = 0;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0 || stock > 1000) { MessageHelper.ShowWarning("Некорректное количество!"); return; }

            try
            {
                object imageParam = DBNull.Value;
                if (imageBytes != null) imageParam = imageBytes;

                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@t", title);
                parameters.Add("@p", price);
                parameters.Add("@s", stock);
                parameters.Add("@c", cmbCategory.SelectedValue);
                parameters.Add("@img", imageParam);

                if (gameId == 0)
                {
                    string sqlInsert = "INSERT INTO board_games (title, price, stock_quantity, category_id, image_data) VALUES (@t, @p, @s, @c, @img)";
                    DatabaseHelper.ExecuteNonQuery(sqlInsert, parameters);
                    MessageHelper.ShowInfo("Товар успешно добавлен!");
                }
                else
                {
                    parameters.Add("@id", gameId);
                    string sqlUpdate = "UPDATE board_games SET title=@t, price=@p, stock_quantity=@s, category_id=@c, image_data=@img WHERE game_id=@id";
                    DatabaseHelper.ExecuteNonQuery(sqlUpdate, parameters);
                    MessageHelper.ShowInfo("Товар успешно обновлен!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex) { MessageHelper.ShowError("Ошибка базы данных: " + ex.Message); }
        }

        private void btnCancel_Click(object sender, EventArgs e) { this.Close(); }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text)) return;
            string formattedText = ValidationHelper.CapitalizeFirstLetter(txtName.Text);
            if (txtName.Text != formattedText)
            {
                int cursorPosition = txtName.SelectionStart;
                txtName.Text = formattedText;
                txtName.SelectionStart = cursorPosition;
            }
        }

        private byte[] CompressImage(Image originalImage, int maxWidth, int maxHeight, long maxFileSizeBytes)
        {
            int newWidth = originalImage.Width;
            int newHeight = originalImage.Height;

            if (newWidth > maxWidth || newHeight > maxHeight)
            {
                double ratioX = (double)maxWidth / newWidth;
                double ratioY = (double)maxHeight / newHeight;
                double ratio = Math.Min(ratioX, ratioY);

                newWidth = (int)(newWidth * ratio);
                newHeight = (int)(newHeight * ratio);
            }

            using (Bitmap newBitmap = new Bitmap(originalImage, newWidth, newHeight))
            {
                long quality = 90;
                byte[] resultBytes;

                while (true)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                        EncoderParameters myEncoderParameters = new EncoderParameters(1);
                        EncoderParameter myEncoderParameter = new EncoderParameter(Encoder.Quality, quality);
                        myEncoderParameters.Param[0] = myEncoderParameter;

                        newBitmap.Save(ms, jpgEncoder, myEncoderParameters);
                        resultBytes = ms.ToArray();

                        if (resultBytes.Length <= maxFileSizeBytes || quality <= 30) break;
                        quality -= 10;
                    }
                }
                return resultBytes;
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid) return codec;
            }
            return null;
        }
    }
}