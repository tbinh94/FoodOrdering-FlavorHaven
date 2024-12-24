using Food_BL;
using System;
using System.Windows.Forms;

namespace foodordering
{
    public partial class frmEditAccount : Form
    {
        public frmEditAccount()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.", "Thông báo");
                return;
            }

            int userId = foodordering.Properties.Settings.Default.userID;
            bool isSeller = foodordering.Properties.Settings.Default.isSeller;

            UserBL userBL = new UserBL();

            try
            {
                bool isUpdated = userBL.UpdatePassword(userId, newPassword, isSeller);
                if (isUpdated)
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật mật khẩu thất bại.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }


        private void frmEditAccount_Load(object sender, EventArgs e)
        {
            txtUsername.Text = UserSession.Instance.LoggedInUsername;
            txtUsername.ReadOnly = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_up f = new Sign_up();
            f.Show();
        }
    }
}
