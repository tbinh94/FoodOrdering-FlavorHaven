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
    public partial class QRfrm : Form
    {
        public QRfrm()
        {
            InitializeComponent();
            pictureBox1.Image = ResizeImg.ResizeImage(Properties.Resources.QRcode, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bthHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
