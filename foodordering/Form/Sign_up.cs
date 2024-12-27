using Food_BL;
using Food_DTO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace foodordering
{
    public partial class Sign_up : Form
    {
        public Sign_up()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Hide();
            login f = new login();
            f.Show();

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phoneNumber = txtPhone.Text.Trim();
            string address = txtAddress.Text.Trim();
            string confirmPassword = txtRePass.Text;
            bool isSeller = checkSeller.Checked;

            string projectPath = Application.StartupPath; // Thư mục gốc của project
            string avatarFolderPath = Path.Combine(projectPath, "UserAvatar");
            string defaultAvatarPath = Path.Combine(projectPath, "Resources", "default_avatar.png");
            string avatarPath;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đảm bảo thư mục lưu trữ avatar tồn tại
            if (!Directory.Exists(avatarFolderPath))
            {
                Directory.CreateDirectory(avatarFolderPath);
            }

            // Kiểm tra nếu người dùng đã upload ảnh
            if (picAvatar.Image != null)
            {
                // Lưu avatar người dùng vào thư mục UserAvatar
                string userAvatarFileName = $"{username}_avatar.jpg";
                avatarPath = Path.Combine(avatarFolderPath, userAvatarFileName);
                picAvatar.Image.Save(avatarPath);
            }
            else
            {
                // Nếu không upload ảnh, sử dụng ảnh mặc định
                avatarPath = Path.Combine(avatarFolderPath, "default_avatar.png");
                if (!File.Exists(avatarPath))
                {
                    File.Copy(defaultAvatarPath, avatarPath); // Sao chép ảnh mặc định
                }
            }

            UserDTO acc = new UserDTO(username, password, email, phoneNumber, address, avatarPath);
            UserBL loginBL = new UserBL();

            if (loginBL.IsUsernameExists(username))
            {
                MessageBox.Show("Tên người dùng đã tồn tại. Vui lòng chọn tên khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isSuccess = loginBL.Signup(acc, isSeller);
            try
            {
                if (isSuccess)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Quay lại màn hình đăng nhập
                }

            }
            catch
            {
                MessageBox.Show("Đăng ký thất bại. Vui lòng thử lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picAvatar.Image = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
