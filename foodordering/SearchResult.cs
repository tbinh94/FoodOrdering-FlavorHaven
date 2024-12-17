using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace foodordering
{
    public partial class SearchResult : Form
    {
        private bool isExpanded = false;
        private List<ProductDTO> filteredProducts;


        public SearchResult(List<ProductDTO> products)
        {
            InitializeComponent();
            filteredProducts = products;

            LoadFilteredProducts(filteredProducts);

        }
        private void LoadFilteredProducts(List<ProductDTO> products)
        {
            //containerPanel.Controls.Clear(); // Xóa sản phẩm cũ

            foreach (var product in products)
            {
                // Tạo ProductItemControl cho từng sản phẩm
                ProductItemControl item = new ProductItemControl
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.Price.ToString("C0"),
                    ProductDescription = product.Description,
                    ProductImage = LoadProductImage(product.ImagePath), // Phương thức riêng để tải ảnh
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10, 10, 10, 20),
                    BackColor = Color.LightGray, // Màu nền
                };

                // Gắn sự kiện click
                item.ProductClicked += (s, e) =>
                {
                    // Hành động khi click vào sản phẩm
                    MessageBox.Show($"Món: {product.ProductName}, Giá: {product.Price:C0}");
                };

                // Thêm vào containerPanel
                containerPanel.Controls.Add(item);
            }

            // Kiểm tra nếu không có sản phẩm
            if (products.Count == 0)
            {
                MessageBox.Show("Không tìm thấy món ăn nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Image LoadProductImage(string imageName)
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", imageName);
            if (File.Exists(imagePath))
            {
                return Image.FromFile(imagePath);
            }

            // Trả về ảnh mặc định nếu không tìm thấy
            return Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "default.png"));
        }

        string[] areas = { "Quận 6", "Quận 7", "Quận 8", "Quận 9", "Quận 10", "Quận 11",
                               "Quận 12", "Bình Thạnh", "Bình Tân", "Phú Nhuận",
                               "Thành phố Thủ Đức", "Bình Chánh", "Cần Giờ",
                               "Củ Chi", "Tân Bình", "Tân Phú", "Hóc Môn", "Nhà Bè" };
        string[] cate = { "Đồ ăn nhanh", "Đồ uống", "Món ăn chính", "Tráng miệng", "Đồ chay", "Khai vị", "Đồ hải sản",
                "Salad", "Súp", "Bánh ngọt" };

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            panelCbox.Visible = isExpanded;

            if (isExpanded)
            {
                LoadCheckBoxes(areas);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            panelCbox.Visible = isExpanded;

            if (isExpanded)
            {
                LoadCheckBoxes(cate);
            }
        }
        private void LoadCheckBoxes(string[] items)
        {
            panelCbox.WrapContents = true; // Tự động xuống dòng
            panelCbox.AutoScroll = true;   // Thêm thanh cuộn nếu cần
            panelCbox.FlowDirection = FlowDirection.LeftToRight;

            int maxPerRow = 3; // Số CheckBox mỗi dòng
            int panelWidth = panelCbox.Width;
            int checkboxWidth = panelWidth / maxPerRow - 10; // Trừ khoảng cách để căn đều
            // Xóa các CheckBox cũ trong Panel
            panelCbox.Controls.Clear();

            // Thêm các CheckBox mới vào Panel
            foreach (string item in items)
            {
                CheckBox cb = new CheckBox();
                cb.Text = item;
                cb.AutoSize = true;
                cb.Margin = new Padding(10); // Tạo khoảng cách giữa các checkbox
                panelCbox.Controls.Add(cb);
            }
        }


    }
}
