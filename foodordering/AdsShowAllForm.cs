using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace foodordering
{
    public partial class AdsShowAllForm : Form
    {
        public List<AdItemDTO> adsa;

        public AdsShowAllForm()
        {
            InitializeComponent();
            adsa = new AdItemBL().GetAllAds(); // Lấy tất cả sản phẩm
            tLP.ColumnCount = 4;
            tLP.Dock = DockStyle.Fill;
            tLP.AutoSize = true;
            tLP.AutoScroll = true;
            tLP.RowCount = adsa.Count / tLP.ColumnCount;
            tLP.AutoScrollMinSize = new Size(1, 1);
            this.Width = SellerInterface.Instance.containerpn.Width;
            this.Resize += (sender, e) =>
            {
                AddElementsToTableLayout();
            };
            tLP.BackColor = Color.Transparent;
            tLP.BackgroundImage = ResizeImg.ResizeImage(Properties.Resources.background1, 1440, 768);

        }

        private void AddElementsToTableLayout()
        {
            tLP.Controls.Clear();
            int columnCount = 4;
            int rowCount = (int)Math.Ceiling((double)adsa.Count / columnCount);
            columnCount = (columnCount == 0) ? 1 : columnCount;
            rowCount = (rowCount == 0) ? 1 : rowCount;
            if (columnCount == 1) rowCount = adsa.Count;

            tLP.ColumnCount = columnCount;
            tLP.RowCount = rowCount;
            tLP.ColumnStyles.Clear();
            tLP.RowStyles.Clear();

            for (int i = 0; i < columnCount; i++)
            {
                tLP.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnCount));
            }
            int x = 0;
            for (int row = 0; row < rowCount; row++)
            {
                int sizerow = 0;
                for (int col = 0; col < columnCount; col++)
                {
                    if (x == adsa.Count) break;

                    AdItemBL adItem = AdItemBL.FromDTO(adsa[x]); // Chuyển từ DTO sang đối tượng BL

                    // Tạo đường dẫn đến hình ảnh quảng cáo trong Resources
                    string imagePath = Path.Combine(Application.StartupPath, "Resources", "PromoIMG", adItem.Image);
                    System.Drawing.Image image;

                    try
                    {
                        if (File.Exists(imagePath))
                        {
                            image = System.Drawing.Image.FromFile(imagePath);
                        }
                        else
                        {
                            // Nếu không tìm thấy file, dùng hình mặc định
                            imagePath = Path.Combine(Application.StartupPath, "Resources", "1.jpg");
                            image = System.Drawing.Image.FromFile(imagePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Không thể tải hình ảnh cho quảng cáo {adItem.AdName}: {ex.Message}");
                        continue; // Bỏ qua quảng cáo này nếu không load được hình
                    }

                    // Tạo AdItemControl với thông tin quảng cáo
                    AdItem adItemControl = new AdItem
                    {
                        DiscountDescription = adItem.AdDescription,
                        AdImage = ResizeImg.ResizeImage(image, 381, 310), // Resize hình ảnh nếu cần
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(10, 7, 10, 20),
                        BackColor = Color.FromArgb(230, 170, 170),
                        Id = adItem.Id
                    };

                    // Thêm vào panel chứa quảng cáo

                    adItemControl.Cursor = Cursors.Hand;
                    sizerow = adItemControl.Width;
                    adItemControl.Dock = DockStyle.None;
                    adItemControl.Anchor = AnchorStyles.None;

                    image.Dispose(); // Giải phóng bộ nhớ hình ảnh sau khi sử dụng

                    tLP.Controls.Add(adItemControl, col, row);
                    image.Dispose();
                    x++;
                }

                tLP.RowStyles.Add(new RowStyle(SizeType.Absolute, sizerow));
            }

            tLP.RowCount += 1;
        }
        private void AddControlToPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.Controls.Clear();
            this.Controls.Add(form);
            form.Show();
        }

    }

}
