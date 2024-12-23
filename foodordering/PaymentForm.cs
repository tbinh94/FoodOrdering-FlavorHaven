using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Food_BL;
using Food_DTO;
namespace foodordering
{
    public partial class PaymentForm : Form
    {
        public UserDTO user;
        public List<Item_Cart> listItem;
        public UserDTO seller;
        public ProductBL productBL;
        public List<Product_Payment_Form> formList;
        public List<ProductDTO> productDTOList;
        public List<String> productName;
        private DiscountBL discountBL;
        public PaymentForm(List<Item_Cart> l)
        {
            InitializeComponent();
            user = Form1.user;
            listItem = l;
            seller = null;
            productBL = new ProductBL();
            formList = new List<Product_Payment_Form>();
            productDTOList = new List<ProductDTO>();
            productName = new List<String>();
            discountBL = new DiscountBL();
        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            lblInfoUser.Text = user.Username + " | " + user.PhoneNumber;
            seller = new UserBL().getUser(productBL.GetProduct(listItem[0].id).SellerID, true);
            lblInfoSeller.Text = seller.Username;
            lblSl.Text = "Tổng giá món (" + listItem.Count + " món)";
            decimal total = 0;
            foreach (var item in listItem)
            {
                //total += int.Parse(item.lblproductSoLuong) * item.product.Price;
            }
            txtTotalPrice.Text = total.ToString("C0");
            foreach (var item in listItem) 
            {
                createPPF(item.ProductName, item.lblProductPrice, item.lblproductSoLuong, item.productPicture);
                productDTOList.Add(item.product);
                productName.Add(item.product.ProductName);
            }
            loadflpExtraFood();
        }

        private void createPPF(string name, string Price, string Sl ,Image img)
        {
            Product_Payment_Form frm = new Product_Payment_Form()
            {
                lblname =name,
                Price = Price,
                SoLuong = "x" + Sl
            };
            Image i = ResizeImg.ResizeImage(img, frm.imgPb.Height, frm.imgPb.Width);
            frm.imgPb.Image = i;
            frm.TopLevel = false;
            frm.AutoSize = true;
            frm.Padding = new Padding(10, 10, 10, 10);
            frm.Width = flpFoodList.Width - 30;
            frm.Show();
            flpFoodList.Controls.Add(frm);
            formList.Add(frm);
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
                    if (File.Exists(imagePath))
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
                if (File.Exists(imagePath))
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
                return;
            }

            createPPF(product.ProductName, product.Price.ToString(), "1", image);
            productDTOList.Add(product);
            loadflpExtraFood();
        }
        public void SetDiscountRate(double discountRate)
        {
            lblDiscount.Text = $"Giảm giá: {discountRate * 100:0.##}%";
        }
        private void voucherPanel_Click(object sender, EventArgs e)
        {
            discountBL = new DiscountBL();
            // Lấy danh sách discount từ BL
            List<DiscountDTO> discounts = discountBL.GetActiveDiscounts();

            // Hiển thị DiscountForm
            DiscountListForm discountForm = new DiscountListForm(this);
            discountForm.LoadDiscounts(discounts); // Load danh sách discount vào form
            discountForm.ShowDialog();
        }
    }
}
