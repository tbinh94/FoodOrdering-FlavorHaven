﻿namespace foodordering
{
    partial class Food_Seller_Form
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
            this.tLP = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tLP
            // 
            this.tLP.ColumnCount = 3;
            this.tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tLP.Location = new System.Drawing.Point(0, 0);
            this.tLP.Margin = new System.Windows.Forms.Padding(2, 26, 2, 2);
            this.tLP.Name = "tLP";
            this.tLP.Padding = new System.Windows.Forms.Padding(0, 26, 0, 0);
            this.tLP.RowCount = 2;
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tLP.Size = new System.Drawing.Size(685, 389);
            this.tLP.TabIndex = 0;
            // 
            // Food_Seller_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(685, 389);
            this.Controls.Add(this.tLP);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Food_Seller_Form";
            this.Text = "FoodCategoryForm";
            this.Load += new System.EventHandler(this.FoodCategoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tLP;
    }
}