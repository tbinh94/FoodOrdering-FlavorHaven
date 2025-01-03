﻿using Food_BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
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
                        img.Image = ResizeImg.ResizeImage(Image.FromStream(stream), img.Width, img.Height);
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
            CategoryCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (string item in list)
            {
                CategoryCbb.Items.Add(item);
            }
            CategoryCbb.SelectedIndex = 0;
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
            string checkTxt = "";
            if (img.Image == null)
            {
                checkTxt += "Vui lòng chọn ảnh sản phẩm!\n";
            }
            if (nameTxt.Text.Length < 2)
            {
                checkTxt += "Tên sản phẩm từ 3 kí tự trở lên!\n";
            }
            if (int.Parse(priceTxt.Text) <= 0)
            {
                checkTxt += "Vui lòng nhập giá sảm phẩm phù hợp!\n";
            }
            if (descriptionTxt.Text.Length < 10)
            {
                checkTxt += "Mô tả sản phẩm từ 10 kí từ trở lên";
            }
            if (checkTxt.Length > 0)
            {
                MessageBox.Show(checkTxt);
                return;
            }
            string imgname = RemoveDiacritics(nameTxt.Text.Trim() + "_" + idseller) + DateTime.Now.ToString("HH-mm-ss") + ".jpg";
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
            if (new ProductBL().save_product(CapitalizeEachWord(nameTxt.Text), Decimal.Parse(priceTxt.Text), imgname, descriptionTxt.Text, CategoryCbb.Items.IndexOf(CategoryCbb.Text) + 1, addressTxt.Text, idseller))
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
                img.Image = ResizeImg.ResizeImage(image, img.Width, img.Height); ;
            }
        }

        private void img_Click(object sender, EventArgs e)
        {
            btn_choose_img_Click(sender, e);
        }

        private void priceTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }

        private void priceTxt_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = priceTxt.SelectionStart;
            if (priceTxt.Text == "" || int.Parse(priceTxt.Text) == 0)
            {
                priceTxt.Text = "0";
                priceTxt.SelectionStart = priceTxt.Text.Length;
                priceTxt.SelectionLength = 0;
                return;
            }
            if ((priceTxt.Text)[0] == '0')
                priceTxt.Text = priceTxt.Text.Substring(1);
            priceTxt.SelectionStart = cursorPosition;
        }
        static string CapitalizeEachWord(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(str.ToLower());
        }
    }
}
