using Food_BL;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace foodordering
{
    public partial class frmEditAccount : Form
    {
        UserBL userBL = new UserBL();
        public frmEditAccount()
        {
            InitializeComponent();
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.BackColor = Color.White;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            string projectPath = Application.StartupPath;
            string avatarFolderPath = Path.Combine(projectPath, "UserAvatar");
            string defaultAvatarPath = Path.Combine(projectPath, "Resources", "default_avatar.png");
            string avatarPath;

            // Kiểm tra và tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(avatarFolderPath))
            {
                Directory.CreateDirectory(avatarFolderPath);
            }

            if (picAvatar.Image != null)
            {
                try
                {
                    string userAvatarFileName = $"{UserSession.Instance.LoggedInUsername}_avatar_temp.jpg";
                    avatarPath = Path.Combine(avatarFolderPath, userAvatarFileName);

                    // Xử lý việc lưu ảnh JPG
                    using (Bitmap bmp = new Bitmap(picAvatar.Image))
                    {
                        bmp.Save(avatarPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu avatar: " + ex.Message, "Thông báo");
                    return;
                }
            }
            else
            {
                // Sử dụng avatar hiện tại hoặc ảnh mặc định
                avatarPath = UserSession.Instance.AvatarPath ?? defaultAvatarPath;
            }

            // Kiểm tra mật khẩu
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
                bool isUpdated = userBL.UpdatePassword(userId, newPassword, avatarPath, isSeller);
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

            string projectPath = Application.StartupPath;
            string defaultAvatarPath = Path.Combine(projectPath, "Resources", "default_avatar.png");
            string avatarFolderPath = Path.Combine(projectPath, "UserAvatar");

            if (!Directory.Exists(avatarFolderPath))
            {
                Directory.CreateDirectory(avatarFolderPath);
            }

            bool isSeller = foodordering.Properties.Settings.Default.isSeller;

            string avatarPath = userBL.GetAvatarPath(UserSession.Instance.LoggedInUsername, isSeller);

            if (!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
            {
                try
                {
                    picAvatar.Image = Image.FromFile(avatarPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh đại diện: " + ex.Message, "Thông báo");
                    picAvatar.Image = Image.FromFile(defaultAvatarPath);
                }
            }
            else
            {
                picAvatar.Image = Image.FromFile(defaultAvatarPath);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sign_up f = new Sign_up();
            f.Show();
        }

        private void btnSelectAvatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";
            openFileDialog.Title = "Chọn ảnh đại diện";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (picAvatar.Image != null)
                {
                    picAvatar.Image.Dispose();
                }

                // Đọc ảnh từ tệp mà không khóa tệp
                using (var stream = new MemoryStream(File.ReadAllBytes(openFileDialog.FileName)))
                {
                    picAvatar.Image = Image.FromStream(stream);
                }
            }
        }


    }
}
