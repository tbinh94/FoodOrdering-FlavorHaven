using Food_BL;
using Food_DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace foodordering
{
    public partial class ItemDetail : Form
    {
        private Image currentImage;

        public ItemDetail()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            searchBar.Text = "Tìm món ăn";
            searchBar.ForeColor = Color.Gray;

            searchBar.Enter += searchBar_Enter;
            searchBar.Leave += searchBar_Leave;


            // override hàm trên
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.BackColor = Color.Transparent;

            productPic.Image = ResizeImage(Properties.Resources.background, 500, 300);
            btnDiscount1.Image = ResizeImage(Properties.Resources.discount, 30, 30);
            btnDiscount2.Image = ResizeImage(Properties.Resources.discount, 30, 30);
            btnDiscount3.Image = ResizeImage(Properties.Resources.discount, 30, 30);
            btnSearch.Image = ResizeImage(Properties.Resources.searchicon, 20, 20);

            ConfigButtonDiscount(btnDiscount1);
            ConfigButtonDiscount(btnDiscount2);
            ConfigButtonDiscount(btnDiscount3);
            load_item_seller();
            pProducts.AutoScroll = true;
        }
        private Image ResizeImage(Image imgToResize, int width, int height)
        {
            try
            {
                Bitmap b = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, width, height);
                }
                return b;
            }
            catch
            {
                return imgToResize; // trả về ảnh gốc nếu có lỗi
            }
        }

        private void ConfigButtonDiscount(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(40, 40);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Text = "";
            btn.Padding = new Padding(0); // Thêm padding = 0
            btn.Margin = new Padding(0); // Thêm margin = 0
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
        private void ConfigureImageButton(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(80, 80);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Text = "";
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
        private void ApplyTransparentStyleToAllButtons(Control container)
        {
            // Tìm button trong container hiện tại
            foreach (Control control in container.Controls)
            {
                // Nếu là button thì áp dụng style
                if (control is System.Windows.Forms.Button)
                {
                    MakeButtonTransparent((System.Windows.Forms.Button)control);
                }
                // Nếu control chứa các control khác (như Panel, GroupBox...)
                // thì tìm kiếm tiếp trong đó
                if (control.HasChildren)
                {
                    ApplyTransparentStyleToAllButtons(control);
                }
            }
        }
        private void MakeButtonTransparent(System.Windows.Forms.Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, Color.White);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, Color.White);
            btn.ForeColor = Color.White;
        }
        private void searchBar_Enter(object sender, EventArgs e)
        {
            if (searchBar.Text == "Tìm món ăn")
            {
                searchBar.Text = "";
                searchBar.ForeColor = Color.Black;
            }
        }

        private void searchBar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBar.Text))
            {
                searchBar.Text = "Tìm món ăn";
                searchBar.ForeColor = Color.Gray;
            }
        }

        private void btnDiscount1_Click(object sender, EventArgs e)
        {
            // Tạo một lớp overlay để làm mờ form chính
            Form overlay = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.5,
                ShowInTaskbar = false,
                Location = this.Location, // this là form chính
                Size = this.Size
            };

            // Hiển thị overlay
            overlay.Show(this);
            Guna2MessageDialog dialog = new Guna2MessageDialog
            {
                Caption = "Flavor Haven Thông báo",
                Text = "HOME CREDIT giảm 50k cho đơn từ 100k\n\n" +
               "Discount : 50.000đ - code: HOMECRE50\n\n" +
               "• Đặt tối thiểu: 100.000đ\n" +
               "• Thời gian áp dụng giao hàng: 15/09/2024-15/03/2025\n" +
               "• Không áp dụng cho đơn hàng Tự đến lấy\n" +
               "• Áp dụng cho Quán Đối Tác\n" +
               "• HSD: 15/03/2025 23:59\n" +
               "• Phương thức thanh toán: Visa/Master/JCB\n" +
               "• Số lượng ưu đãi: 1 lần/ thẻ\n" +
               "• Loại ngân hàng: Home Credit\n" +
               "• Số lượng ưu đãi có hạn\n" +
               "• Số lượng ưu đãi: 1 lần/ khách hàng\n" +
               "• Chỉ áp dụng cho người dùng mới của Visa/Master/JCB Home Credit",
                Style = MessageDialogStyle.Light,
                Icon = MessageDialogIcon.Information,
                Buttons = MessageDialogButtons.OK,
            };

            dialog.Show();
            overlay.Dispose();
        }

        private void btnDiscount2_Click(object sender, EventArgs e)
        {
            // Tạo một lớp overlay để làm mờ form chính
            Form overlay = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.5,
                ShowInTaskbar = false,
                Location = this.Location, // this là form chính
                Size = this.Size
            };

            // Hiển thị overlay
            overlay.Show(this);
            Guna2MessageDialog dialog = new Guna2MessageDialog
            {
                Caption = "Flavor Haven Thông báo",
                Text = "HOME CREDIT giảm 40k cho đơn từ 150k\n\n" +
               "Discount : 40.000đ - code: HOMECRE40\n\n" +
               "• Đặt tối thiểu: 150.000đ\n" +
               "• Thời gian áp dụng giao hàng: 15/09/2024-15/03/2025\n" +
               "• Không áp dụng cho đơn hàng Tự đến lấy\n" +
               "• Áp dụng cho Quán Đối Tác\n" +
               "• HSD: 15/03/2025 23:59\n" +
               "• Phương thức thanh toán: Visa/Master/JCB\n" +
               "• Số lượng ưu đãi: 1 lần/ thẻ\n" +
               "• Loại ngân hàng: Home Credit\n" +
               "• Số lượng ưu đãi có hạn\n" +
               "• Số lượng ưu đãi: 1 lần/ khách hàng\n" +
               "• Chỉ áp dụng cho người dùng mới của Visa/Master/JCB Home Credit",
                Style = MessageDialogStyle.Light,
                Icon = MessageDialogIcon.Information,
                Buttons = MessageDialogButtons.OK
            };

            dialog.Show();
            overlay.Dispose();
        }

        private void btnDiscount3_Click(object sender, EventArgs e)
        {
            // Tạo một lớp overlay để làm mờ form chính
            Form overlay = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                BackColor = Color.Black,
                Opacity = 0.5,
                ShowInTaskbar = false,
                Location = this.Location, // this là form chính
                Size = this.Size
            };

            // Hiển thị overlay
            overlay.Show(this);
            Guna2MessageDialog dialog = new Guna2MessageDialog
            {
                Caption = "Flavor Haven Thông báo",
                Text = "Giảm giá một số món ăn trên menu\n\n" +
               "Discount : 50.000đ - code: HOMECRE50\n\n" +
               "• HSD: 30/11/2024 23:59\n" +
               "• Số lượng ưu đãi có hạn\n",
                Style = MessageDialogStyle.Light,
                Icon = MessageDialogIcon.Information,
                Buttons = MessageDialogButtons.OK
            };
            dialog.Show();
            overlay.Dispose();
        }
        public void SetProductDetails(string productName, string productPrice, string address, Image productImage)
        {
            lblName.Text = productName;
            lblPrice.Text = productPrice;
            lblAddress.Text = address;
            label1.Text = $"Home >> TP. HCM >> {productName}";

            if (currentImage != null)
            {
                currentImage.Dispose();
            }

            if (productImage != null)
            {
                currentImage = new Bitmap(productImage);

                productPic.SizeMode = PictureBoxSizeMode.Zoom; // hoặc mode khác tùy nhu cầu
                productPic.Image = currentImage;
            }
        }


        private void ItemDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ItemDetail_Load(object sender, EventArgs e)
        {

        }

        private void load_item_seller()
        {
            pProducts.Controls.Clear();
            List<ProductDTO> list = new ProductBL().GetProducts_Seller();


            foreach (ProductDTO item in list)
            {
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", item.ImagePath);
                Image image;

                if (File.Exists(imagePath))
                {
                    image = Image.FromFile(imagePath);
                }
                else
                {
                    // Nếu không tìm thấy file, dùng hình mặc định
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "1.jpg");
                    image = Image.FromFile(imagePath);
                }
                Product_ItemDetail p = new Product_ItemDetail
                {
                    id = item.ProductID,
                    lblProductName = item.ProductName,

                    lblProductDescription = item.Description,
                    productPicture = ResizeImage(image, 100, 100),
                    lblProductPrice = item.Price.ToString("C0"),
                };
                p.Dock = DockStyle.Top;
                p.Padding = new Padding(10, 10, 10, 10);
                pProducts.Controls.Add(p);
            }
        }

    }
}
