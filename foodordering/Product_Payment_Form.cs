using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace foodordering
{
    public partial class Product_Payment_Form : Form
    {
        public Product_Payment_Form()
        {
            InitializeComponent();
        }
        public string lblname { get => lblName.Text; set => lblName.Text= value; }
        public Image  imgP { get => img.Image; set => img.Image = value; }
        public PictureBox imgPb { get => img; set => img = value; }

        public string Price { get => lblPrice.Text; set => lblPrice.Text = value; }
        public string SoLuong { get => lblSoLuong.Text;set => lblSoLuong.Text = value; }

    }
}
