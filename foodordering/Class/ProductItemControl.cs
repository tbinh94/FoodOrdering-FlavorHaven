using Food_BL;
using System;
using System.Drawing;
using System.Windows.Forms;
using Guna;
using Guna.UI2.WinForms;
namespace foodordering
{
    public partial class ProductItemControl : UserControl
    {
        public event EventHandler ProductClicked;
        public Form1 _f;
        public ProductItemControl()
        {
            InitializeComponent();
            pictureBoxProduct.Click += ProductItemControl_Click_1;
            //_f = Application.OpenForms.OfType<Form1>().FirstOrDefault();
        }
        // Thuộc tính để thiết lập tên sản phẩm

        public Guna2PictureBox pI
        {
            get => pictureBoxProduct;
        }
        public Panel pn
        {
            get => panel1;
        }
        public new string ProductName
        {
            get => lblProductName.Text;
            set => lblProductName.Text = value;
        }

        // Thuộc tính để thiết lập giá sản phẩm
        public string ProductPrice
        {
            get => lblProductPrice.Text;
            set => lblProductPrice.Text = value;
        }

        // Thuộc tính để thiết lập mô tả sản phẩm
        public string ProductDescription
        {
            get => lblProductDescription.Text;
            set => lblProductDescription.Text = value;
        }

        public string setTextCart
        {
            get => addCart.Text;
            set => addCart.Text = value;
        }

        // Thuộc tính để thiết lập hình ảnh sản phẩm
        public Image ProductImage
        {
            get => pictureBoxProduct.Image;
            set => pictureBoxProduct.Image = value;
        }
        public Guna2PictureBox pbx
        {
            get => pictureBoxProduct;
            set => pictureBoxProduct = value;
        }

        public Button cart
        {
            get => addCart;
            set => addCart = value;
        }
        // Thuộc tính để thiết lập trạng thái yêu thích
        public bool IsFavorite
        {
            get => btnFavorite.Visible;
            set => btnFavorite.Visible = value;
        }

        // Thuộc tính để thiết lập giảm giá
        public string DiscountText
        {
            get => lblDiscount.Text;
            set => lblDiscount.Text = value;
        }
        public string Address
        {
            get => lblAddress.Text;
            set => lblAddress.Text = value;
        }
        private int _id;
        public int id { get => _id; set => _id = value; }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{ProductName} đã được thêm vào danh sách yêu thích!");
        }

        private void ProductItemControl_Load(object sender, EventArgs e)
        {
            addCart.Click += addCart_Click;
        }
        private void ProductItemControl_Click_1(object sender, EventArgs e)
        {
            ProductClicked?.Invoke(this, e);

        }
        private void addCart_Click1(object sender, EventArgs e)
        {

        }
        private void addCart_Click(object sender, EventArgs e)
        {
            //Cart cart = new Cart(Form1.Instance.list);
            //_f = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            //if (new CartBL().check_Exist(Form1.iduser, id))
            //{
            //    cart = new Cart(Form1.Instance.list);
            //}
            //else if (new CartBL().add_Item_Cart(Form1.iduser, id))
            //{
            //    Form1.Instance.list = new CartBL().GetCart(Form1.iduser);
            //    cart = new Cart(Form1.Instance.list);
            //    addCart.Text = "🛍️";
            //}
            //_f.Enabled = false;
            //DialogResult dialog = cart.ShowDialog();
            //if (dialog == DialogResult.OK)
            //{
            //    _f.Enabled = true;
            //}

            CartBL cartBL = new CartBL();
            if (cartBL.check_Exist(Form1.iduser, id))
            {
                MessageBox.Show("Sản phẩm đã có trong giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cartBL.add_Item_Cart(Form1.iduser, id))
            {
                Form1.Instance.list = cartBL.GetCart(Form1.iduser);
                addCart.Text = "🛍️";
            }
        }
    }
}
