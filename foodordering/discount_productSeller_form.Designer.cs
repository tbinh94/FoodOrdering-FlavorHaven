namespace foodordering
{
    partial class discount_productSeller_form
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
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.priceTxt = new System.Windows.Forms.TextBox();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.slTxt = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.SuspendLayout();
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.SystemColors.ControlLight;
            this.img.Location = new System.Drawing.Point(443, 23);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(399, 274);
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            this.img.Click += new System.EventHandler(this.img_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // nameTxt
            // 
            this.nameTxt.Enabled = false;
            this.nameTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(419, 303);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(445, 44);
            this.nameTxt.TabIndex = 3;
            // 
            // priceTxt
            // 
            this.priceTxt.Enabled = false;
            this.priceTxt.Location = new System.Drawing.Point(559, 373);
            this.priceTxt.Name = "priceTxt";
            this.priceTxt.Size = new System.Drawing.Size(141, 31);
            this.priceTxt.TabIndex = 5;
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.Location = new System.Drawing.Point(1012, 777);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(171, 59);
            this.btn_xacnhan.TabIndex = 10;
            this.btn_xacnhan.Text = "Xác nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = true;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 709);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tồn kho:";
            // 
            // slTxt
            // 
            this.slTxt.Enabled = false;
            this.slTxt.Location = new System.Drawing.Point(229, 703);
            this.slTxt.Name = "slTxt";
            this.slTxt.Size = new System.Drawing.Size(141, 31);
            this.slTxt.TabIndex = 14;
            this.slTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.slTxt_KeyPress);
            // 
            // discount_productSeller_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 857);
            this.Controls.Add(this.slTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.priceTxt);
            this.Controls.Add(this.nameTxt);
            this.Controls.Add(this.img);
            this.Name = "discount_productSeller_form";
            this.Text = "save_productSeller_form";
            this.Load += new System.EventHandler(this.save_productSeller_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox img;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox nameTxt;
        private System.Windows.Forms.TextBox priceTxt;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox slTxt;
    }
}