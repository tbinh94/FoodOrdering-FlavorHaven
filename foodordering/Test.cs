using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace foodordering
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        private void CheckDatabaseConnection()
        {
            // Chuỗi kết nối (Connection String)
            string connectionString = "Data Source=(localdb)\\localPC;Initial Catalog=Test;Integrated Security=True";

            // Tạo một đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();
                    // Nếu kết nối thành công, thực hiện một truy vấn đơn giản
                    using (SqlCommand command = new SqlCommand("SELECT 1", connection))
                    {
                        command.ExecuteScalar();
                    }
                    MessageBox.Show("Kết nối vào cơ sở dữ liệu thành công!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Không thể kết nối vào cơ sở dữ liệu: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
        }
    }
}
