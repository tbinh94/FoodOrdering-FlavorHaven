using Food_BL;
using Food_DTO;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace foodordering
{
    public partial class login : Form
    {
        public static login instance;
        public static System.Windows.Forms.Panel pn1;
        public static Sign_up su;
        public static int szh;
        public static int szw;
        public string Username { get; private set; }
        public login()
        {
            InitializeComponent();
            instance = this;

            btnShowPass.Image = ResizeImg.ResizeImage(Properties.Resources.show, 20, 20);


            pic1.Image = ResizeAnimatedGif(Properties.Resources.backlogin, 398, 712);

            pic1.SizeMode = PictureBoxSizeMode.StretchImage;
            pic1.Dock = DockStyle.Fill;
        }

        private static Image ResizeAnimatedGif(Image imgToResize, int width, int height)
        {
            try
            {
                // Tạo một ảnh GIF mới với kích thước mong muốn
                var resizedGif = new Bitmap(width, height);
                resizedGif.SetResolution(imgToResize.HorizontalResolution, imgToResize.VerticalResolution);

                using (Graphics g = Graphics.FromImage(resizedGif))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                }

                // Duyệt qua tất cả các frame của ảnh gốc
                FrameDimension frameDimension = new FrameDimension(imgToResize.FrameDimensionsList[0]);
                int frameCount = imgToResize.GetFrameCount(frameDimension);

                // Tạo một animator mới cho ảnh GIF
                ImageAnimator.Animate(imgToResize, null);

                // Tạo một bộ nhớ để lưu tất cả các frame
                var gifEncoder = System.Drawing.Imaging.ImageCodecInfo.GetImageEncoders()
                    .FirstOrDefault(codec => codec.MimeType == "image/gif");

                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.MultiFrame);

                // Frame đầu tiên
                imgToResize.SelectActiveFrame(frameDimension, 0);
                using (var stream = new MemoryStream())
                {
                    resizedGif.Save(stream, gifEncoder, encoderParams);
                    for (int i = 1; i < frameCount; i++)
                    {
                        imgToResize.SelectActiveFrame(frameDimension, i);
                        resizedGif.SaveAdd(new Bitmap(resizedGif), encoderParams);
                    }

                    // Kết thúc và trả về GIF đã resize
                    encoderParams.Param[0] = new EncoderParameter(Encoder.SaveFlag, (long)EncoderValue.Flush);
                    resizedGif.SaveAdd(encoderParams);
                }

                return resizedGif;
            }
            catch
            {
                return imgToResize; // Trả về ảnh gốc nếu có lỗi
            }
        }


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool isSeller = checkSeller.Checked;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo");
                return;
            }

            UserDTO acc = new UserDTO(username, password);
            UserBL loginBL = new UserBL();

            try
            {
                if (loginBL.Login(acc, isSeller))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                    // Chuyển đến màn hình chính
                    this.Username = username; // Lưu tên người dùng
                                              // Cập nhật trạng thái đăng nhập
                    int i = new UserBL().getUserID(username, isSeller);
                    Form1.iduser = i;
                    foodordering.Properties.Settings.Default.userID = i;
                    foodordering.Properties.Settings.Default.isSeller = isSeller;
                    foodordering.Properties.Settings.Default.Save();
                    if (isSeller)
                    {
                        Form1.IsSellerLoggedIn = true;
                        Form1.LoggedInSellerName = username;
                    }
                    this.DialogResult = DialogResult.OK; // Đóng form với trạng thái OK
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại.\nKiểm tra lại tên đăng nhập hoặc mật khẩu.", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Hide();
            Sign_up f = new Sign_up();
            f.Show();
        }

        private void container_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '●')
            {
                txtPassword.PasswordChar = '\0';
                btnShowPass.Image = ResizeImg.ResizeImage(Properties.Resources.hide, 20, 20);
            }
            else
            {
                txtPassword.PasswordChar = '●';
                btnShowPass.Image = ResizeImg.ResizeImage(Properties.Resources.show, 20, 20);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            btnShowPass.UseTransparentBackground = true;
        }
    }
}
