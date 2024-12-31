using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace foodordering
{
    public partial class OderPerItem : UserControl
    {
        public OderDTO order;

        public OderPerItem(OderDTO o)
        {
            InitializeComponent();
            order = o;
        }
        private Product_Payment_Form createPPF(string name, int id, string Price, string Sl, Image img)
        {
            Product_Payment_Form frm = new Product_Payment_Form()
            {
                lblname = name,
                Price = Price,
                SoLuong = "x" + Sl
            };
            Image i = ResizeImg.ResizeImage(img, frm.imgPb.Height, frm.imgPb.Width);
            frm.imgPb.Image = i;
            frm.TopLevel = false;
            frm.AutoSize = true;
            frm.Padding = new Padding(10);
            return frm;
        }

        private void OderPerItem_Load(object sender, EventArgs e)
        {
            int i = panel1.Height + panel3.Height;
            UserDTO user = new UserBL().getUser(new ProductBL().GetProduct(order.OrderItemsList[0].Item1).SellerID, true);
            foreach (var item in order.OrderItemsList)
            {
                ProductDTO product = new ProductBL().GetProduct(item.Item1);
                Product_Payment_Form frm = createPPF(product.ProductName, product.ProductID, item.Item3.ToString(), item.Item2.ToString(), Image.FromFile(Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.ImagePath)));
                fLP.Controls.Add(frm);
                frm.Show();
                i += frm.Height + 10;
            }
            this.Height = i;
            total.Text = "Tổng tiền: " + order.Total.ToString();
            this.Width += 20;
            
            shopName.Text = user.Username;
            time.Text = order.OderDate.ToString("HH:mm:ss dd-MM-yyyy");
            //fLP.VerticalScroll.Enabled = false;
            //fLP.VerticalScroll.Visible = false;
            this.Refresh();
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnRebuy_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void borderButton1_Click(object sender, EventArgs e)
        {
            odersHistory frm = new odersHistory();
            frm.Hide();
        }
    }
}
