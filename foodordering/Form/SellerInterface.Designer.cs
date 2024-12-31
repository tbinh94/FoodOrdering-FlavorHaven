namespace foodordering
{
    partial class SellerInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnMyProducts = new System.Windows.Forms.Button();
            this.btnToggle = new System.Windows.Forms.Button();
            this.containerPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(58, 16);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Xin chào";
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.Controls.Add(this.btnAddProduct);
            this.panelMenu.Controls.Add(this.btnMyProducts);
            this.panelMenu.Controls.Add(this.btnToggle);
            this.panelMenu.Location = new System.Drawing.Point(12, 48);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(138, 218);
            this.panelMenu.TabIndex = 5;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProduct.Location = new System.Drawing.Point(3, 105);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(125, 45);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Thêm sản phẩm";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Visible = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnMyProducts
            // 
            this.btnMyProducts.FlatAppearance.BorderSize = 0;
            this.btnMyProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyProducts.Location = new System.Drawing.Point(3, 54);
            this.btnMyProducts.Name = "btnMyProducts";
            this.btnMyProducts.Size = new System.Drawing.Size(125, 45);
            this.btnMyProducts.TabIndex = 5;
            this.btnMyProducts.Text = "Sản phẩm của tôi";
            this.btnMyProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyProducts.UseVisualStyleBackColor = true;
            this.btnMyProducts.Visible = false;
            this.btnMyProducts.Click += new System.EventHandler(this.btnMyProducts_Click);
            // 
            // btnToggle
            // 
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggle.Location = new System.Drawing.Point(3, 3);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(125, 45);
            this.btnToggle.TabIndex = 4;
            this.btnToggle.Text = "Sản phẩm";
            this.btnToggle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            // 
            // containerPanel
            // 
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.containerPanel.Location = new System.Drawing.Point(-97, 0);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(782, 389);
            this.containerPanel.TabIndex = 6;
            // 
            // SellerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(685, 389);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.lblWelcome);
            this.Name = "SellerInterface";
            this.Text = "SllerInterface";
            this.Load += new System.EventHandler(this.SellerInterface_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnMyProducts;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Panel containerPanel;
    }
}