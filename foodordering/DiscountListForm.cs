using Food_BL;
using Food_DTO;
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
    public partial class DiscountListForm : Form
    {
        private DiscountBL discountBL;
        private PaymentForm paymentForm;


        public DiscountListForm(PaymentForm form)
        {
            InitializeComponent();
            paymentForm = form;
            this.StartPosition = FormStartPosition.CenterScreen;
            tlpDiscounts.AutoScroll = true;
            tlpDiscounts.AutoSize = true;
        }
        public void LoadDiscounts(List<DiscountDTO> discounts)
        {
            tlpDiscounts.Controls.Clear(); 
            tlpDiscounts.RowCount = discounts.Count; 
            tlpDiscounts.RowStyles.Clear();

            foreach (var discount in discounts)
            {
                Panel discountPanel = new Panel
                {
                    Size = new Size(tlpDiscounts.Width-10, 50),
                    BackColor = Color.LightGray,
                    Margin = new Padding(5),
                    Tag = discount // Gắn DiscountDTO vào Tag
                };

                Label lblDescription = new Label
                {
                    Text = discount.Description,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Label lblRate = new Label
                {
                    Text = $"{discount.DiscountRate}%",
                    Dock = DockStyle.Right,
                    TextAlign = ContentAlignment.MiddleRight
                };

                discountPanel.Controls.Add(lblDescription);
                discountPanel.Controls.Add(lblRate);

                // Gắn sự kiện Click
                discountPanel.Click += DiscountPanel_Click;

                // Đảm bảo các control con không cản sự kiện Click
                foreach (Control control in discountPanel.Controls)
                {
                    control.Click += (s, e) => DiscountPanel_Click(discountPanel, e);
                }

                tlpDiscounts.Controls.Add(discountPanel); // Thêm vào tlpDiscounts
            }
        }

        private void DiscountPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                DiscountDTO discount = clickedPanel.Tag as DiscountDTO;
                if (discount != null)
                {
                    paymentForm.SetDiscountRate(discount.DiscountRate);

                    paymentForm.Show();

                    this.Hide();
                }
            }
        }



    }
}
