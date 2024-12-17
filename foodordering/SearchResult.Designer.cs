namespace foodordering
{
    partial class SearchResult
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
            this.containerPanel = new System.Windows.Forms.Panel();
            this.panelCbox = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnDistrict = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.containerPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerPanel
            // 
            this.containerPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.containerPanel.Controls.Add(this.panelCbox);
            this.containerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerPanel.Location = new System.Drawing.Point(0, 54);
            this.containerPanel.Name = "containerPanel";
            this.containerPanel.Size = new System.Drawing.Size(816, 334);
            this.containerPanel.TabIndex = 3;
            // 
            // panelCbox
            // 
            this.panelCbox.BackColor = System.Drawing.Color.White;
            this.panelCbox.Location = new System.Drawing.Point(0, 6);
            this.panelCbox.Name = "panelCbox";
            this.panelCbox.Size = new System.Drawing.Size(379, 111);
            this.panelCbox.TabIndex = 0;
            this.panelCbox.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCategory);
            this.panel1.Controls.Add(this.btnDistrict);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(816, 54);
            this.panel1.TabIndex = 4;
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategory.Location = new System.Drawing.Point(112, 10);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(94, 41);
            this.btnCategory.TabIndex = 3;
            this.btnCategory.Text = "PHÂN LOẠI\r\n⇩";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnDistrict
            // 
            this.btnDistrict.FlatAppearance.BorderSize = 0;
            this.btnDistrict.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDistrict.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDistrict.Location = new System.Drawing.Point(12, 10);
            this.btnDistrict.Name = "btnDistrict";
            this.btnDistrict.Size = new System.Drawing.Size(94, 41);
            this.btnDistrict.TabIndex = 2;
            this.btnDistrict.Text = "KHU VỰC\r\n⇩\r\n";
            this.btnDistrict.UseVisualStyleBackColor = true;
            this.btnDistrict.Click += new System.EventHandler(this.btnDistrict_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 388);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(816, 62);
            this.panel2.TabIndex = 5;
            // 
            // SearchResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 450);
            this.Controls.Add(this.containerPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "SearchResult";
            this.Text = "SearchResult";
            this.containerPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerPanel;
        private System.Windows.Forms.FlowLayoutPanel panelCbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnDistrict;
        private System.Windows.Forms.Panel panel2;
    }
}