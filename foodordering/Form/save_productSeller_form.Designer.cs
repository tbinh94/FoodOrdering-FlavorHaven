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
            this.img.Location = new System.Drawing.Point(152, 22);
            this.img.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(200, 142);
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
            this.btn_choose_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_choose_img.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_choose_img.FlatAppearance.BorderSize = 2;
            this.btn_choose_img.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_choose_img.Location = new System.Drawing.Point(437, 128);
            this.btn_choose_img.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_choose_img.Name = "btn_choose_img";
            this.btn_choose_img.Size = new System.Drawing.Size(145, 36);
            this.btn_choose_img.TabIndex = 1;
            this.btn_choose_img.Text = "Chọn ảnh sản phẩm";
            this.btn_choose_img.UseVisualStyleBackColor = true;
            this.btn_choose_img.Click += new System.EventHandler(this.btn_choose_img_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // nameTxt
            // 
            this.nameTxt.Location = new System.Drawing.Point(152, 207);
            this.nameTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(430, 20);
            this.nameTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Giá:";
            // 
            // priceTxt
            // 
            this.priceTxt.Location = new System.Drawing.Point(152, 240);
            this.priceTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(430, 20);
            this.priceTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 271);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Loại sản phẩm:";
            // 
            // CategoryCbb
            // 
            this.CategoryCbb.FormattingEnabled = true;
            this.CategoryCbb.Location = new System.Drawing.Point(152, 269);
            this.CategoryCbb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CategoryCbb.Name = "CategoryCbb";
            this.CategoryCbb.Size = new System.Drawing.Size(430, 21);
            this.CategoryCbb.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 302);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mô tả:";
            // 
            // descriptionTxt
            // 
            this.descriptionTxt.Location = new System.Drawing.Point(152, 304);
            this.descriptionTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.descriptionTxt.Name = "descriptionTxt";
            this.descriptionTxt.Size = new System.Drawing.Size(430, 20);
            this.descriptionTxt.TabIndex = 9;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(28, 388);
            this.btn_save.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(86, 31);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Đăng bán";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 337);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Địa chỉ:";
            // 
            // addressTxt
            // 
            this.addressTxt.Location = new System.Drawing.Point(152, 339);
            this.addressTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addressTxt.Name = "addressTxt";
            this.addressTxt.Size = new System.Drawing.Size(430, 20);
            this.addressTxt.TabIndex = 12;
            // 
            // save_productSeller_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 389);
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
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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