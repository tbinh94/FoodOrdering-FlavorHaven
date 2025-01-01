using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace foodordering
{
    public partial class SearchResult : Form
    {
        private bool isExpanded = false;
        private ProductSearchForm currentProductSearchForm;
        private Dictionary<string, CheckBox> districtCheckboxes = new Dictionary<string, CheckBox>();

        public SearchResult()
        {
            InitializeComponent();
        }

        public void LoadProductSearchForm(ProductSearchForm productSearchForm)
        {
            currentProductSearchForm = productSearchForm;
            productSearchForm.TopLevel = false;
            productSearchForm.FormBorderStyle = FormBorderStyle.None;
            productSearchForm.Dock = DockStyle.Fill;
            containerPanel.Controls.Add(productSearchForm);
            containerPanel.Controls.SetChildIndex(panelCbox, 0);
            productSearchForm.Show();
        }


        string[] areas = { "Quận 6", "Quận 7", "Quận 8", "Quận 10", "Quận 11",
                               "Quận 12", "Bình Thạnh", "Bình Tân", "Phú Nhuận",
                               "Thành phố Thủ Đức", "Bình Chánh", "Cần Giờ",
                               "Củ Chi", "Tân Bình", "Tân Phú", "Hóc Môn", "Nhà Bè", "Quận Tân Bình", "Quận 1", "Quận 5", "Quận 3",
                            "Quận 2", "Quận 4"};


        private void btnDistrict_Click(object sender, EventArgs e)
        {
            isExpanded = !isExpanded;
            panelCbox.Visible = isExpanded;

            if (isExpanded)
            {
                LoadCheckBoxes(areas);
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
                cb.CheckedChanged += CheckBox_CheckedChanged;

                panelCbox.Controls.Add(cb);
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (currentProductSearchForm != null)
            {
                var selectedDistricts = new HashSet<string>();

                // Lặp qua tất cả checkbox trong panel
                foreach (Control control in panelCbox.Controls)
                {
                    if (control is CheckBox checkbox && checkbox.Checked)
                    {
                        selectedDistricts.Add(checkbox.Text.Trim());
                    }
                }

                // Gọi phương thức mới để lọc theo quận
                currentProductSearchForm.FilterByDistricts(selectedDistricts);
            }
        }

    }
}
