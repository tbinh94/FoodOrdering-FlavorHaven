using System;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class Policies : Form
    {
        public Policies()
        {
            InitializeComponent();

            contactBtn.Image = ResizeImg.ResizeImage(Properties.Resources.tele_icon, 40, 40);
            btnLogo.Image = ResizeImg.ResizeImage(Properties.Resources.logo, 140, 140);
            ConfigureImageButton(btnLogo);
            contactBtn.BackColor = Color.Transparent;

        }


        private void ConfigureImageButton(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(100, 100);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Form1.Instance.Show();
        }

        private void Policies_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
