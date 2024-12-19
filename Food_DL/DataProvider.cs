using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Food_DL
{
    public class DataProvider
    {
        public SqlConnection cn;
        public DataProvider()
        {
            // (localdb)\\localPC   (localdb)\\localLap
            // localhost
            string cnStr = "Data Source = localhost; Initial Catalog = Test; Integrated Security = True";
            cn = new SqlConnection(cnStr);
        }
        public void Connect()
        {
            try
            {
                if (cn != null && cn.State != System.Data.ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            try
            {
                if (cn != null && cn.State != System.Data.ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public object MyExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = System.Data.CommandType.Text;

            // Thêm tham số nếu có
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            Connect();

            try
            {
                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex; // Hoặc ghi log lỗi nếu cần
            }
            finally
            {
                Disconnect();
            }
        }

        public void MyExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = System.Data.CommandType.Text;

            // Thêm tham số nếu có
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            // Kết nối
            Connect();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex; // Hoặc ghi log lỗi nếu cần
            }
            finally
            {
                // Đảm bảo đóng kết nối
                Disconnect();
            }
        }

        public SqlDataReader MyExecuteReader(string sql, CommandType type)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            Connect();
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
