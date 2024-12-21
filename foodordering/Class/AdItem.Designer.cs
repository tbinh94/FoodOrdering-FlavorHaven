namespace foodordering
{
    partial class AdItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAdDescription = new System.Windows.Forms.Label();
            this.pictureBoxAd = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAdDescription);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 138);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 23);
            this.panel1.TabIndex = 7;
            // 
            // lblAdDescription
            // 
            this.lblAdDescription.AutoSize = true;
            this.lblAdDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdDescription.Location = new System.Drawing.Point(3, 0);
            this.lblAdDescription.Name = "lblAdDescription";
            this.lblAdDescription.Size = new System.Drawing.Size(44, 16);
            this.lblAdDescription.TabIndex = 3;
            this.lblAdDescription.Text = "label2";
            // 
            // pictureBoxAd
            // 
            this.pictureBoxAd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAd.ImageRotate = 0F;
            this.pictureBoxAd.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxAd.Name = "pictureBoxAd";
            this.pictureBoxAd.Size = new System.Drawing.Size(199, 161);
            this.pictureBoxAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAd.TabIndex = 1;
            this.pictureBoxAd.TabStop = false;
            // 
            // AdItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxAd);
            this.Name = "AdItem";
            this.Size = new System.Drawing.Size(199, 161);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pictureBoxAd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAdDescription;
    }
}
