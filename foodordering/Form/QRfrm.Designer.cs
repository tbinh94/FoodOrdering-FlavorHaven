namespace foodordering
{
    partial class QRfrm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bthHuy = new foodordering.BorderButton();
            this.btnXacNhan = new foodordering.BorderButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 264);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 264);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bthHuy);
            this.panel1.Controls.Add(this.btnXacNhan);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 264);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 52);
            this.panel1.TabIndex = 2;
            // 
            // bthHuy
            // 
            this.bthHuy.BackColor = System.Drawing.Color.Transparent;
            this.bthHuy.BorderColor = System.Drawing.Color.OrangeRed;
            this.bthHuy.BorderWidth = 2;
            this.bthHuy.DefaultTextColor = System.Drawing.Color.Black;
            this.bthHuy.FlatAppearance.BorderSize = 0;
            this.bthHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bthHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bthHuy.ForeColor = System.Drawing.Color.Black;
            this.bthHuy.HoverTextColor = System.Drawing.Color.OrangeRed;
            this.bthHuy.Location = new System.Drawing.Point(194, 12);
            this.bthHuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bthHuy.Name = "bthHuy";
            this.bthHuy.Size = new System.Drawing.Size(82, 26);
            this.bthHuy.TabIndex = 1;
            this.bthHuy.Text = "Hủy";
            this.bthHuy.UseVisualStyleBackColor = false;
            this.bthHuy.Click += new System.EventHandler(this.bthHuy_Click);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Transparent;
            this.btnXacNhan.BorderColor = System.Drawing.Color.OrangeRed;
            this.btnXacNhan.BorderWidth = 2;
            this.btnXacNhan.DefaultTextColor = System.Drawing.Color.Black;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.Black;
            this.btnXacNhan.HoverTextColor = System.Drawing.Color.OrangeRed;
            this.btnXacNhan.Location = new System.Drawing.Point(40, 12);
            this.btnXacNhan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(98, 26);
            this.btnXacNhan.TabIndex = 0;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // QRfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 316);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "QRfrm";
            this.Text = "QRfrm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private BorderButton bthHuy;
        private BorderButton btnXacNhan;
    }
}