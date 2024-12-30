using Food_BL;
using Food_DTO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace foodordering
{
    public partial class discount_productSeller_form : Form
    {
        public int idProduct;
        public UserDTO user;
        public ProductDTO product;
        public discount_productSeller_form(int idProduct)
        {
            InitializeComponent();
            img.AllowDrop = true;
            this.idProduct = idProduct;
            user = Form1.user;
            product = new ProductBL().GetProduct(idProduct);

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

            nameTxt.Text = product.ProductName;
            priceTxt.Text = product.Price.ToString();
            slTxt.Text = product.Inventory.ToString();

            loadImg(product.ImagePath);

        }
        public void loadImg(string path)
        {
            string folderPath = Path.Combine(Application.StartupPath, "Resources", "ProductImage");
            string imagePath = Path.Combine(folderPath, path);
            Image i = ResizeImg.ResizeImage(Image.FromFile(imagePath), 379, 254);
            img.Image = i;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {



        }

        private void img_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void img_Click(object sender, EventArgs e)
        {
            btn_choose_img_Click(sender, e);
        }

        private void slTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }
        }
    }
}
