using System;
using System.Windows.Forms;

namespace foodordering
{
    public partial class SearchResult : Form
    {
        private bool isExpanded = false;


        public SearchResult()
        {
            InitializeComponent();

        }
        public void LoadProductSearchForm(ProductSearchForm productSearchForm)
        {
            productSearchForm.TopLevel = false;
            productSearchForm.FormBorderStyle = FormBorderStyle.None;
            productSearchForm.Dock = DockStyle.Fill;

            // Thêm ProductSearchForm vào containerPanel
            containerPanel.Controls.Add(productSearchForm);

            // Đảm bảo panelCbox luôn nằm trên cùng
            containerPanel.Controls.SetChildIndex(panelCbox, 0);

            productSearchForm.Show();
        }


        string[] areas = { "Quận 6", "Quận 7", "Quận 8", "Quận 9", "Quận 10", "Quận 11",
                               "Quận 12", "Bình Thạnh", "Bình Tân", "Phú Nhuận",
                               "Thành phố Thủ Đức", "Bình Chánh", "Cần Giờ",
                               "Củ Chi", "Tân Bình", "Tân Phú", "Hóc Môn", "Nhà Bè" };
        string[] cate = { "Đồ ăn nhanh", "Đồ uống", "Món ăn chính", "Tráng miệng", "Đồ chay", "Khai vị", "Đồ hải sản",
                "Salad", "Súp", "Bánh ngọt" };

        private void btnDistrict_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            panelCbox.Visible = isExpanded;

            if (isExpanded)
            {
                LoadCheckBoxes(areas);
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            panelCbox.Visible = isExpanded;

            if (isExpanded)
            {
                LoadCheckBoxes(cate);
            }
        }
        private void LoadCheckBoxes(string[] items)
        {
            panelCbox.WrapContents = true; // Tự động xuống dòng
            panelCbox.AutoScroll = true;   // Thêm thanh cuộn nếu cần
            panelCbox.FlowDirection = FlowDirection.LeftToRight;

            int maxPerRow = 3; // Số CheckBox mỗi dòng
            int panelWidth = panelCbox.Width;
            int checkboxWidth = panelWidth / maxPerRow - 10; // Trừ khoảng cách để căn đều
            // Xóa các CheckBox cũ trong Panel
            panelCbox.Controls.Clear();

            // Thêm các CheckBox mới vào Panel
            foreach (string item in items)
            {
                CheckBox cb = new CheckBox();
                cb.Text = item;
                cb.AutoSize = true;
                cb.Margin = new Padding(10); // Tạo khoảng cách giữa các checkbox
                panelCbox.Controls.Add(cb);
            }
        }


    }
}
