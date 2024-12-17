using System;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class seller : Form
    {
        public seller()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            btnLogo.Image = ResizeImg.ResizeImage(Properties.Resources.logo, 140, 140);
            pic1.Image = ResizeImg.ResizeImage(Properties.Resources.store, 330, 200);
            ConfigureImage(pic1);
            ConfigureImageButton1(btnLogo);
            ConfigureImageButton2(help);

        }
        private void ConfigureImageButton1(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(100, 100);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
        }
        private void ConfigureImageButton2(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(60, 20);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }
        private void ConfigureImage(System.Windows.Forms.PictureBox pic)
        {
            pic.Size = new Size(500, 500);  // kích thước button

            pic.Text = "";
            pic.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Form1.Instance.Show();
        }

        private void seller_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void help_Click(object sender, EventArgs e)
        {
            Hide();
            HelpForm form = new HelpForm();
            form.Show();
        }

        private void seller_Load(object sender, EventArgs e)
        {
            //login frm = new login();
            //var panel1 = frm.Controls.Find("panel1", true).FirstOrDefault();
            //if (panel1 != null)
            //{
            //    panel1.Visible = false;
            //}

            //AddControlToPanel(frm);
        }
    }
}
