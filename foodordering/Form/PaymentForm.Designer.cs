namespace foodordering
{
    partial class PaymentForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfoSeller = new System.Windows.Forms.Label();
            this.flpFoodList = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpExtraFood = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSl = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.voucherPanel = new System.Windows.Forms.Panel();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBank = new Guna.UI2.WinForms.Guna2Button();
            this.btnCash = new Guna.UI2.WinForms.Guna2Button();
            this.btnOrder = new Guna.UI2.WinForms.Guna2Button();
            this.tlpBuyerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInfoUser = new System.Windows.Forms.Label();
            this.voucherPanel.SuspendLayout();
            this.tlpBuyerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ giao hàng";
            // 
            // lblInfoSeller
            // 
            this.lblInfoSeller.AutoSize = true;
            this.lblInfoSeller.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoSeller.Location = new System.Drawing.Point(26, 262);
            this.lblInfoSeller.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInfoSeller.Name = "lblInfoSeller";
            this.lblInfoSeller.Size = new System.Drawing.Size(659, 36);
            this.lblInfoSeller.TabIndex = 2;
            this.lblInfoSeller.Text = "Tên seller hoặc tên quán sẽ hiển thị ở đây";
            // 
            // flpFoodList
            // 
            this.flpFoodList.AutoScroll = true;
            this.flpFoodList.Location = new System.Drawing.Point(32, 319);
            this.flpFoodList.Margin = new System.Windows.Forms.Padding(6);
            this.flpFoodList.Name = "flpFoodList";
            this.flpFoodList.Size = new System.Drawing.Size(778, 396);
            this.flpFoodList.TabIndex = 3;
            this.flpFoodList.Paint += new System.Windows.Forms.PaintEventHandler(this.flpFoodList_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 748);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(605, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách đặt các món này cũng đặt thêm";
            // 
            // flpExtraFood
            // 
            this.flpExtraFood.Location = new System.Drawing.Point(32, 813);
            this.flpExtraFood.Margin = new System.Windows.Forms.Padding(6);
            this.flpExtraFood.Name = "flpExtraFood";
            this.flpExtraFood.Size = new System.Drawing.Size(778, 167);
            this.flpExtraFood.TabIndex = 5;
            // 
            // lblSl
            // 
            this.lblSl.AutoSize = true;
            this.lblSl.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSl.Location = new System.Drawing.Point(24, 1035);
            this.lblSl.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSl.Name = "lblSl";
            this.lblSl.Size = new System.Drawing.Size(414, 29);
            this.lblSl.TabIndex = 6;
            this.lblSl.Text = "Tổng giá món ( + số món ở đây )";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Enabled = false;
            this.txtTotalPrice.Location = new System.Drawing.Point(610, 1035);
            this.txtTotalPrice.Margin = new System.Windows.Forms.Padding(6);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(196, 31);
            this.txtTotalPrice.TabIndex = 7;
            // 
            // voucherPanel
            // 
            this.voucherPanel.Controls.Add(this.lblDiscount);
            this.voucherPanel.Controls.Add(this.label5);
            this.voucherPanel.Location = new System.Drawing.Point(32, 1133);
            this.voucherPanel.Margin = new System.Windows.Forms.Padding(6);
            this.voucherPanel.Name = "voucherPanel";
            this.voucherPanel.Size = new System.Drawing.Size(778, 87);
            this.voucherPanel.TabIndex = 8;
            this.voucherPanel.Click += new System.EventHandler(this.voucherPanel_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDiscount.Location = new System.Drawing.Point(562, 29);
            this.lblDiscount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(164, 25);
            this.lblDiscount.TabIndex = 1;
            this.lblDiscount.Text = "Chọn voucher >";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 29);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thêm voucher";
            // 
            // btnBank
            // 
            this.btnBank.BackColor = System.Drawing.Color.Transparent;
            this.btnBank.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnBank.BorderThickness = 1;
            this.btnBank.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnBank.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBank.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBank.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBank.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBank.FillColor = System.Drawing.Color.Transparent;
            this.btnBank.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnBank.ForeColor = System.Drawing.Color.Tomato;
            this.btnBank.Location = new System.Drawing.Point(32, 1231);
            this.btnBank.Margin = new System.Windows.Forms.Padding(6);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(370, 71);
            this.btnBank.TabIndex = 9;
            this.btnBank.Text = "Chuyển khoản ngân hàng";
            this.btnBank.UseTransparentBackground = true;
            this.btnBank.Click += new System.EventHandler(this.btnBank_Click);
            // 
            // btnCash
            // 
            this.btnCash.BackColor = System.Drawing.Color.Transparent;
            this.btnCash.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnCash.BorderThickness = 1;
            this.btnCash.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnCash.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCash.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCash.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCash.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCash.FillColor = System.Drawing.Color.Transparent;
            this.btnCash.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold);
            this.btnCash.ForeColor = System.Drawing.Color.Tomato;
            this.btnCash.Location = new System.Drawing.Point(440, 1231);
            this.btnCash.Margin = new System.Windows.Forms.Padding(6);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(370, 71);
            this.btnCash.TabIndex = 10;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.UseTransparentBackground = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnOrder.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnOrder.BorderThickness = 1;
            this.btnOrder.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.btnOrder.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOrder.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOrder.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOrder.FillColor = System.Drawing.Color.Tomato;
            this.btnOrder.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(32, 1313);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(6);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(778, 71);
            this.btnOrder.TabIndex = 11;
            this.btnOrder.Text = "Đặt đơn - (Tổng số tiền ở đây)";
            this.btnOrder.UseTransparentBackground = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // tlpBuyerInfo
            // 
            this.tlpBuyerInfo.ColumnCount = 1;
            this.tlpBuyerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBuyerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpBuyerInfo.Controls.Add(this.label8, 0, 1);
            this.tlpBuyerInfo.Controls.Add(this.lblInfoUser, 0, 0);
            this.tlpBuyerInfo.Location = new System.Drawing.Point(32, 58);
            this.tlpBuyerInfo.Margin = new System.Windows.Forms.Padding(6);
            this.tlpBuyerInfo.Name = "tlpBuyerInfo";
            this.tlpBuyerInfo.RowCount = 2;
            this.tlpBuyerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBuyerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBuyerInfo.Size = new System.Drawing.Size(778, 169);
            this.tlpBuyerInfo.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hiện địa chỉ";
            // 
            // lblInfoUser
            // 
            this.lblInfoUser.AutoSize = true;
            this.lblInfoUser.Location = new System.Drawing.Point(6, 0);
            this.lblInfoUser.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblInfoUser.Name = "lblInfoUser";
            this.lblInfoUser.Size = new System.Drawing.Size(398, 25);
            this.lblInfoUser.TabIndex = 0;
            this.lblInfoUser.Text = "Ở đây hiện tên người mua | số điện thoại";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(878, 873);
            this.Controls.Add(this.tlpBuyerInfo);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.voucherPanel);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.lblSl);
            this.Controls.Add(this.flpExtraFood);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flpFoodList);
            this.Controls.Add(this.lblInfoSeller);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "PaymentForm";
            this.Text = "Thanh toán";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PaymentForm_FormClosed);
            this.Load += new System.EventHandler(this.PaymentForm_Load);
            this.voucherPanel.ResumeLayout(false);
            this.voucherPanel.PerformLayout();
            this.tlpBuyerInfo.ResumeLayout(false);
            this.tlpBuyerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfoSeller;
        private System.Windows.Forms.FlowLayoutPanel flpFoodList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpExtraFood;
        private System.Windows.Forms.Label lblSl;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Panel voucherPanel;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnBank;
        private Guna.UI2.WinForms.Guna2Button btnCash;
        private Guna.UI2.WinForms.Guna2Button btnOrder;
        private System.Windows.Forms.TableLayoutPanel tlpBuyerInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblInfoUser;
    }
}