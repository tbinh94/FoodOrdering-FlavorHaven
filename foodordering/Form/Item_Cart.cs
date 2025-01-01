using Food_BL;
using Food_DTO;
using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace foodordering
{
    public partial class Item_Cart : Form
    {
        private Form1 _f;
        public Item_Cart()
        {
            InitializeComponent();
            _f = Application.OpenForms.OfType<Form1>().FirstOrDefault();

            productPic.SizeMode = PictureBoxSizeMode.Zoom;

            truSL.Image = ResizeImg.ResizeImage(Properties.Resources.minus, 20, 20);
            congSL.Image = ResizeImg.ResizeImage(Properties.Resources.plus, 20, 20);
            removeItem.Image = ResizeImg.ResizeImage(Properties.Resources.close, 20, 20);

            ConfigureImageButton(truSL); ConfigureImageButton(congSL); ConfigureImageButton(removeItem);
        }
        private void ConfigureImageButton(Guna2Button btn)
        {
            // Thiết lập kích thước button
            btn.Size = new Size(20, 20);

            // Thiết lập thuộc tính của Guna2Button
            btn.Text = "";
            btn.ImageAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent;
            btn.BorderThickness = 0;
            btn.FillColor = Color.Transparent;
            btn.HoverState.FillColor = Color.Transparent;
        }
        public int id { get; set; }
        public Guna2TextBox soluong { get => ProductSoLuong; set => ProductSoLuong = value; }
        public ProductDTO product { get; set; }
        public Image productPicture { get => productPic.Image; set => productPic.Image = value; }
        public string lblProductName { get => ProductName.Text; set => ProductName.Text = value; }
        public string lblProductPrice { get => ProductPrice.Text; set => ProductPrice.Text = value; }
        public string lblproductSoLuong { get => ProductSoLuong.Text; set => ProductSoLuong.Text = value; }
        public CheckBox checkBox { get => choosed; set => choosed = value; }
        public string lblInventory { get => inventory.Text; set => inventory.Text = value; }
        private void lblSLText_Click(object sender, EventArgs e)
        {

        }

        private void congSL_Click(object sender, EventArgs e)
        {
            ProductSoLuong.Text = (int.Parse(ProductSoLuong.Text) + 1).ToString();
        }

        private void truSL_Click(object sender, EventArgs e)
        {
            if (int.Parse(ProductSoLuong.Text) > 1)
                ProductSoLuong.Text = (int.Parse(ProductSoLuong.Text) - 1).ToString();
            else
            {
                removeItem_Click(sender, e);
            }


        }

        private void removeItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thực hiện không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (new CartBL().remove_Item_Cart(Form1.iduser, id))
                {
                    Cart.instance.listProduct.RemoveAll(l => l.ProductID == id);
                    this.Close();
                    _f.LoadProductItemControl();
                }
            }
            else
            {
            }
        }

        private void ProductSoLuong_TextChanged(object sender, EventArgs e)
        {
            int cursorPosition = ProductSoLuong.SelectionStart;
            if (ProductSoLuong.Text == "" || int.Parse(ProductSoLuong.Text) == 0)
            {
                ProductSoLuong.Text = "0";
                ProductSoLuong.SelectionStart = ProductSoLuong.Text.Length;
                ProductSoLuong.SelectionLength = 0;
                return;
            }
            int i = int.Parse(ProductSoLuong.Text);
            if ((ProductSoLuong.Text)[0] == '0')
                ProductSoLuong.Text = ProductSoLuong.Text.Substring(1);
            if (i > int.Parse(inventory.Text))
                ProductSoLuong.Text = inventory.Text;
            if (int.Parse(ProductSoLuong.Text) >= int.Parse(inventory.Text))
            {
                congSL.Enabled = false;
            }
            else
            {
                congSL.Enabled = true;
            }
            ProductSoLuong.SelectionStart = cursorPosition;

        }

        private void ProductSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không hợp lệ
            }

        }
    }
}
