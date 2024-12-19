using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Food_DL
{
    public class User_DL : DataProvider
    {
        // Kiểm tra đăng nhập
        public bool Login(UserDTO acc, bool isSeller)
        {
            string tableName = isSeller ? "Seller" : "Users"; // Kiểm tra bảng
            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE Username = @Username AND Password = @Password";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@Username", acc.Username },
                { "@Password", acc.Password } // Nên mã hóa mật khẩu trước khi gửi
            };

            try
            {
                return (int)MyExecuteScalar(sql, parameters) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Đăng ký tài khoản mới
        public bool Signup(UserDTO acc, bool isSeller)
        {
            string tableName = isSeller ? "Seller" : "Users";
            string sql = $"INSERT INTO {tableName} (Username, Password, Email, PhoneNumber, Address) " +
                         "VALUES (@Username, @Password, @Email, @PhoneNumber, @Address)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@Username", acc.Username },
                    { "@Password", acc.Password },
                    { "@Email", acc.Email },
                    { "@PhoneNumber", acc.PhoneNumber },
                    { "@Address", acc.Address }
                };

            try
            {
                MyExecuteNonQuery(sql, parameters);
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        public bool IsUsernameExists(string username)
        {
            // SQL Query để kiểm tra username trong cả hai bảng Users và Sellers
            string sql = @"
                SELECT COUNT(*)
                FROM (
                    SELECT Username FROM Users WHERE Username = @Username
                    UNION
                    SELECT Username FROM Seller WHERE Username = @Username
                ) AS Combined";

            // Tạo Dictionary để chứa tham số
            var parameters = new Dictionary<string, object>
            {
                { "@Username", username }
            };

            try
            {
                int result = (int)MyExecuteScalar(sql, parameters);
                return result > 0; // Trả về true nếu tìm thấy username
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int getUserID(string username, bool isSeller)
        {
            string tableName = isSeller ? "Seller" : "Users";
            string columnID = isSeller ? "SellerID" : "UserID";
            int i = 0;

            string sql = $"select {columnID} from {tableName} where Username = '" + username + "'";

            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    i = int.Parse(reader[0].ToString());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return i;
        }

        public UserDTO getUser(int iduser, bool isSeller)
        {
            string tableName = isSeller ? "Seller" : "Users";
            string columnID = isSeller ? "SellerID" : "UserID";

            string sql = $"select * from {tableName} where {columnID} = '" + iduser + "'";
            try
            {
                UserDTO user = null;
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    user = new UserDTO(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
                }
                return user;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool UpdatePassword(int userId, string newPassword, bool isSeller)
        {
            try
            {
                using (cn)
                {
                    cn.Open();
                    string tableName = isSeller ? "Seller" : "Users";
                    string query = $"UPDATE {tableName} SET Password = @Password WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Password", newPassword);
                        cmd.Parameters.AddWithValue("@UserID", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
