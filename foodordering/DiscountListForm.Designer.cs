﻿namespace foodordering
{
    partial class DiscountListForm
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
            this.tlpDiscounts = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tlpDiscounts
            // 
            this.tlpDiscounts.AutoScroll = true;
            this.tlpDiscounts.AutoSize = true;
            this.tlpDiscounts.ColumnCount = 1;
            this.tlpDiscounts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiscounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpDiscounts.Location = new System.Drawing.Point(0, 0);
            this.tlpDiscounts.Name = "tlpDiscounts";
            this.tlpDiscounts.RowCount = 2;
            this.tlpDiscounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiscounts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpDiscounts.Size = new System.Drawing.Size(357, 343);
            this.tlpDiscounts.TabIndex = 0;
            // 
            // DiscountListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 343);
            this.Controls.Add(this.tlpDiscounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DiscountListForm";
            this.Text = "DiscountListForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpDiscounts;
    }
}