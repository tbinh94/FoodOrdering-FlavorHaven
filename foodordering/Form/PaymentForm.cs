using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace foodordering
{
    public partial class PaymentForm : Form
    {
        public double discountRate;
        public UserDTO user;
        public List<Item_Cart> listItem;
        public UserDTO seller;
        public ProductBL productBL;
        public List<Product_Payment_Form> formList;
        public List<ProductDTO> productDTOList;
        public List<String> productName;
        List<Tuple<int, int, decimal>> listProduct;

        private DiscountBL discountBL;
        public PaymentForm(List<Item_Cart> l)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            user = Form1.user;
            this.Width = flpFoodList.Width + 45;
            discountRate = 0;
            listItem = Cart.instance.products_choosed;
            seller = null;
            productBL = new ProductBL();
            formList = new List<Product_Payment_Form>();
            productDTOList = new List<ProductDTO>();
            productName = new List<String>();
            listProduct = new List<Tuple<int, int, decimal>>();
            discountBL = new DiscountBL();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblInfoUser.Text = user.Username + " | " + user.PhoneNumber;
            seller = new UserBL().getUser(productBL.GetProduct(listItem[0].id).SellerID, true);
            lblInfoSeller.Text = seller.Username;
            label8.Text = user.Address;
            foreach (var item in listItem)

            {
                createPPF(item.product.ProductName, item.id, item.lblProductPrice, item.lblproductSoLuong, item.productPicture);
                productDTOList.Add(item.product);
                productName.Add(item.product.ProductName);
            }
            loadflpExtraFood();
        }

        private void createPPF(string name, int id, string Price, string Sl, Image img)
        {
            Product_Payment_Form frm = new Product_Payment_Form()
            {
                lblname = name,
                Price = Price,
                SoLuong = "x" + Sl
            };
            Image i = ResizeImg.ResizeImage(img, frm.imgPb.Height, frm.imgPb.Width);
            frm.imgPb.Image = i;
            frm.TopLevel = false;
            frm.AutoSize = true;
            frm.Padding = new Padding(10, 10, 10, 10);
            frm.Width = flpFoodList.Width - 20;
            frm.Show();
            flpFoodList.Controls.Add(frm);
            listProduct.Add(new Tuple<int, int, decimal>(id, int.Parse(Sl), Math.Round(Decimal.Parse(Price, NumberStyles.Currency))));

            formList.Add(frm);
            setText();
        }
        private void setText()
        {
            int totalSl = 0;
            decimal total = 0;
            foreach (var item in formList)
            {
                totalSl += int.Parse(item.SoLuong.Substring(1));
                total += int.Parse(item.SoLuong.Substring(1)) * Decimal.Parse(item.Price, NumberStyles.Currency);
            }
            lblSl.Text = "Tổng giá món (" + totalSl.ToString() + " món)";
            txtTotalPrice.Text = total.ToString("C0");
            setTotal_Discount();

        }
        private void setTotal_Discount()
        {
            decimal total = Decimal.Parse(txtTotalPrice.Text, NumberStyles.Currency) * (1 - decimal.Parse(discountRate.ToString()));
            total = Math.Round(total, 2);
            btnOrder.Text = "Đặt đơn - (" + total + ")";
        }
        public static List<T> ShuffleList<T>(List<T> inputList)
        {
            Random random = new Random();
            return inputList.OrderBy(x => random.Next()).ToList();
        }
        private void loadflpExtraFood()
        {
            flpExtraFood.Controls.Clear();

            flpExtraFood.FlowDirection = FlowDirection.LeftToRight; // Hiển thị sản phẩm theo chiều ngang
            flpExtraFood.WrapContents = false;
            flpExtraFood.AutoScroll = true;

            List<ProductDTO> products = productBL.GetProducts_Seller(seller.Id)
                .Where(product => !productDTOList.Any(p => p.ProductName == product.ProductName))
                .ToList();
            List<ProductDTO> shuffledProducts = ShuffleList(new List<ProductDTO>(products));

            foreach (var productDto in shuffledProducts.Take(shuffledProducts.Count < 4 ? shuffledProducts.Count : 4))
            {
                ProductBL product = ProductBL.FromDTO(productDto);
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.Image);
                Image image;

                try
                {
                    if (System.IO.File.Exists(imagePath))
                    {
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                    else
                    {
                        imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải hình ảnh cho {product.Name}: {ex.Message}");
                    continue;
                }

                ProductItemControl productItem = new ProductItemControl
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price.ToString("C0"),
                    ProductDescription = product.Description,
                    ProductImage = ResizeImg.ResizeImage(image, 100, flpExtraFood.Height - 20), // Điều chỉnh chiều cao
                    Address = product.Address,
                    DiscountText = product.DiscountText,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10, 0, 10, 0),
                    BackColor = Color.FromArgb(230, 170, 170),
                    id = product.id,
                };

                productItem.cart.Hide();
                productItem.Width = 100;
                productItem.Height = flpExtraFood.Height - 20; // Fit với chiều cao của FlowLayoutPanel

                flpExtraFood.Controls.Add(productItem);

                productItem.ProductClicked += (sender, e) => addBtn(productDto);
                productItem.Cursor = Cursors.Hand;

                image.Dispose();
            }
        }


        private void addBtn(ProductDTO product)
        {
            string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.ImagePath);
            Image image;

            try
            {
                if (System.IO.File.Exists(imagePath))
                {
                    image = System.Drawing.Image.FromFile(imagePath);
                }
                else
                {
                    imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                    image = System.Drawing.Image.FromFile(imagePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            createPPF(product.ProductName, product.ProductID, product.Price.ToString(), "1", image);
            productDTOList.Add(product);
            loadflpExtraFood();
        }
        public void SetDiscountRate(double discountRate)
        {
            this.discountRate = discountRate;
            lblDiscount.Text = $"Giảm giá: {discountRate * 100:0.##}%";
            setTotal_Discount();
        }
        private void voucherPanel_Click(object sender, EventArgs e)
        {
            discountBL = new DiscountBL();
            // Lấy danh sách discount từ BL
            List<DiscountDTO> discounts = discountBL.GetActiveDiscounts();
            if (discounts == null || discounts.Count == 0)
            {
                MessageBox.Show("No active discounts available.");
                return;
            }

            // Hiển thị DiscountForm
            DiscountListForm discountForm = new DiscountListForm(this);
            discountForm.LoadDiscounts(discounts); // Load danh sách discount vào form
            discountForm.ShowDialog();
        }

        private void flpFoodList_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, flpFoodList.ClientRectangle,
                Color.DarkOrange, 2, ButtonBorderStyle.Solid,
                Color.DarkOrange, 2, ButtonBorderStyle.Solid,
                Color.DarkOrange, 2, ButtonBorderStyle.Solid,
                Color.DarkOrange, 2, ButtonBorderStyle.Solid);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (btnBank.Checked)
            {
                QRfrm f = new QRfrm();
                DialogResult a = f.ShowDialog();
                if (a == DialogResult.OK)
                {
                    OderDTO oder = new OderDTO
                    {
                        UserID = user.Id,
                        OderDate = DateTime.Now,
                        OrderItemsList = listProduct,
                        Total = Decimal.Parse(txtTotalPrice.Text, NumberStyles.Currency)
                    };
                    new OderBL().addOder(oder);
                    updateInventory();
                    this.Close();
                }
            }
            else if (btnCash.Checked)
            {
                OderDTO oder = new OderDTO
                {
                    UserID = user.Id,
                    OderDate = DateTime.Now,
                    OrderItemsList = listProduct,
                    Total = Decimal.Parse(txtTotalPrice.Text, NumberStyles.Currency)
                };
                new OderBL().addOder(oder);
                updateInventory();
                this.Close();
            }
            else
                MessageBox.Show("Vui lòng chọn phương thức thanh toán!");

        }

        private void btnBank_Click(object sender, EventArgs e)
        {
            btnBank.Checked = true;
            btnCash.Checked = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            btnBank.Checked = false;
            btnCash.Checked = true;
        }
        private void updateInventory()
        {
            int i = 0;
            foreach (var product in productDTOList)
            {
                if (new ProductBL().updateInventory(product.ProductID, product.Inventory - int.Parse(listItem[i].soluong.Text)))
                { }
                else
                { }

            }
        }

        private void PaymentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
