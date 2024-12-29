﻿using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace foodordering
{
    public partial class ProductSearchForm : Form
    {
        public List<ProductDTO> products;
        private List<ProductDTO> filteredProducts;
        private HashSet<string> selectedDistricts = new HashSet<string>();
        private ProductBL productBL;
        private string currentSearchQuery = string.Empty;
        public string SearchText { get; private set; } = string.Empty;
        private List<ProductDTO> initialSearchResults;

        public ProductSearchForm()
        {
            InitializeComponent();
            products = new ProductBL().GetAllProducts(); // Lấy tất cả sản phẩm
            productBL = new ProductBL();
            tLP.ColumnCount = 4;
            tLP.Dock = DockStyle.Fill;
            tLP.AutoSize = true;
            tLP.AutoScroll = true;
            tLP.RowCount = products.Count / tLP.ColumnCount;
            tLP.AutoScrollMinSize = new Size(1, 1);
            this.Width = SellerInterface.Instance.containerpn.Width;
            this.Resize += (sender, e) =>
            {
                AddElementsToTableLayout();
            };
            DoubleBuffering(tLP);

        }
        private void DoubleBuffering(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }
        private void AddElementsToTableLayout()
        {
            tLP.Controls.Clear();
            int columnCount = 4;
            int rowCount = (int)Math.Ceiling((double)products.Count / columnCount);
            columnCount = (columnCount == 0) ? 1 : columnCount;
            rowCount = (rowCount == 0) ? 1 : rowCount;
            if (columnCount == 1) rowCount = products.Count;

            tLP.ColumnCount = columnCount;
            tLP.RowCount = rowCount;
            tLP.ColumnStyles.Clear();
            tLP.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                tLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnCount));
            }

            int x = 0;
            for (int row = 0; row < rowCount; row++)
            {
                int sizerow = 0;
                for (int col = 0; col < columnCount; col++)
                {
                    if (x == products.Count) break;

                    var productDto = products[x];
                    ProductBL product = ProductBL.FromDTO(productDto);
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
                            imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                            image = Image.FromFile(imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh cho {product.Name}: {ex.Message}");
                        continue;
                    }
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
                    productItems.ProductClicked += ProductItem_ProductClicked;

                    sizerow = productItems.Width;
                    productItems.Dock = DockStyle.None;
                    productItems.Anchor = AnchorStyles.None;

                    tLP.Controls.Add(productItems, col, row);
                    productItems.Cursor = Cursors.Hand;

                    image.Dispose();
                    x++;
                }
                tLP.RowStyles.Add(new RowStyle(SizeType.Absolute, sizerow));
            }
            tLP.RowCount += 1;
        }

        private void ProductItem_ProductClicked(object sender, EventArgs e)
        {
            if (sender is ProductItemControl productItem)
            {
                string productName = productItem.ProductName;
                string productPrice = productItem.ProductPrice;
                string address = productItem.Address;
                System.Drawing.Image productImage = productItem.ProductImage;
                Random random = new Random();
                int randomRating = random.Next(1, 6);

                ItemDetail form2 = new ItemDetail();
                form2.SetProductDetails(productName, productPrice, address, productImage, randomRating);
                AddControlToPanel(form2);


            }
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

        public void FilterProducts(string searchQuery)
        {
            var filteredProducts = products
                .Where(p =>
                    (string.IsNullOrEmpty(searchQuery) ||
                     (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.Trim().ToLower().Contains(searchQuery.Trim().ToLower())) ||
                     (!string.IsNullOrEmpty(p.Description) && p.Description.Trim().ToLower().Contains(searchQuery.Trim().ToLower()))))
                .ToList();

            if (!filteredProducts.Any())
            {
                MessageBox.Show("Thông tin tìm kiếm không phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            initialSearchResults = new List<ProductDTO>(filteredProducts); // Lưu lại kết quả ban đầu
            products = filteredProducts;
            AddElementsToTableLayout();
        }

        public void FilterByDistricts(HashSet<string> districts)
        {
            if (districts.Count == 0)
            {
                products = new List<ProductDTO>(initialSearchResults);
            }
            else
            {
                // Lọc từ kết quả tìm kiếm ban đầu
                products = initialSearchResults
                    .Where(p => districts.Contains(p.Address))
                    .ToList();
            }

            if (!products.Any())
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            AddElementsToTableLayout();
        }
        public void ApplyFilters(HashSet<string> districts)
        {
            selectedDistricts = districts;

            // Bắt đầu với tất cả sản phẩm
            filteredProducts = products;

            // Áp dụng lọc theo từ khóa tìm kiếm đã lưu trước
            if (!string.IsNullOrEmpty(currentSearchQuery))
            {
                filteredProducts = productBL.FilterProductsBySearch(filteredProducts, currentSearchQuery);
            }

            // Áp dụng lọc theo quận nếu có
            if (districts.Count > 0)
            {
                filteredProducts = productBL.FilterProductsByDistrict(filteredProducts, districts);
            }

            if (!filteredProducts.Any())
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DisplayFilteredProducts();
        }

        public void ApplyFilters(string searchQuery)
        {
            currentSearchQuery = searchQuery; // Lưu lại từ khóa tìm kiếm

            // Bắt đầu với tất cả sản phẩm
            filteredProducts = products;

            // Áp dụng lọc theo từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchQuery))
            {
                filteredProducts = productBL.FilterProductsBySearch(filteredProducts, searchQuery);
            }

            // Áp dụng lọc theo quận/huyện nếu có
            if (selectedDistricts.Count > 0)
            {
                filteredProducts = productBL.FilterProductsByDistrict(filteredProducts, selectedDistricts);
            }

            if (!filteredProducts.Any())
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp!", "Thông báo",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DisplayFilteredProducts();
        }

        private void DisplayFilteredProducts()
        {
            products = filteredProducts;
            AddElementsToTableLayout();
        }

        private void tLP_Paint(object sender, PaintEventArgs e)
        {
            var bounds = new Rectangle(Point.Empty, tLP.DisplayRectangle.Size);

            // Tạo LinearGradientBrush cho gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(bounds,                                        
                Color.FromArgb(255, 123, 104, 238), // Màu tím nhạt
                Color.FromArgb(255, 70, 130, 180),  // Màu xanh dương
                LinearGradientMode.Vertical))                 // Hướng gradient (theo chiều dọc)
            {
                e.Graphics.FillRectangle(brush, bounds);      
            }
        }
    }
}
