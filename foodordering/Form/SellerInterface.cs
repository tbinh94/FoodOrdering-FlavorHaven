using System;
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
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            // Đổi trạng thái ẩn/hiện
            isExpanded = !isExpanded;

            // Cập nhật trạng thái Visible cho các nút
            btnMyProducts.Visible = isExpanded;
            btnAddProduct.Visible = isExpanded;
        }

        private void SellerInterface_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Form1.LoggedInSellerName))
            {
                lblWelcome.Text = "Xin chào, " + Form1.LoggedInSellerName;
            }
            else
            {
                lblWelcome.Text = "Xin chào bạn!";
            }
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
        private void btnMyProducts_Click(object sender, EventArgs e)
        {
            Food_Seller_Form frm = new Food_Seller_Form(Form1.iduser);
            AddControlToPanel(frm);
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            save_productSeller_form frm = new save_productSeller_form(Form1.iduser);
            AddControlToPanel(frm);
        }
    }
}
