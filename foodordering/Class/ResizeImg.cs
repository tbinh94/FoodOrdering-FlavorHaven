using System.Drawing;
using System.Drawing.Drawing2D;

namespace foodordering
{
    public class ResizeImg
    {
        public static Image ResizeImage(Image imgToResize, int width, int height)
        {
            try
            {
                Bitmap b = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgToResize, 0, 0, width, height);
                }
                return b;
            }
            catch
            {
                return imgToResize; // Trả về ảnh gốc nếu có lỗi
            }
        }
    }
}
