using System;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class SellerInterface : Form
    {
        private bool isExpanded = false;
        public string name;
        public Panel containerpn;
        private static SellerInterface _instance;
        public static SellerInterface Instance // xài này thay cho instance = this sẽ tránh lỗi
        {
            get
            {
                if (_instance == null)
                    _instance = new SellerInterface();
                return _instance;
            }
        }
        public SellerInterface()
        {
            InitializeComponent();
            name = lblWelcome.ToString();
            containerpn = containerPanel;
            DoubleBuffering(containerPanel);
        }
        private void DoubleBuffering(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }
        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Đổi trạng thái ẩn/hiện
            isExpanded = !isExpanded;

            // Cập nhật trạng thái Visible cho các nút
            btnMyProducts.Visible = isExpanded;
            btnAddProduct.Visible = isExpanded;
        }
        private void AddControlToPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(form);
            form.Show();
        }
        public void btnMyProducts_Click(object sender, EventArgs e)
        {
            MyProducts();
        }
        public void MyProducts()
        {
            Food_Seller_Form frm = new Food_Seller_Form(Form1.iduser);
            AddControlToPanel(frm);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            save_productSeller_form frm = new save_productSeller_form(Form1.iduser);
            AddControlToPanel(frm);
        }

        private void SellerInterface_Load(object sender, EventArgs e)
        {
            label1.Text = "Xin chào " + Form1.user.Username + "!";
        }

        private void SellerInterface_Resize(object sender, EventArgs e)
        {
            int panelLeftWidth = (int)(SellerInterface.Instance.Width * 0.2);


            leftPanel.Width = panelLeftWidth;
            leftPanel.Height = this.ClientSize.Height;
            leftPanel.Location = new Point(0, 0);

            containerPanel.Width = this.ClientSize.Width - panelLeftWidth;
            containerPanel.Location = new Point(leftPanel.Right, 0);

            containerPanel.Height = SellerInterface.Instance.Height;

            AdjustRightPanelLayout();
        }
        private void AdjustRightPanelLayout()
        {
            foreach (System.Windows.Forms.Control ctrl in containerPanel.Controls)
            {
                if (ctrl is FlowLayoutPanel flp)
                {
                    flp.Width = containerPanel.ClientSize.Width - 10;
                    flp.Margin = new Padding(5);

                }
            }
        }
    }
}
