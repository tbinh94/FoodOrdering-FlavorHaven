using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class AdItem : UserControl
    {
        public event EventHandler AdClicked;

        public AdItem()
        {
            InitializeComponent();
        }
        public Guna2PictureBox AdImageBox
        {
            get => pictureBoxAd;
        }

        public Panel AdPanel
        {
            get => panel1;
        }

        public string DiscountDescription
        {
            get => lblAdDescription.Text;
            set => lblAdDescription.Text = value;
        }
        public Image AdImage
        {
            get => pictureBoxAd.Image;
            set => pictureBoxAd.Image = value;
        }

        private int _id;
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public void UpdateAdItem(int discountId, string discountName, string discountValue, string description, string expiryDate, string imagePath)
        {
            Id = discountId;
            DiscountDescription = description;
            AdImage = Image.FromFile(imagePath);
        }
    }

}
