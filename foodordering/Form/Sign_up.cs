using Food_BL;
using Food_DTO;
using System;
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

            UserDTO acc = new UserDTO(username, password, email, phoneNumber, address);
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
    }
}
