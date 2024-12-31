namespace foodordering
{
    partial class OderPerItem
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
            this.total = new System.Windows.Forms.Label();
            this.borderButton1 = new foodordering.BorderButton();
            this.fLP = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.shopName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.total);
            this.panel1.Controls.Add(this.borderButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 425);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(938, 72);
            this.panel1.TabIndex = 1;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Dock = System.Windows.Forms.DockStyle.Right;
            this.total.Location = new System.Drawing.Point(715, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(53, 25);
            this.total.TabIndex = 1;
            this.total.Text = "total";
            // 
            // borderButton1
            // 
            this.borderButton1.BackColor = System.Drawing.Color.Transparent;
            this.borderButton1.BorderColor = System.Drawing.Color.OrangeRed;
            this.borderButton1.BorderWidth = 2;
            this.borderButton1.DefaultTextColor = System.Drawing.Color.Black;
            this.borderButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.borderButton1.FlatAppearance.BorderSize = 0;
            this.borderButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderButton1.ForeColor = System.Drawing.Color.Black;
            this.borderButton1.HoverTextColor = System.Drawing.Color.OrangeRed;
            this.borderButton1.Location = new System.Drawing.Point(768, 0);
            this.borderButton1.Name = "borderButton1";
            this.borderButton1.Size = new System.Drawing.Size(170, 72);
            this.borderButton1.TabIndex = 0;
            this.borderButton1.Text = "Mua lại";
            this.borderButton1.UseVisualStyleBackColor = false;
            // 
            // fLP
            // 
            this.fLP.AutoScroll = true;
            this.fLP.AutoSize = true;
            this.fLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fLP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fLP.Location = new System.Drawing.Point(0, 0);
            this.fLP.Name = "fLP";
            this.fLP.Size = new System.Drawing.Size(938, 367);
            this.fLP.TabIndex = 2;
            this.fLP.WrapContents = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(938, 425);
            this.panel2.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.fLP);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(938, 367);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.time);
            this.panel3.Controls.Add(this.shopName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(938, 58);
            this.panel3.TabIndex = 0;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Dock = System.Windows.Forms.DockStyle.Right;
            this.time.Location = new System.Drawing.Point(886, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(52, 25);
            this.time.TabIndex = 1;
            this.time.Text = "time";
            // 
            // shopName
            // 
            this.shopName.AutoSize = true;
            this.shopName.Location = new System.Drawing.Point(29, 14);
            this.shopName.Name = "shopName";
            this.shopName.Size = new System.Drawing.Size(115, 25);
            this.shopName.TabIndex = 0;
            this.shopName.Text = "shopName";
            // 
            // OderPerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OderPerItem";
            this.Size = new System.Drawing.Size(938, 497);
            this.Load += new System.EventHandler(this.OderPerItem_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel fLP;
        private BorderButton borderButton1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label shopName;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label time;
    }
}
