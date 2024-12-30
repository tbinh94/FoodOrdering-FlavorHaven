namespace foodordering
{
    partial class Item_Cart
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
            this.ProductName = new System.Windows.Forms.Label();
            this.ProductPrice = new System.Windows.Forms.Label();
            this.lblSLText = new System.Windows.Forms.Label();
            this.ProductSoLuong = new Guna.UI2.WinForms.Guna2TextBox();
            this.congSL = new Guna.UI2.WinForms.Guna2Button();
            this.truSL = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.removeItem = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.inventory = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productPic = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.choosed = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.Location = new System.Drawing.Point(359, 19);
            this.ProductName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(142, 25);
            this.ProductName.TabIndex = 0;
            this.ProductName.Text = "ProductName";
            // 
            // ProductPrice
            // 
            this.ProductPrice.AutoSize = true;
            this.ProductPrice.Location = new System.Drawing.Point(359, 71);
            this.ProductPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.Size = new System.Drawing.Size(135, 25);
            this.ProductPrice.TabIndex = 1;
            this.ProductPrice.Text = "ProductPrice";
            // 
            // lblSLText
            // 
            this.lblSLText.AutoSize = true;
            this.lblSLText.Location = new System.Drawing.Point(4, 29);
            this.lblSLText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSLText.Name = "lblSLText";
            this.lblSLText.Size = new System.Drawing.Size(104, 25);
            this.lblSLText.TabIndex = 2;
            this.lblSLText.Text = "Số Lượng";
            this.lblSLText.Click += new System.EventHandler(this.lblSLText_Click);
            // 
            // ProductSoLuong
            // 
            this.ProductSoLuong.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ProductSoLuong.DefaultText = "1";
            this.ProductSoLuong.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ProductSoLuong.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ProductSoLuong.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductSoLuong.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ProductSoLuong.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductSoLuong.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ProductSoLuong.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ProductSoLuong.Location = new System.Drawing.Point(116, 19);
            this.ProductSoLuong.Margin = new System.Windows.Forms.Padding(12);
            this.ProductSoLuong.Name = "ProductSoLuong";
            this.ProductSoLuong.PasswordChar = '\0';
            this.ProductSoLuong.PlaceholderText = "";
            this.ProductSoLuong.SelectedText = "";
            this.ProductSoLuong.Size = new System.Drawing.Size(104, 46);
            this.ProductSoLuong.TabIndex = 3;
            this.ProductSoLuong.TextChanged += new System.EventHandler(this.ProductSoLuong_TextChanged);
            this.ProductSoLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProductSoLuong_KeyPress);
            // 
            // congSL
            // 
            this.congSL.AutoRoundedCorners = true;
            this.congSL.BorderRadius = 22;
            this.congSL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.congSL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.congSL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.congSL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.congSL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.congSL.ForeColor = System.Drawing.Color.White;
            this.congSL.Location = new System.Drawing.Point(104, 19);
            this.congSL.Margin = new System.Windows.Forms.Padding(4);
            this.congSL.Name = "congSL";
            this.congSL.Size = new System.Drawing.Size(52, 46);
            this.congSL.TabIndex = 4;
            this.congSL.Text = "+";
            this.congSL.Click += new System.EventHandler(this.congSL_Click);
            // 
            // truSL
            // 
            this.truSL.AutoRoundedCorners = true;
            this.truSL.BorderRadius = 22;
            this.truSL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.truSL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.truSL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.truSL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.truSL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.truSL.ForeColor = System.Drawing.Color.White;
            this.truSL.Location = new System.Drawing.Point(4, 19);
            this.truSL.Margin = new System.Windows.Forms.Padding(4);
            this.truSL.Name = "truSL";
            this.truSL.Size = new System.Drawing.Size(52, 46);
            this.truSL.TabIndex = 5;
            this.truSL.Text = "-";
            this.truSL.Click += new System.EventHandler(this.truSL_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.removeItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(948, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 169);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.congSL);
            this.panel3.Controls.Add(this.truSL);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 88);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(160, 81);
            this.panel3.TabIndex = 7;
            // 
            // removeItem
            // 
            this.removeItem.AutoRoundedCorners = true;
            this.removeItem.BorderRadius = 22;
            this.removeItem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.removeItem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.removeItem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.removeItem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.removeItem.FillColor = System.Drawing.Color.Red;
            this.removeItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.removeItem.ForeColor = System.Drawing.Color.White;
            this.removeItem.Location = new System.Drawing.Point(104, 8);
            this.removeItem.Margin = new System.Windows.Forms.Padding(4);
            this.removeItem.Name = "removeItem";
            this.removeItem.Size = new System.Drawing.Size(52, 46);
            this.removeItem.TabIndex = 6;
            this.removeItem.Text = "X";
            this.removeItem.Click += new System.EventHandler(this.removeItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.inventory);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ProductSoLuong);
            this.panel2.Controls.Add(this.lblSLText);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(672, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 169);
            this.panel2.TabIndex = 7;
            // 
            // inventory
            // 
            this.inventory.AutoSize = true;
            this.inventory.Location = new System.Drawing.Point(130, 81);
            this.inventory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(100, 25);
            this.inventory.TabIndex = 5;
            this.inventory.Text = "inventory";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tồn kho";
            // 
            // productPic
            // 
            this.productPic.Dock = System.Windows.Forms.DockStyle.Right;
            this.productPic.Location = new System.Drawing.Point(44, 0);
            this.productPic.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.productPic.Name = "productPic";
            this.productPic.Size = new System.Drawing.Size(270, 169);
            this.productPic.TabIndex = 1;
            this.productPic.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.productPic);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(314, 169);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.choosed);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(44, 169);
            this.panel5.TabIndex = 9;
            // 
            // choosed
            // 
            this.choosed.AutoSize = true;
            this.choosed.Location = new System.Drawing.Point(9, 81);
            this.choosed.Name = "choosed";
            this.choosed.Size = new System.Drawing.Size(28, 27);
            this.choosed.TabIndex = 9;
            this.choosed.UseVisualStyleBackColor = true;
            // 
            // Item_Cart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 169);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.ProductPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "Item_Cart";
            this.Text = "Item_Cart";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox productPic;
        private Guna.UI2.WinForms.Guna2TextBox ProductSoLuong;
        private System.Windows.Forms.Label lblSLText;
        private System.Windows.Forms.Label ProductPrice;
        private new System.Windows.Forms.Label ProductName;
        private Guna.UI2.WinForms.Guna2Button congSL;
        private Guna.UI2.WinForms.Guna2Button truSL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button removeItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label inventory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox choosed;
    }
}