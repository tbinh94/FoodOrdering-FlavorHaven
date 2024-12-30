using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace foodordering
{
    public partial class Food_Seller_Form : Form
    {
        public int id;
        public List<ProductDTO> products;
        public Food_Seller_Form(int i)
        {
            InitializeComponent();
            id = i;
            tLP.ColumnCount = 4;
            products = new ProductBL().GetProducts_Seller(i);
            tLP.Dock = DockStyle.Fill;
            tLP.AutoSize = true;
            tLP.AutoScroll = true;
            //tLP.HorizontalScroll.Visible = false;
            tLP.RowCount = products.Count / tLP.ColumnCount;
            tLP.AutoScrollMinSize = new Size(1, 1);
            this.Width = SellerInterface.Instance.containerpn.Width;
            this.Resize += (sender, e) =>
            {
                // Tính toán số lượng cột và hàng và cập nhật TableLayoutPanel
                AddElementsToTableLayout(id);
            };
        }

        private void FoodCategoryForm_Load(object sender, EventArgs e)
        {
            AddElementsToTableLayout(id);
        }
        private void AddElementsToTableLayout(int id)
        {
            tLP.Controls.Clear();
            int columnCount = 4; //  int columnCount = SellerInterface.Instance.containerpn.Width / 300;
            int rowCount = (int)Math.Ceiling((double)products.Count / columnCount); // products.Count/columnCount;

            columnCount = (columnCount == 0) ? 1 : columnCount;
            rowCount = (rowCount == 0) ? 1 : rowCount;
            if (columnCount == 1)
                rowCount = products.Count;
            tLP.ColumnCount = columnCount;
            tLP.RowCount = rowCount;
            // Cài đặt chiều rộng cột và chiều cao hàng
            tLP.ColumnStyles.Clear();
            tLP.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                tLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnCount));
            }

            //for (int i = 0; i < rowCount; i++)
            //{
            //    tLP.RowStyles.Add(new RowStyle(SizeType.Absolute, 500));
            //}
            int x = 0;
            for (int row = 0; row < rowCount; row++)
            {
                int sizerow = 0;
                for (int col = 0; col < columnCount; col++)
                {
                    if (x == products.Count)
                        break;
                    var productDto = products[x];
                    ProductBL product = ProductBL.FromDTO(productDto);

                    // Tạo đường dẫn đến folder ProductImage trong Resources
                    string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.Image);
                    Image image;

                    try
                    {
                        if (System.IO.File.Exists(imagePath))
                        {
                            image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            // Nếu không tìm thấy file, dùng hình mặc định
                            imagePath = Path.Combine(Application.StartupPath, "Resources", "1.jpg");
                            image = Image.FromFile(imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh cho {product.Name}: {ex.Message}");
                        continue; // Bỏ qua sản phẩm này nếu không load được hình
                    }

                    // Tạo các ProductItemControl với hình ảnh tương ứng
                    ProductItemControl productItems = new ProductItemControl
                    {
                        ProductName = product.Name,
                        ProductPrice = product.Price.ToString("C0"),
                        ProductDescription = product.Description,
                        ProductImage = ResizeImg.ResizeImage(image, 381, 310),
                        Address = product.Address,
                        DiscountText = product.DiscountText,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.FromArgb(230, 170, 170),
                        id = product.id,
                    };
                    //float scaleX = 100f / columnCount;
                    //float scaleY = 100f / rowCount;
                    sizerow = productItems.Width;
                    //productItems.Width = (int)(productItems.Width * scaleX);
                    //productItems.Height = (int)(productItems.Height * scaleY);
                    productItems.Dock = DockStyle.None;
                    productItems.Anchor = AnchorStyles.None;
                    productItems.Enabled = true;
                    productItems.cart.Hide();
                    productItems.pbx.Click += (_, __) =>
                    {
                        AddControlToPanel(new edit_productSeller_form(product.id));
                    };
                    ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
                    contextMenuStrip.Items.Add("Chỉnh sửa sản phẩm", null, (_, __) =>
                    {
                        AddControlToPanel(new edit_productSeller_form(product.id));
                    });

                    contextMenuStrip.Items.Add("Ngừng bán sản phẩm này", null, (_, __) =>
                    {
                        deleteProduct(product.id);
                    });
                    productItems.ContextMenuStrip = contextMenuStrip;
                    //productItems.AutoSize = true;
                    // Thêm vào các panel
                    tLP.Controls.Add(productItems, col, row);
                    productItems.Cursor = Cursors.Hand;
                    // Giải phóng image gốc sau khi đã resize
                    image.Dispose();
                    x++;
                }
                tLP.RowStyles.Add(new RowStyle(SizeType.Absolute, sizerow));
            }
            tLP.RowCount += 1;
            int them = products.Count * 10 / columnCount;
            tLP.RowStyles.Add(new RowStyle(SizeType.Absolute, them));

        }
        public void FilterProducts(string searchQuery)
        {
            var filteredProducts = products
                .Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) &&
                     p.ProductName.Trim().ToLower().Contains(searchQuery.Trim().ToLower())) ||
                    (!string.IsNullOrEmpty(p.Description) &&
                     p.Description.Trim().ToLower().Contains(searchQuery.Trim().ToLower())))
                .ToList();

            if (!filteredProducts.Any())
            {
                MessageBox.Show("Thông tin tìm kiếm không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            products = filteredProducts;
            AddElementsToTableLayout(id);
        }
        private void AddControlToPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(form);
            form.Show();
        }

        private void deleteProduct(int i)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (new ProductBL().remove_product(i))
                {
                    products = new ProductBL().GetProducts_Seller(id);
                    AddElementsToTableLayout(id);
                }
            }
        }

        private void discount(int i)
        {

        }
    }
}


