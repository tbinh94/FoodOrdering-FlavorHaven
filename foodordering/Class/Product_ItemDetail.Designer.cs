namespace foodordering
{
    partial class Product_ItemDetail
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
            this.productPic = new System.Windows.Forms.PictureBox();
            this.ProductName = new System.Windows.Forms.Label();
            this.ProductDescription = new System.Windows.Forms.Label();
            this.ProductPrice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).BeginInit();
            this.SuspendLayout();
            // 
            // productPic
            // 
            this.productPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.productPic.Location = new System.Drawing.Point(0, 0);
            this.productPic.Name = "productPic";
            this.productPic.Size = new System.Drawing.Size(243, 197);
            this.productPic.TabIndex = 0;
            this.productPic.TabStop = false;
            // 
            // ProductName
            // 
            this.ProductName.AutoSize = true;
            this.ProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductName.Location = new System.Drawing.Point(272, 18);
            this.ProductName.Name = "ProductName";
            this.ProductName.Size = new System.Drawing.Size(101, 16);
            this.ProductName.TabIndex = 1;
            this.ProductName.Text = "ProductName";
            // 
            // ProductDescription
            // 
            this.ProductDescription.AutoSize = true;
            this.ProductDescription.Location = new System.Drawing.Point(272, 56);
            this.ProductDescription.Name = "ProductDescription";
            this.ProductDescription.Size = new System.Drawing.Size(121, 16);
            this.ProductDescription.TabIndex = 2;
            this.ProductDescription.Text = "ProductDescription";
            // 
            // ProductPrice
            // 
            this.ProductPrice.AutoSize = true;
            this.ProductPrice.Location = new System.Drawing.Point(596, 18);
            this.ProductPrice.Name = "ProductPrice";
            this.ProductPrice.Size = new System.Drawing.Size(84, 16);
            this.ProductPrice.TabIndex = 3;
            this.ProductPrice.Text = "ProductPrice";
            // 
            // Product_ItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProductPrice);
            this.Controls.Add(this.ProductDescription);
            this.Controls.Add(this.ProductName);
            this.Controls.Add(this.productPic);
            this.Name = "Product_ItemDetail";
            this.Size = new System.Drawing.Size(780, 197);
            ((System.ComponentModel.ISupportInitialize)(this.productPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox productPic;
        private new System.Windows.Forms.Label ProductName;
        private System.Windows.Forms.Label ProductDescription;
        private System.Windows.Forms.Label ProductPrice;
    }
}
