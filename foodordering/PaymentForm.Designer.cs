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
            this.label2 = new System.Windows.Forms.Label();
            this.flpFoodList = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.flpExtraFood = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.voucherPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBank = new Guna.UI2.WinForms.Guna2Button();
            this.btnCash = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.tlpBuyerInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.voucherPanel.SuspendLayout();
            this.tlpBuyerInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Địa chỉ giao hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(316, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên seller hoặc tên quán sẽ hiển thị ở đây";
            // 
            // flpFoodList
            // 
            this.flpFoodList.Location = new System.Drawing.Point(16, 166);
            this.flpFoodList.Name = "flpFoodList";
            this.flpFoodList.Size = new System.Drawing.Size(389, 254);
            this.flpFoodList.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 434);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(296, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách đặt các món này cũng đặt thêm";
            // 
            // flpExtraFood
            // 
            this.flpExtraFood.Location = new System.Drawing.Point(16, 466);
            this.flpExtraFood.Name = "flpExtraFood";
            this.flpExtraFood.Size = new System.Drawing.Size(389, 64);
            this.flpExtraFood.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tổng giá món ( + số món ở đây )";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(305, 548);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPrice.TabIndex = 7;
            // 
            // voucherPanel
            // 
            this.voucherPanel.Controls.Add(this.label6);
            this.voucherPanel.Controls.Add(this.label5);
            this.voucherPanel.Location = new System.Drawing.Point(16, 589);
            this.voucherPanel.Name = "voucherPanel";
            this.voucherPanel.Size = new System.Drawing.Size(389, 45);
            this.voucherPanel.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thêm voucher";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(281, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Chọn voucher >";
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
            this.btnBank.Location = new System.Drawing.Point(16, 657);
            this.btnBank.Name = "btnBank";
            this.btnBank.Size = new System.Drawing.Size(185, 37);
            this.btnBank.TabIndex = 9;
            this.btnBank.Text = "Chuyển khoản ngân hàng";
            this.btnBank.UseTransparentBackground = true;
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
            this.btnCash.Location = new System.Drawing.Point(220, 657);
            this.btnCash.Name = "btnCash";
            this.btnCash.Size = new System.Drawing.Size(185, 37);
            this.btnCash.TabIndex = 10;
            this.btnCash.Text = "Tiền mặt";
            this.btnCash.UseTransparentBackground = true;
            // 
            // guna2Button3
            // 
            this.guna2Button3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button3.BorderColor = System.Drawing.Color.OrangeRed;
            this.guna2Button3.BorderThickness = 1;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton;
            this.guna2Button3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button3.FillColor = System.Drawing.Color.Tomato;
            this.guna2Button3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(16, 700);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(389, 37);
            this.guna2Button3.TabIndex = 11;
            this.guna2Button3.Text = "Đặt đơn - (Tổng số tiền ở đây)";
            this.guna2Button3.UseTransparentBackground = true;
            // 
            // tlpBuyerInfo
            // 
            this.tlpBuyerInfo.ColumnCount = 1;
            this.tlpBuyerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBuyerInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBuyerInfo.Controls.Add(this.label8, 0, 1);
            this.tlpBuyerInfo.Controls.Add(this.label7, 0, 0);
            this.tlpBuyerInfo.Location = new System.Drawing.Point(16, 30);
            this.tlpBuyerInfo.Name = "tlpBuyerInfo";
            this.tlpBuyerInfo.RowCount = 2;
            this.tlpBuyerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBuyerInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBuyerInfo.Size = new System.Drawing.Size(389, 88);
            this.tlpBuyerInfo.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(198, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ở đây hiện tên người mua | số điện thoại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hiện địa chỉ";
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 749);
            this.Controls.Add(this.tlpBuyerInfo);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.btnCash);
            this.Controls.Add(this.btnBank);
            this.Controls.Add(this.voucherPanel);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flpExtraFood);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flpFoodList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PaymentForm";
            this.Text = "Thanh toán";
            this.voucherPanel.ResumeLayout(false);
            this.voucherPanel.PerformLayout();
            this.tlpBuyerInfo.ResumeLayout(false);
            this.tlpBuyerInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flpFoodList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flpExtraFood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Panel voucherPanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button btnBank;
        private Guna.UI2.WinForms.Guna2Button btnCash;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.TableLayoutPanel tlpBuyerInfo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}