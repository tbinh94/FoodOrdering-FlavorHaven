using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public class BorderButton : Button
    {
        public Color BorderColor { get; set; } = Color.OrangeRed;
        public int BorderWidth { get; set; } = 2;
        public Color HoverTextColor { get; set; } = Color.OrangeRed; // Màu chữ khi hover
        public Color DefaultTextColor { get; set; } = Color.Black; // Màu chữ mặc định

        private bool isHovering = false;

        public BorderButton()
        {
            FlatStyle = FlatStyle.Flat; // Loại bỏ border mặc định
            FlatAppearance.BorderSize = 0; // Tắt border hệ thống
            BackColor = Color.Transparent; // Nền trong suốt
            ForeColor = DefaultTextColor; // Màu chữ mặc định

            // Đăng ký sự kiện hover
            MouseEnter += (s, e) =>
            {
                isHovering = true;
                ForeColor = HoverTextColor; // Thay đổi màu chữ khi hover
                Invalidate(); // Vẽ lại button
            };

            MouseLeave += (s, e) =>
            {
                isHovering = false;
                ForeColor = DefaultTextColor; // Trở về màu chữ mặc định
                Invalidate(); // Vẽ lại button
            };
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            // Vẽ border phía dưới
            using (Pen pen = new Pen(BorderColor, BorderWidth))
            {
                pevent.Graphics.DrawLine(
                    pen,
                    0, Height - BorderWidth,  // Bắt đầu ở góc dưới bên trái
                    Width, Height - BorderWidth // Kết thúc ở góc dưới bên phải
                );
            }
        }
    }
}
