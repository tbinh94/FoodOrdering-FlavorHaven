using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public partial class HelpForm : Form
    {
        private List<TextBox> textBoxes = new List<TextBox>();
        private int currentIndex = 0;
        public HelpForm()
        {
            InitializeComponent();

            btnLogo.Image = ResizeImg.ResizeImage(Properties.Resources.logo, 140, 140);
            ConfigureImageButton(btnLogo);

            for (int i = 0; i < 5; i++)
            {
                TextBox txt = new TextBox();
                txt.Location = new Point(10, 10);
                txt.Font = new System.Drawing.Font("Time News Roman", 11);
                txt.Size = new Size(panelContainer.Width - 20, panelContainer.Height - 20); ;
                string[] contents = new string[] {
                    "Hiện tại, Flavor Haven đã tạm ngừng hỗ trợ phương thức thanh toán đơn hàng bằng Số dư TK Flavor Haven. Bạn vui lòng rút tiền trong Số dư TK Flavor Haven về tài khoản ngân hàng đã liên kết để sử dụng nhé!",
                    "[Mua sắm an toàn] Không chia sẻ thông tin cá nhân: mật khẩu đăng nhập, mã OTP và mã PIN ví Flavor HavenPay.... với bất kỳ ai, kể cả nhân viên Flavor Haven. Nếu tài khoản có dấu hiệu đăng nhập bất thường, hãy liên hệ Bộ Phận Chăm Sóc Khách Hàng Flavor Haven. Tham khảo thêm Mua Sắm An Toàn",
                    "Từ ngày 19/05/2023, Người mua có thể ĐỒNG KIẾM () khi nhận hàng từ Flavor Haven. () ĐỒNG KIỂM là kiểm tra tình trạng bên ngoài, số lượng của sản phẩm trong đơn hàng và KHÔNG được mở tem chống hàng giả, niêm phong riêng của sản phẩm, KHÔNG sử dụng dùng thử sản phẩm.",
                    "[Cảnh báo] Hãy thận trọng khi nhận được lời mời làm việc từ các đối tượng lừa đảo thông qua tin nhắn, gọi điện, nhóm chạt hoặc các trang Mạng xã hội. Nếu bạn nhận được tin nhắn đáng ngờ, hãy thông báo ngay với Bộ phận CSKH qua tính năng Gọi tổng đài Flavor Haven (miễn phí) trên ứng dụng Flavor Haven",
                    "Trang này KHÔNG THỂ tìm kiếm thông tin chi tiết đơn hàng, sản phẩm khuyến mãi hoặc số điện thoại. Để tra những nội dung trên, bạn có thể vào trang chủ Flavor Haven.vn hoặc tải ứng dụng di động"
                };
                txt.Multiline = true;
                txt.Text = contents[i];
                txt.Visible = i == 0;
                panelContainer.Controls.Add(txt);
                textBoxes.Add(txt);
            }
            InitializeTimer();

        }
        private void InitializeTimer()
        {
            timer1 = new Timer();
            timer1.Interval = 5000;
            timer1.Tick += Timer_Tick;
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            textBoxes[currentIndex].Visible = false;

            currentIndex = (currentIndex + 1) % textBoxes.Count;

            textBoxes[currentIndex].Visible = true;
        }
        private void OpenCategoryDetail(string filePath, string categoryTitle)
        {
            CategoryDetail detailForm = new CategoryDetail(filePath);
            detailForm.ShowDialog();
        }
        private void ConfigureImageButton(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(100, 100);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Form1.Instance.Show();
        }

        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Policies frm = new Policies();
            frm.Show();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            textBoxes[currentIndex].Visible = false;
            currentIndex = (currentIndex - 1 + textBoxes.Count) % textBoxes.Count;
            textBoxes[currentIndex].Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            textBoxes[currentIndex].Visible = false;
            currentIndex = (currentIndex + 1) % textBoxes.Count;
            textBoxes[currentIndex].Visible = true;
        }
        private string GetRTFFilePath(string fileName)
        {
            string rtfFolderPath = System.IO.Path.Combine(Application.StartupPath, "RTF Files");
            string fullPath = System.IO.Path.Combine(rtfFolderPath, fileName);

            if (!System.IO.File.Exists(fullPath))
            {
                MessageBox.Show($"Không tìm thấy file: {fullPath}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return fullPath;
        }


        private void btnMuaSam_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("MuaSam.rtf");
            OpenCategoryDetail(filePath, "Mua Sắm");
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("KhuyenMai.rtf");
            OpenCategoryDetail(filePath, "Khuyến Mãi - Ưu đãi");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("ThanhToan.rtf");
            OpenCategoryDetail(filePath, "Thanh Toán");
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("DonHang.rtf");
            OpenCategoryDetail(filePath, "Đơn hàng và vận chuyển");
        }

        private void btnTraHang_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("TraHang.rtf");
            OpenCategoryDetail(filePath, "Trả hàng và hoàn tiền");
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("ThongTin.rtf");
            OpenCategoryDetail(filePath, "Thông tin chung");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("BaoMat.rtf");
            OpenCategoryDetail(filePath, "Bảo mật tài khoản");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string filePath = GetRTFFilePath("ThanhVien.rtf");
            OpenCategoryDetail(filePath, "Thành viên mới");
        }
        private void CenterPanel()
        {
            containerPanel.Location = new Point(
                (this.ClientSize.Width - containerPanel.Width) / 2,
                (this.ClientSize.Height - containerPanel.Height) / 2
            );
        }
        private void HelpForm_Load(object sender, EventArgs e)
        {
            CenterPanel();
        }

        private void HelpForm_Resize(object sender, EventArgs e)
        {
            CenterPanel();
        }
    }
}
