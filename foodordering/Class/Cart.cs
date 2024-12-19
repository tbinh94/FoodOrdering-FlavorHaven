using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace foodordering
{
    public partial class Cart : Form
    {
        public static Cart instance;
        public List<CartDTO> listProduct;
        public List<List<Item_Cart>> products_oder_by_seller;
        public List<Item_Cart> products_choosed;
        private CancellationTokenSource cancellationTokenSource;
        public Cart(List<CartDTO> l)
        {
            InitializeComponent();
            products_oder_by_seller = new List<List<Item_Cart>>();
            products_choosed = new List<Item_Cart>();
            fLP1.FlowDirection = FlowDirection.TopDown;
            fLP1.WrapContents = false;
            fLP1.AutoScroll = true;
            instance = this;
            listProduct = l;
            loadProduct(l);
        }

        public void loadProduct(List<CartDTO> list)
        {
            fLP1.Controls.Clear();
            List<int> idp = new List<int>();
            List<ProductDTO> p = new List<ProductDTO>();
            for (int i = 0; i < list.Count; i++)
            {
                p.Add(new ProductBL().GetProduct(list[i].ProductID));
                idp.Add(p[p.Count - 1].SellerID);
            }
            idp = idp.Distinct().ToList();
            List<int> checkp = new List<int>();
            for (int i = idp.Count - 1; i >= 0; i--)
            {
                List<Item_Cart> p1 = new List<Item_Cart>();
                FlowLayoutPanel flow = new FlowLayoutPanel()
                {
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    BorderStyle = BorderStyle.FixedSingle,
                    WrapContents = false,
                };
                FlowLayoutPanel panel = new FlowLayoutPanel();
                CheckBox checkBox = new CheckBox()
                {
                    Name = "choosed",
                    AutoSize = true,
                };

                checkBox.CheckedChanged += (sender, e) => CheckBox_CheckedChanged(checkBox, flow, sender, e);
                panel.Controls.Add(checkBox);

                UserDTO user = new UserBL().getUser(idp[i], true);
                Label tx = new Label()
                {
                    Text = user.Username,
                };
                panel.Controls.Add(tx);
                panel.Height = tx.Height + 5;
                panel.Padding = new Padding(5);
                flow.Controls.Add(panel);

                for (int j = list.Count - 1; j >= 0; j--)
                {
                    if (checkp.Contains(j) || p[j].SellerID != idp[i])
                        continue;
                    CartDTO cart = list[j];
                    ProductDTO product = new ProductBL().GetProductCart(cart.ProductID, Form1.iduser);
                    string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.ImagePath);
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

                    Item_Cart item_Cart = new Item_Cart
                    {
                        id = cart.ProductID,
                        productPicture = image,
                        lblProductName = product.ProductName,
                        lblProductPrice = product.Price.ToString("C0"),
                        lblproductSoLuong = cart.SoLuong.ToString(),
                        lblInventory = product.Inventory.ToString(),
                        product = product,

                    };
                    item_Cart.soluong.TextChanged += Soluong_TextChanged;
                    item_Cart.checkBox.CheckedChanged += (sender, e) => CheckBox_CheckedChanged(item_Cart, sender, e);
                    item_Cart.FormClosed += (sender, e) => Item_Cart_FormClosed(item_Cart, sender, e);
                    item_Cart.TopLevel = false;
                    //item_Cart.Dock = DockStyle.Fill;
                    //item_Cart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    item_Cart.AutoSize = true;
                    //item_Cart.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    item_Cart.Padding = new Padding(10, 10, 10, 10);
                    item_Cart.Width = fLP1.Width - 30;
                    flow.Controls.Add(item_Cart);
                    item_Cart.Show();
                    p1.Add(item_Cart);

                }
                products_oder_by_seller.Add(p1);
                fLP1.Controls.Add(flow);
            }
        }

        private void Item_Cart_FormClosed(Item_Cart itemcart, object sender, FormClosedEventArgs e)
        {
            products_choosed.Remove(itemcart);
            FlowLayoutPanel panel = itemcart.Parent as FlowLayoutPanel;
            int count = 0;
            foreach (Control control in panel.Controls)
            {
                if (control is Item_Cart)
                {
                    count++;
                }
            }
            if (count ==1 )
                fLP1.Controls.Remove(panel);
            setText();
            setTotal();

        }

        private async void Soluong_TextChanged(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            try
            {

                await Task.Delay(1000, token);
                setTotal();

            }
            catch (TaskCanceledException)
            {

            }
        }

        private void CheckBox_CheckedChanged(CheckBox checkB, FlowLayoutPanel flowLayoutPanel, object sender, EventArgs e)
        {

            foreach (Control control in flowLayoutPanel.Controls)
            {
                if (control is Item_Cart cart)
                {
                    cart.checkBox.Checked = checkB.Checked;
                }
            }

        }

        private void Cart_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public void CheckBox_CheckedChanged(Item_Cart itemCart, object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            if (cb.Checked == true)
            {
                products_choosed.Add(itemCart);
                check_choosed(itemCart);

            }
            else
            {
                products_choosed.Remove(itemCart);
                FlowLayoutPanel p = itemCart.Parent as FlowLayoutPanel;
                foreach (Control control in p.Controls)
                {
                    if (control is FlowLayoutPanel flp)
                    {
                        foreach (Control control2 in flp.Controls)
                        {
                            if (control2 is CheckBox checkbox)
                            {
                                checkbox.Checked = false;
                            }
                        }
                    }
                }
            }
            setText();
        }
        public void setText()
        {
            btn_buy.Text = "Mua hàng (" + products_choosed.Count + ")";

        }
        public void setTotal()
        {
            decimal total = 0;
            foreach (var item in products_choosed)
            {
                total += int.Parse(item.lblproductSoLuong) * item.product.Price;
            }
            lblTotal.Text = total.ToString("C0");
        }

        public void check_choosed(Item_Cart itemCart)
        {
            int id = itemCart.product.SellerID;

            foreach (var itemlist in products_oder_by_seller)
            {
                if (itemlist[0].product.SellerID == id)
                {
                    bool check = true;
                    foreach (var item in itemlist)
                    {
                        if (item.checkBox.Checked == false)
                        {
                            check = false;
                        }
                    }
                    if (check)
                    {
                        FlowLayoutPanel p = itemlist[0].Parent as FlowLayoutPanel;
                        foreach (Control control in p.Controls)
                        {
                            if (control is FlowLayoutPanel flp)
                            {
                                foreach (Control control2 in flp.Controls)
                                {
                                    if (control2 is CheckBox checkbox)
                                    {
                                        checkbox.Checked = true;
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }

        private void btn_buy_TextChanged(object sender, EventArgs e)
        {
            Soluong_TextChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var item in fLP1.Controls)
            {

                if (item is FlowLayoutPanel flpinFLP1)
                {
                    foreach (Control control in flpinFLP1.Controls)
                    {
                        if (control is FlowLayoutPanel flpcheckBox)
                        {
                            foreach (Control ct in flpcheckBox.Controls)
                            {
                                if (ct is CheckBox checkBox)
                                {
                                    checkBox.Checked = checkBoxAll.Checked;
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
