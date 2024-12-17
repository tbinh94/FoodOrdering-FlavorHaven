namespace foodordering
{
    partial class save_productSeller_form
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
            this.img = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_choose_img = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.priceTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CategoryCbb = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTxt = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.addressTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.SystemColors.ControlLight;
            this.img.Location = new System.Drawing.Point(50, 43);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(399, 274);
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            this.img.DragDrop += new System.Windows.Forms.DragEventHandler(this.img_DragDrop);
            this.img.DragEnter += new System.Windows.Forms.DragEventHandler(this.img_DragEnter);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_choose_img
            // 
            this.btn_choose_img.Location = new System.Drawing.Point(498, 247);
            this.btn_choose_img.Name = "btn_choose_img";
            this.btn_choose_img.Size = new System.Drawing.Size(140, 70);
            this.btn_choose_img.TabIndex = 1;
            this.btn_choose_img.Text = "Chọn ảnh";
            this.btn_choose_img.UseVisualStyleBackColor = true;
            this.btn_choose_img.Click += new System.EventHandler(this.btn_choose_img_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(229, 395);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(445, 31);
            this.nameTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 463);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá:";
            // 
            // priceTxt
            // 
            this.priceTxt.Location = new System.Drawing.Point(229, 457);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(445, 31);
            this.priceTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 521);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại sản phẩm:";
            // 
            // CategoryCbb
            // 
            this.CategoryCbb.FormattingEnabled = true;
            this.CategoryCbb.Location = new System.Drawing.Point(229, 513);
            this.CategoryCbb.Name = "CategoryCbb";
            this.CategoryCbb.Size = new System.Drawing.Size(198, 33);
            this.CategoryCbb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 581);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mô tả:";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.Location = new System.Drawing.Point(229, 581);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(445, 31);
            this.descriptionTxt.TabIndex = 9;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(55, 747);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(171, 59);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Đăng bán";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 648);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa chỉ:";
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(229, 648);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(445, 31);
            this.addressTxt.TabIndex = 12;
            // 
            // save_productSeller_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 857);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.addressTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.descriptionTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CategoryCbb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.priceTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_choose_img);
            this.Controls.Add(this.img);
            this.Name = "save_productSeller_form";
            this.Text = "save_productSeller_form";
            this.Load += new System.EventHandler(this.save_productSeller_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_choose_img;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox priceTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CategoryCbb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descriptionTxt;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addressTxt;
    }
}