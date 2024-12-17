using System;
using System.Drawing;
using System.Windows.Forms;

namespace foodordering
{
    public class CustomTextBox : TextBox
    {
        private string _placeholder = "";
        private Color _placeholderColor = Color.Gray;
        private Color _originalForeColor;

        public string Placeholder
        {
            get { return _placeholder; }
            set
            {
                _placeholder = value;
                if (string.IsNullOrEmpty(this.Text))
                    this.Text = _placeholder;
            }
        }

        public Color PlaceholderColor
        {
            get { return _placeholderColor; }
            set { _placeholderColor = value; }
        }

        public CustomTextBox()
        {
            _originalForeColor = this.ForeColor;
            this.GotFocus += CustomTextBox_GotFocus;
            this.LostFocus += CustomTextBox_LostFocus;
        }

        private void CustomTextBox_GotFocus(object sender, EventArgs e)
        {
            if (this.Text == _placeholder)
            {
                this.Text = "";
                this.ForeColor = _originalForeColor;
            }
        }

        private void CustomTextBox_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = _placeholder;
                this.ForeColor = _placeholderColor;
            }
        }
    }
}