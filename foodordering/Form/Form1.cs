using Food_BL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Panel = System.Windows.Forms.Panel;

namespace foodordering
{

    public partial class Form1 : Form
    {
        public List<CartDTO> list;
        public List<ProductDTO> listProduct;
        public static UserDTO user;
        private static Form1 instance;
        public System.Windows.Forms.Panel pn3;
        public static bool IsSellerLoggedIn = false;
        public static string LoggedInSellerName = "";
        public static int iduser;
        private ProductBL productBL;
        BorderButton selectedButton = null;
        private ProductSearchForm productSearchForm;
        public static Form1 Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new Form1();
                }
                return instance;
            }
        }

        public Form1()
        {
            InitializeComponent();

            // 1. Sự kiện liên quan đến Form
            this.Resize += new EventHandler(Form1_Resize);
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            DoubleBuffering(panel3);

            // 2. Khởi tạo các thành phần dữ liệu
            productBL = new ProductBL();
            iduser = foodordering.Properties.Settings.Default.userID == 0 ? 0 : foodordering.Properties.Settings.Default.userID;
            user = foodordering.Properties.Settings.Default.userID == 0
                ? null
                : new UserBL().getUser(iduser, foodordering.Properties.Settings.Default.isSeller);
            list = new CartBL().GetCart(iduser);
            listProduct = new ProductBL().GetAllProducts();

            // 3. Cấu hình các thành phần giao diện cơ bản
            searchBar.Text = "Tìm địa điểm, món ăn, địa chỉ...";
            searchBar.ForeColor = Color.Gray;
            searchBar.Enter += searchBar_Enter;
            searchBar.Leave += searchBar_Leave;

            flowLayoutPanelProducts.AutoScroll = true;
            flpDetail.WrapContents = true;
            flpDetail.AutoScroll = false;

            // 4. Thiết lập các nút và ảnh
            btnSearch.Image = ResizeImg.ResizeImage(Properties.Resources.searchicon, 20, 20);
            cartButton.Image = ResizeImg.ResizeImage(Properties.Resources.carticon, 40, 40);
            btnLogo.Image = ResizeImg.ResizeImage(Properties.Resources.logo, 100, 100);
            panel3.BackgroundImage = ResizeImg.ResizeImage(Properties.Resources.background, 1440, 768);

            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.BackColor = Color.LightBlue;

            ApplyTransparentStyleToAllButtons(panel3);
            ConfigureImageButton(cartButton);
            ConfigureImageButton(btnLogo);

            flowLayoutPanelProducts.HorizontalScroll.Visible = false;
            flpAds.AutoScroll = false;

            // 5. Tải dữ liệu và giao diện
            //LoadProducts();
            LoadProductItemControl();
            LoadProductsForFlowLayout();
            LoadAds();
            LoadProductsForDetail();
            LoadFeaturedProducts();

            // 6. Cấu hình bổ sung
            SetupSuggestionControls();
            pn3 = panel3;
        }

        private void DoubleBuffering(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null, panel, new object[] { true });
        }
        public void loadCart()
        {
            list = new CartBL().GetCart(iduser);
        }
        public void LoadProductItemControl()
        {
            loadCart();
            foreach (ProductItemControl v in flowLayoutPanelProducts.Controls)
            {
                if (list.Find(x => x.ProductID == v.id) != null)
                {
                    v.setTextCart = "🛍️";
                    continue;
                }
                v.setTextCart = "🛒";
            }
        }
        public async Task<System.Drawing.Image> LoadImageAsync(string imagePath)
        {
            try
            {
                if (File.Exists(imagePath))
                {
                    return await Task.Run(() => System.Drawing.Image.FromFile(imagePath));
                }
                else
                {
                    // Nếu không tìm thấy ảnh, tải ảnh mặc định
                    string defaultImagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                    return await Task.Run(() => System.Drawing.Image.FromFile(defaultImagePath));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải hình ảnh: {ex.Message}");
                return null;
            }
        }
        private void LoadProductsForFlowLayout()
        {
            flowLayoutPanelProducts.Controls.Clear();

            // Lấy danh sách sản phẩm xáo trộn và chọn 8 sản phẩm đầu tiên
            if (listProduct == null)
                listProduct = new ProductBL().GetAllProducts();

            List<ProductDTO> shuffledProducts = ShuffleList(new List<ProductDTO>(listProduct));
            List<ProductDTO> top8Products = shuffledProducts.Take(8).ToList();

            foreach (var productDto in top8Products)
            {
                ProductBL product = ProductBL.FromDTO(productDto);
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.Image);
                System.Drawing.Image image;

                try
                {
                    if (File.Exists(imagePath))
                    {
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                    else
                    {
                        imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải hình ảnh cho {product.Name}: {ex.Message}");
                    continue;
                }

                ProductItemControl productItem = new ProductItemControl
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price.ToString("C0"),
                    ProductDescription = product.Description,
                    ProductImage = ResizeImg.ResizeImage(image, 381, 310),
                    Address = product.Address,
                    DiscountText = product.DiscountText,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10, 7, 10, 20),
                    BackColor = Color.FromArgb(230, 170, 170),
                    id = product.id,
                };

                flowLayoutPanelProducts.Controls.Add(productItem);
                productItem.ProductClicked += ProductItem_ProductClicked;
                productItem.Cursor = Cursors.Hand;
                image.Dispose();
            }
        }
        private void LoadAds()
        {
            flpAds.Controls.Clear(); // Làm sạch các control hiện tại trong panel

            AdItemBL adItemBL = new AdItemBL();
            List<AdItemDTO> ads = adItemBL.GetAllAds(); // Lấy danh sách quảng cáo từ BL
            ads = ShuffleList(ads).Take(4).ToList();
            foreach (var adDto in ads)
            {
                AdItemBL adItem = AdItemBL.FromDTO(adDto);


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
                        imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải hình ảnh cho quảng cáo {adItem.AdName}: {ex.Message}");
                    continue;
                }

                // Tạo AdItemControl với thông tin quảng cáo
                AdItem adItemControl = new AdItem
                {
                    DiscountDescription = adItem.AdDescription,
                    AdImage = ResizeImg.ResizeImage(image, 381, 310),
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10, 7, 10, 20),
                    BackColor = Color.FromArgb(230, 170, 170),
                    Id = adItem.Id
                };

                flpAds.Controls.Add(adItemControl);

                image.Dispose();
            }
        }
        private void LoadProductsForDetail()
        {
            flpDetail.Controls.Clear();
            int totalHeight = 0;

            if (listProduct == null)
                listProduct = new ProductBL().GetAllProducts();

            List<ProductDTO> shuffledProducts = ShuffleList(new List<ProductDTO>(listProduct));

            foreach (var productDto in shuffledProducts)
            {
                ProductBL product = ProductBL.FromDTO(productDto);
                string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.Image);
                System.Drawing.Image image;

                try
                {
                    if (File.Exists(imagePath))
                    {
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                    else
                    {
                        imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                        image = System.Drawing.Image.FromFile(imagePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Không thể tải hình ảnh cho {product.Name}: {ex.Message}");
                    continue;
                }

                ProductItemControl productItemDetail = new ProductItemControl
                {
                    ProductName = product.Name,
                    ProductPrice = product.Price.ToString("C0"),
                    ProductDescription = product.Description,
                    ProductImage = ResizeImg.ResizeImage(image, 381, 310),
                    Address = product.Address,
                    DiscountText = product.DiscountText,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(10, 7, 10, 20),
                    BackColor = Color.FromArgb(230, 170, 170),
                    id = product.id,
                };

                flpDetail.Controls.Add(productItemDetail);
                totalHeight += productItemDetail.Height + productItemDetail.Margin.Top + productItemDetail.Margin.Bottom;

                image.Dispose();
            }
            flpDetail.Height = totalHeight;
            flpDetail.Width = fLP1.Width - 20;
        }

        public static List<T> ShuffleList<T>(List<T> inputList)
        {
            Random random = new Random();
            return inputList.OrderBy(x => random.Next()).ToList();
        }

        private void ProductItem_ProductClicked(object sender, EventArgs e)
        {
            if (sender is ProductItemControl productItem)
            {
                // Lấy dữ liệu sản phẩm từ ProductItemControl
                string productName = productItem.ProductName;
                string productPrice = productItem.ProductPrice;
                string address = productItem.Address;
                System.Drawing.Image productImage = productItem.ProductImage;

                Random random = new Random();
                int randomRating = random.Next(1, 6);

                // Tạo Form2 và truyền dữ liệu
                ItemDetail form2 = new ItemDetail();
                form2.SetProductDetails(productName, productPrice, address, productImage, randomRating);
                AddControlToPanel(form2);
            }
        }


        private void MakeButtonTransparent(System.Windows.Forms.Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.Transparent;
            btn.FlatAppearance.BorderColor = Color.White;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(50, Color.White);
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, Color.White);
            btn.ForeColor = Color.White;
        }
        // Hàm làm trong suốt button trong 1 container (panel, groupbox)
        private void ApplyTransparentStyleToAllButtons(System.Windows.Forms.Control container)
        {
            // Tìm button trong container hiện tại
            foreach (System.Windows.Forms.Control control in container.Controls)
            {
                // Nếu là button thì áp dụng style
                if (control is System.Windows.Forms.Button)
                {
                    MakeButtonTransparent((System.Windows.Forms.Button)control);
                }
                // Nếu control chứa các control khác (như Panel, GroupBox...)
                // thì tìm kiếm tiếp trong đó
                if (control.HasChildren)
                {
                    ApplyTransparentStyleToAllButtons(control);
                }
            }
        }
        public void ConfigureImageButton(System.Windows.Forms.Button btn)
        {
            btn.Size = new Size(80, 80);  // kích thước button
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Text = "";
            btn.ImageAlign = ContentAlignment.MiddleCenter;
            btn.BackColor = Color.Transparent; // hoặc màu khác tùy thiết kế
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent; // mau hover
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tìm kiếm...");
        }

        // Sự kiện khi nhấn vào nút giỏ hàng
        private void cartButton_Click(object sender, EventArgs e)
        {
            //Cart cart = new Cart(list);
            //cart.Show();
            this.Enabled = false;
            using (Cart cart = new Cart(list))
            {
                if (cart.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void searchBar_Enter(object sender, EventArgs e)
        {
            if (searchBar.Text == "Tìm địa điểm, món ăn, địa chỉ...")
            {
                searchBar.Text = "";
                searchBar.ForeColor = Color.Black;
            }
        }

        private void searchBar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchBar.Text))
            {
                searchBar.Text = "Tìm địa điểm, món ăn, địa chỉ...";
                searchBar.ForeColor = Color.Gray;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (login loginForm = new login())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Lưu trạng thái đăng nhập
                    UserSession.Instance.LoggedInUsername = loginForm.Username;

                    // Cập nhật nút đăng nhập
                    UpdateLoginButton(UserSession.Instance.LoggedInUsername);
                    user = new UserBL().getUser(foodordering.Properties.Settings.Default.userID, foodordering.Properties.Settings.Default.isSeller);

                }
            }
        }

        private void UpdateLoginButton(string username)
        {

            btnLogin.Text = $"🙋🏻‍♂️ {username} ⇓";
            btnLogin.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleLeft;
            btnLogin.ImageAlign = (HorizontalAlignment)ContentAlignment.MiddleRight;
            //btnLogin.Image = Properties.Resources.down_arrow;

            // Xóa sự kiện cũ
            btnLogin.Click -= btnLogin_Click;

            // Gắn sự kiện mới
            btnLogin.Click += btnDropdown_Click;
        }

        private void btnDropdown_Click(object sender, EventArgs e)
        {
            // Xóa tất cả mục cũ trước khi thêm
            cmsMenu.Items.Clear();

            ToolStripMenuItem history = new ToolStripMenuItem("Lịch sử đơn hàng");
            ToolStripMenuItem edit = new ToolStripMenuItem("Cập nhật tài khoản");
            ToolStripMenuItem signOut = new ToolStripMenuItem("Đăng xuất");

            history.Click += OrderHistoryItem_Click;
            signOut.Click += SignOutItem_Click;
            edit.Click += EditAccount_Click;

            cmsMenu.Items.Add(history);
            cmsMenu.Items.Add(edit);
            cmsMenu.Items.Add(signOut);

            cmsMenu.Show(btnLogin, new Point(0, btnLogin.Height));

        }

        private void EditAccount_Click(object sender, EventArgs e)
        {
            using (frmEditAccount editForm = new frmEditAccount())
            {
                editForm.StartPosition = FormStartPosition.CenterScreen;
                editForm.ShowDialog();
            }

        }
        private void OrderHistoryItem_Click(object sender, EventArgs e)
        {
            // Hiển thị form Lịch sử đơn hàng
            //HelpForm orderHistory = new HelpForm();
            //orderHistory.ShowDialog();
            this.Enabled = false;
            using (odersHistory f = new odersHistory())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                }
            }
        }

        private void SignOutItem_Click(object sender, EventArgs e)
        {
            // Reset trạng thái người dùng
            UserSession.Instance.LoggedInUsername = null;
            IsSellerLoggedIn = false;

            foodordering.Properties.Settings.Default.userID = 0;
            foodordering.Properties.Settings.Default.isSeller = false;
            foodordering.Properties.Settings.Default.Save();

            btnLogin.Text = "Đăng nhập";
            btnLogin.Image = null; // Xóa mũi tên
            btnLogin.Click -= btnDropdown_Click;
            btnLogin.Click += btnLogin_Click;

            MessageBox.Show("Bạn đã đăng xuất thành công.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Hide();
            Sign_up form = new Sign_up();
            form.Show();
        }

        private void btnSellerChannel_Click(object sender, EventArgs e)
        {
            Hide();
            seller form = new seller();
            form.Show();
            if (IsSellerLoggedIn)
            {
                SellerInterface sellerInterface = new SellerInterface();
                sellerInterface.TopLevel = false;
                sellerInterface.FormBorderStyle = FormBorderStyle.None;
                sellerInterface.Dock = DockStyle.Fill;

                form.rightPanel.Controls.Clear(); // Xóa nội dung cũ
                form.rightPanel.Controls.Add(sellerInterface);
                sellerInterface.Show();
            }
            else
            {
                // Người dùng chưa đăng nhập, để trống rightPanel
                form.rightPanel.Controls.Clear();
                MessageBox.Show("Chỉ người bán mới có thể truy cập giao diện này.\nVui lòng thử lại sau khi đăng nhập là người bán.", "Thông báo");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            HelpForm form = new HelpForm();
            form.Show();
            //Food_Seller_Form form = new Food_Seller_Form(1);
            //form.Show();
        }

        private void AddControlToPanel(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            fLP1.Controls.Clear();
            panel3.Controls.Add(form);
            form.Show();
        }

        private async void btnLogo_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.Control control in panel3.Controls)
            {
                control.Visible = false; // Ẩn control
            }
            // Hiển thị loadingPanel và progressBar1
            loadingPanel.Visible = true;
            progressBar1.Visible = true;
            progressBar1.Value = 0; // Đặt lại giá trị ban đầu

            // Mô phỏng quá trình loading trong 5 giây
            await Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50); // Mỗi vòng lặp mất 50ms (100 vòng = 5 giây)
                    this.Invoke((MethodInvoker)(() =>
                    {
                        progressBar1.Value = i; // Cập nhật giá trị ProgressBar
                    }));
                }
            });
            // Khôi phục giao diện chính
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
            progressBar1.Visible = false;
        }

        private void loadProductByCategorieID(int i)
        {
            //FoodCategoryForm f = new FoodCategoryForm(i);
            //AddControlToPanel(f);
            //f.Show();
            List<ProductDTO> products = new ProductBL().GetProducts_byCategorieID(i);
            listProduct = products;
            LoadProductsForDetail();
        }

        private void guna2Button1_Paint(object sender, PaintEventArgs e) { }

        private void btnAle_Click(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EnsureUserAvatarFolder();
            CopyDefaultAvatar();

            // Kiểm tra xem người dùng đã đăng nhập trước đó hay chưa
            if (foodordering.Properties.Settings.Default.userID != 0)
            {
                UserDTO userl = new UserBL().getUser(foodordering.Properties.Settings.Default.userID, foodordering.Properties.Settings.Default.isSeller);
                if (userl != null)
                {
                    UserSession.Instance.LoggedInUsername = userl.Username;

                    if (foodordering.Properties.Settings.Default.isSeller)
                    {
                        IsSellerLoggedIn = true;
                    }

                    user = userl;
                }
                else
                {
                    ResetUserState();
                }
            }

            // Nếu chưa có người dùng nào đăng nhập, hiển thị form đăng nhập
            if (string.IsNullOrEmpty(UserSession.Instance.LoggedInUsername))
            {
                using (login loginForm = new login())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        UserSession.Instance.LoggedInUsername = loginForm.Username;

                        UpdateLoginButton(UserSession.Instance.LoggedInUsername);
                        user = new UserBL().getUser(foodordering.Properties.Settings.Default.userID, foodordering.Properties.Settings.Default.isSeller);

                    }
                }
            }

            if (!string.IsNullOrEmpty(UserSession.Instance.LoggedInUsername))
            {
                UpdateLoginButton(UserSession.Instance.LoggedInUsername);
            }

            // Tải danh mục sản phẩm
            List<string> categories = new ProductBL().CategoryProduct();
            int indexctg = 0;

            foreach (System.Windows.Forms.Control control in fLPCategory.Controls)
            {
                if (control is BorderButton button)
                {
                    int currentIndex = indexctg;
                    button.Text = categories[currentIndex];
                    indexctg++;
                    button.Click += (_, __) => ToggleButtonColor(button, currentIndex + 1);
                }
            }

            for (int i = indexctg; i < categories.Count; i++)
            {
                int index = i;
                BorderButton button = new BorderButton()
                {
                    Text = categories[i],  // Chỉ định văn bản cho button
                    Width = 80,             // Đặt kích thước cho button
                    Height = 36,            // Đặt chiều cao cho button
                    BackColor = Color.White,  // Chọn màu nền cho button
                    ForeColor = Color.Black,      // Màu chữ cho button
                    Font = new Font("Verdana", 8, FontStyle.Bold)  // Cài đặt phông chữ cho button
                };
                button.Click += (_, __) => ToggleButtonColor(button, index + 1);
                fLPCategory.Controls.Add(button);
                button.Show();


                suggestionsListBox.Visible = false;
            }
        }

        private void ToggleButtonColor(BorderButton button, int categoryIndex)
        {
            if (selectedButton != null)
            {
                selectedButton.BackColor = Color.White;
                selectedButton.ForeColor = Color.Black;
            }

            // Đổi màu của button hiện tại
            button.BackColor = Color.DarkOrange;
            button.ForeColor = Color.White;

            selectedButton = button;
            loadProductByCategorieID(categoryIndex);
        }
        private void ResetUserState()
        {
            IsSellerLoggedIn = false;
            UserSession.Instance.LoggedInUsername = null;

            foodordering.Properties.Settings.Default.userID = 0;
            foodordering.Properties.Settings.Default.isSeller = false;
            foodordering.Properties.Settings.Default.Save();

            UpdateLoginButton(null);
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            //loadProductByCategorieID(1);
        }

        private void btnSearch_Click_2(object sender, EventArgs e)
        {
            string searchQuery = searchBar.Text.Trim();
            var productSearchForm = new ProductSearchForm();
            productSearchForm.FilterProducts(searchQuery);

            var searchResultForm = new SearchResult();
            searchResultForm.LoadProductSearchForm(productSearchForm);

            AddControlToPanel(searchResultForm);
        }


        private void searchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && suggestionsListBox.Visible)
            {
                suggestionsListBox.Focus();
                suggestionsListBox.SelectedIndex = 0;
            }
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click_2(sender, e);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        public void LoadFeaturedProducts()
        {
            flpFeatures.Controls.Clear();

            ProductBL productBL = new ProductBL();
            List<ProductDTO> featuredProducts = productBL.GetRandomProducts(10);

            foreach (var product in featuredProducts)
            {
                System.Windows.Forms.Button productButton = new System.Windows.Forms.Button
                {
                    Text = product.ProductName,
                    Width = 75,
                    Height = 24,
                    BackColor = Color.Transparent,
                    ForeColor = Color.White,
                    Font = new Font("Time News Roman", 8, FontStyle.Bold),
                    Margin = new Padding(5),
                    FlatStyle = FlatStyle.Flat
                };
                productButton.MouseEnter += (sender, e) =>
                {
                    productButton.BackColor = Color.White;
                    productButton.ForeColor = Color.Black;
                };

                productButton.MouseLeave += (sender, e) =>
                {
                    productButton.BackColor = Color.Transparent;
                    productButton.ForeColor = Color.White;
                };
                productButton.Click += (s, e) =>
                {
                    MessageBox.Show($"Sản phẩm: {product.ProductName}\nGiá trung bình: {product.Price:C0}");
                };

                flpFeatures.Controls.Add(productButton);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int panelLeftWidth = (int)(panel3.Width * 0.41);


            leftPanel.Width = panelLeftWidth;
            leftPanel.Height = this.ClientSize.Height;
            leftPanel.Location = new Point(0, 0);

            fLP1.Width = this.ClientSize.Width - panelLeftWidth;
            fLP1.Location = new Point(leftPanel.Right, 0);

            fLP1.Height = pn3.Height;

            AdjustRightPanelLayout();
        }

        private void AdjustRightPanelLayout()
        {
            foreach (System.Windows.Forms.Control ctrl in fLP1.Controls)
            {
                if (ctrl is FlowLayoutPanel flp)
                {
                    flp.Width = fLP1.ClientSize.Width - 10;
                    flp.Margin = new Padding(5);
                    panel2.Width = fLP1.Width;
                }
            }
        }


        private void adsShowAll_Click(object sender, EventArgs e)
        {
            adsShowAll.Visible = false;
            AdsShowAllForm showAllAds = new AdsShowAllForm();
            AddControlToPanel(showAllAds);

        }

        private void searchBar_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchBar.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                hintContainerPanel.Visible = false;
                return;
            }

            try
            {
                List<string> suggestions = productBL.GetProductSuggestions(searchText);

                suggestionsListBox.Items.Clear();
                if (suggestions.Any())
                {
                    foreach (var suggestion in suggestions)
                    {
                        suggestionsListBox.Items.Add(suggestion);
                    }

                    hintContainerPanel.Visible = true;
                    hintContainerPanel.BringToFront();
                    suggestionsListBox.Visible = true;


                }
                else
                {
                    hintContainerPanel.Visible = false;
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine($"PL Error: {ex.Message}");
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
            }

        }

        private void suggestionsListBox_Click_1(object sender, EventArgs e)
        {
            if (suggestionsListBox.SelectedItem != null)
            {
                string selectedProductName = suggestionsListBox.SelectedItem.ToString();
                searchBar.Text = selectedProductName;
                hintContainerPanel.Visible = false;

                try
                {
                    // Lấy thông tin chi tiết sản phẩm
                    ProductDTO product = productBL.GetProductDetails(selectedProductName);
                    if (product != null)
                    {
                        string imagePath = Path.Combine(Application.StartupPath, "Resources", "ProductImage", product.ImagePath);
                        System.Drawing.Image productImage;

                        try
                        {
                            if (File.Exists(imagePath))
                            {
                                productImage = System.Drawing.Image.FromFile(imagePath);
                            }
                            else
                            {
                                // Sử dụng ảnh mặc định nếu không tìm thấy
                                imagePath = Path.Combine(Application.StartupPath, "Resources", "default.png");
                                productImage = System.Drawing.Image.FromFile(imagePath);
                            }

                            // Resize ảnh nếu cần
                            System.Drawing.Image resizedImage = ResizeImg.ResizeImage(productImage, 381, 310);

                            // Tạo và hiển thị ItemDetail
                            Random random = new Random();
                            int randomRating = random.Next(1, 6);

                            ItemDetail form2 = new ItemDetail();
                            form2.SetProductDetails(
                                product.ProductName,
                                product.Price.ToString("C0"),
                                product.Address,
                                resizedImage,
                                randomRating
                            );
                            AddControlToPanel(form2);

                            // Giải phóng tài nguyên
                            productImage.Dispose();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không thể tải hình ảnh cho {product.ProductName}: {ex.Message}");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi hiển thị chi tiết sản phẩm: " + ex.Message);
                }
            }
        }


        private void suggestionsListBox_Leave_1(object sender, EventArgs e)
        {
            Task.Delay(200).ContinueWith(t =>
            {
                if (!suggestionsListBox.Focused)
                {
                    suggestionsListBox.Invoke((MethodInvoker)(() => suggestionsListBox.Visible = false));
                }
            });
            suggestionsListBox.Visible = false;
        }
        private void SetupSuggestionControls()
        {
            hintContainerPanel.BorderStyle = BorderStyle.FixedSingle;
            hintContainerPanel.BackColor = Color.White;
            hintContainerPanel.Visible = false;

            hintContainerPanel.Location = new Point(
                searchBar.Location.X,
                searchBar.Location.Y + searchBar.Height
            );

            suggestionsListBox.BorderStyle = BorderStyle.None;
            suggestionsListBox.BackColor = Color.White;
            suggestionsListBox.Dock = DockStyle.Fill;
            suggestionsListBox.Margin = new Padding(10);
            suggestionsListBox.Font = new Font("Verdana", 11, FontStyle.Regular);

            hintContainerPanel.Size = new Size(
                searchBar.Width,
                150
            );
        }

        private void EnsureUserAvatarFolder()
        {
            string resourcePath = Path.Combine(Application.StartupPath, "Resources");
            string avatarFolderPath = Path.Combine(resourcePath, "UserAvatar");

            // Tạo thư mục Resources nếu chưa có
            if (!Directory.Exists(resourcePath))
            {
                Directory.CreateDirectory(resourcePath);
            }

            // Tạo thư mục UserAvatar nếu chưa có
            if (!Directory.Exists(avatarFolderPath))
            {
                Directory.CreateDirectory(avatarFolderPath);
            }
        }
        private void CopyDefaultAvatar()
        {
            string avatarFolderPath = Path.Combine(Application.StartupPath, "Resources", "UserAvatar");
            string defaultAvatarPath = Path.Combine(avatarFolderPath, "default_avatar.png");

            if (!File.Exists(defaultAvatarPath))
            {
                // Lấy ảnh mặc định từ Resources và lưu vào UserAvatar
                Properties.Resources.default_avatar.Save(defaultAvatarPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }


    }
}
