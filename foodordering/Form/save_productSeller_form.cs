using Food_BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
namespace foodordering
{
    public partial class save_productSeller_form : Form
    {
        public int idseller;
        public save_productSeller_form(int id)
        {
            InitializeComponent();
            idseller = id;
            img.AllowDrop = true;
        }
        public string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Mảng chứa các ký tự có dấu
            string[] vietnameseSigns = new string[]
            {
        "aAeEoOuUiIdDyY",
        "áàạảãâấầậẩẫăắằặẳẵ",
        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
        "éèẹẻẽêếềệểễ",
        "ÉÈẸẺẼÊẾỀỆỂỄ",
        "óòọỏõôốồộổỗơớờợởỡ",
        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
        "úùụủũưứừựửữ",
        "ÚÙỤỦŨƯỨỪỰỬỮ",
        "íìịỉĩ",
        "ÍÌỊỈĨ",
        "đ",
        "Đ",
        "ýỳỵỷỹ",
        "ÝỲỴỶỸ"
            };

            // Mảng chứa ký tự không dấu tương ứng
            string[] signs = new string[]
            {
        "aAeEoOuUiIdDyY",
        "a",
        "A",
        "e",
        "E",
        "o",
        "O",
        "u",
        "U",
        "i",
        "I",
        "d",
        "D",
        "y",
        "Y"
            };

            // Thay thế từng ký tự có dấu bằng ký tự không dấu
            for (int i = 1; i < vietnameseSigns.Length; i++)
            {
                for (int j = 0; j < vietnameseSigns[i].Length; j++)
                {
                    text = text.Replace(vietnameseSigns[i][j], signs[i][0]);
                }
            }

            // Loại bỏ khoảng trắng và ký tự đặc biệt
            text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", "");
            text = System.Text.RegularExpressions.Regex.Replace(text, @"[^a-zA-Z0-9]", "");

            return text;
        }

        private void btn_choose_img_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                try
                {
                    using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        img.Image = ResizeImg.ResizeImage(Image.FromStream(stream), 381, 310);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}");
                }
            }
        }

        private void save_productSeller_form_Load(object sender, EventArgs e)
        {
            List<string> list = new ProductBL().CategoryProduct();
            foreach (string item in list)
            {
                CategoryCbb.Items.Add(item);
            }
            addressTxt.Text = Form1.user.Address;
            // Duyệt qua tất cả các TextBox trong Form
            foreach (Control control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Lưu vị trí và kích thước ban đầu của TextBox
                    Point originalLocation = textBox.Location;
                    Size originalSize = textBox.Size;

                    // Tạo Panel để làm viền
                    Panel borderPanel = new Panel
                    {
                        Location = originalLocation,
                        Size = new Size(originalSize.Width + 2, originalSize.Height + 2), // Thêm viền
                        BackColor = Color.Gray, // Màu viền
                        Padding = new Padding(1)
                    };

                    // Di chuyển TextBox vào trong Panel
                    textBox.BorderStyle = BorderStyle.None; // Loại bỏ viền mặc định
                    textBox.Dock = DockStyle.Fill; // Lấp đầy Panel

                    // Thay thế vị trí TextBox bằng Panel
                    this.Controls.Add(borderPanel);
                    borderPanel.Controls.Add(textBox);

                    // Điều chỉnh thứ tự hiển thị
                    borderPanel.BringToFront();
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            string imgname = RemoveDiacritics(nameTxt.Text.Trim() + "_" + idseller) + ".jpg";
            string folderPath = Path.Combine(Application.StartupPath, "Resources", "ProductImage");
            string imagePath = Path.Combine(folderPath, imgname);
            //img.Image.Save(imagePath, ImageFormat.Jpeg);
            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Kiểm tra xem img.Image có null không
            if (img.Image != null)
            {
                try
                {
                    img.Image.Save(imagePath, ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    // In ra thông báo lỗi để biết nguyên nhân cụ thể
                    MessageBox.Show("Lỗi lưu ảnh: " + ex.Message);
                }
            }
            if (new ProductBL().save_product(nameTxt.Text, Decimal.Parse(priceTxt.Text), imgname, descriptionTxt.Text, CategoryCbb.Items.IndexOf(CategoryCbb.Text) + 1, addressTxt.Text, idseller))
            {
                MessageBox.Show("Bạn đã đăng sản phẩm thành công!");

            }
            else
            {
                MessageBox.Show("Đăng sản phẩm thất bại.\nXin hãy thử lại!");
            }
        }

        private void img_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void img_DragDrop(object sender, DragEventArgs e)
        {
            foreach (string pic in ((string[])e.Data.GetData(DataFormats.FileDrop)))
            {
                Image image = Image.FromFile(pic);
                img.Image = ResizeImg.ResizeImage(image, 381, 310); ;
            }
        }

        private void img_Click(object sender, EventArgs e)
        {
            btn_choose_img_Click(sender, e);
        }
    }
}
