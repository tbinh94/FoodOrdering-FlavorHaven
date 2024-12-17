using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class Product_ItemDetail : UserControl
    {
        public Product_ItemDetail()
        {
            InitializeComponent();
            //productPic.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public int id { get; set; }

        public Image productPicture { get => productPic.Image; set => productPic.Image = value; }
        public string lblProductName { get => ProductName.Text; set => ProductName.Text = value; }
        public string lblProductPrice { get => ProductPrice.Text; set => ProductPrice.Text = value; }
        public string lblProductDescription { get => ProductDescription.Text; set => ProductDescription.Text = value; }
    }
}
