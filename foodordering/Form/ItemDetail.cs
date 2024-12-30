using Food_BL;
using Food_DTO;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace foodordering
{
    public partial class ItemDetail : Form
    {
        private Image currentImage;
        private Bitmap backgroundBitmap;
        private Guna2Button selectedButton = null;

        public ItemDetail()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            searchBar.Text = "Tìm món ăn";
            searchBar.ForeColor = Color.Gray;

            searchBar.Enter += searchBar_Enter;
            searchBar.Leave += searchBar_Leave;

            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.BackColor = Color.Transparent;

            productPic.Image = ResizeImg.ResizeImage(Properties.Resources.background, 500, 300);
            btnDiscount1.Image = ResizeImg.ResizeImage(Properties.Resources.discount, 30, 30);
            btnDiscount2.Image = ResizeImg.ResizeImage(Properties.Resources.discount, 30, 30);
            btnDiscount3.Image = ResizeImg.ResizeImage(Properties.Resources.discount, 30, 30);
            btnSearch.Image = ResizeImg.ResizeImage(Properties.Resources.searchicon, 20, 20);
            picQR.Image = Properties.Resources.QR;
            picQR.SizeMode = PictureBoxSizeMode.Zoom;


            ConfigButtonDiscount(btnDiscount1);
            ConfigButtonDiscount(btnDiscount2);
            ConfigButtonDiscount(btnDiscount3);
            backgroundBitmap = new Bitmap(ResizeImg.ResizeImage(Properties.Resources.border, 500, 300));

            DoubleBuffering(pProducts);
            pProducts.BackColor = Color.Transparent;
            tableLayoutPanel1.BackColor = Color.Transparent;
            pProducts.Paint += new PaintEventHandler(pProducts_Paint);
            pProducts.Scroll += new ScrollEventHandler(pProducts_Scroll);

            pProducts.AutoScroll = true;

            load_item_seller();
        }
        private void DoubleBuffering(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel, new object[] { true });
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
        public void SetProductDetails(string productName, string productPrice, string address, Image productImage, int rating)
        {
            lblName.Text = productName;
            lblPrice.Text = productPrice;
            lblAddress.Text = address;
            label1.Text = $"Home >> TP. HCM >> {productName}";
            starRating.Value = rating;

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
            Random random = new Random();

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
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                    image = Image.FromFile(imagePath);
                }

                Product_ItemDetail p = new Product_ItemDetail
                {
                    id = item.ProductID,
                    lblProductName = item.ProductName,
                    lblProductDescription = item.Description,
                    productPicture = ResizeImg.ResizeImage(image, 100, 100),
                    lblProductPrice = item.Price.ToString("C0"),
                };

                p.Dock = DockStyle.Top;
                p.Padding = new Padding(10, 10, 10, 10);
                pProducts.Controls.Add(p);
            }
        }
        private void load_item_seller_by_category(int categoryID)
        {
            pProducts.Controls.Clear();
            List<ProductDTO> list = new ProductBL().GetProducts_byCategorieID(categoryID); // Lọc theo CategoryID
            Random random = new Random();

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
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                    image = Image.FromFile(imagePath);
                }

                Product_ItemDetail p = new Product_ItemDetail
                {
                    id = item.ProductID,
                    lblProductName = item.ProductName,
                    lblProductDescription = item.Description,
                    productPicture = ResizeImg.ResizeImage(image, 100, 100),
                    lblProductPrice = item.Price.ToString("C0"),
                };

                p.Dock = DockStyle.Top;
                p.Padding = new Padding(10, 10, 10, 10);
                pProducts.Controls.Add(p);
            }
        }


        private void FilterProductsBySeller(string query)
        {
            pProducts.Controls.Clear();

            // Lấy danh sách sản phẩm của seller
            List<ProductDTO> allProducts = new ProductBL().GetProducts_Seller();

            var filteredProducts = allProducts
                .Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.Trim().ToLower().Contains(query.Trim().ToLower())))
                .ToList();

            foreach (ProductDTO item in filteredProducts)
            {
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", item.ImagePath);
                Image image;

                if (File.Exists(imagePath))
                {
                    image = Image.FromFile(imagePath);
                }
                else
                {
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                    image = Image.FromFile(imagePath);
                }

                Product_ItemDetail p = new Product_ItemDetail
                {
                    id = item.ProductID,
                    lblProductName = item.ProductName,
                    lblProductDescription = item.Description,
                    productPicture = ResizeImg.ResizeImage(image, 100, 100),
                    lblProductPrice = item.Price.ToString("C0"),
                };

                p.Dock = DockStyle.Top;
                p.Padding = new Padding(10, 10, 10, 10);

                // Thêm sản phẩm vào panel
                pProducts.Controls.Add(p);
            }

            if (!filteredProducts.Any())
            {
                MessageBox.Show("Không tìm thấy sản phẩm nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = searchBar.Text.Trim();
            FilterProductsBySeller(searchQuery);
        }

        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void pProducts_Scroll(object sender, ScrollEventArgs e)
        {
            pProducts.Invalidate();
        }
        private void pProducts_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int adjustedWidth = pProducts.Width - SystemInformation.VerticalScrollBarWidth;

            g.DrawImage(backgroundBitmap, new Rectangle(0, 0, adjustedWidth, pProducts.Height));

            base.OnPaint(e);
        }

        private void btnMainFood_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnMainFood);
            load_item_seller_by_category(3);
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnDessert);
            load_item_seller_by_category(4);
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            SetButtonColor(btnDrink);
            load_item_seller_by_category(2);
        }
        private void SetButtonColor(Guna2Button clickedButton)
        {
            // Nếu có nút đã được chọn, đặt lại màu nền và màu chữ của nó về trạng thái ban đầu
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.White;
                selectedButton.ForeColor = Color.Gray;
            }

            clickedButton.AutoRoundedCorners = true;
            // Đặt màu nền của nút được nhấn là Gray và màu chữ là White
            clickedButton.BackColor = Color.Gray;
            clickedButton.ForeColor = Color.White;

            selectedButton = clickedButton;
        }
    }
}
