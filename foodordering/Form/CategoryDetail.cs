using System;
using System.Windows.Forms;

namespace foodordering
{
    public partial class CategoryDetail : Form
    {
        public CategoryDetail(string filePath)
        {
            InitializeComponent();

            // Load file RTF vào RichTextBox
            try
            {
                richTextBox1.LoadFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu lỗi
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
