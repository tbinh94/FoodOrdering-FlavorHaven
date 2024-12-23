using Food_DTO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace Food_DL
{
    public class CartDAL : DataProvider
    {
        public List<CartDTO> getAllItem(int id)
        {
            int UserID, ProductID, SoLuong;
            List<CartDTO> list = new List<CartDTO>();
            string sql = "Select * from Cart_Item where UserID = " + id;
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    UserID = int.Parse(reader[0].ToString());
                    ProductID = int.Parse(reader[1].ToString());
                    SoLuong = int.Parse(reader[2].ToString());
                    list.Add(new CartDTO { UserID = UserID, ProductID = ProductID, SoLuong = SoLuong });
                }
                reader.Close();
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public bool addCard(int userID, int id)
        {
            string sql = "INSERT INTO Cart_Item (UserID,ProductID, Quantity) Values (" + userID + "," + id + ",1)";
            try
            {
                MyExecuteNonQuery(sql);
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public bool removeCart(int userID, int id)
        {
            string sql = "DELETE FROM Cart_Item WHERE UserID = " + userID + "AND ProductID = " + id;
            try
            {
                MyExecuteNonQuery(sql);
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public bool check_Exist(int userID, int id)
        {
            string sql = "SELECT COUNT(*) FROM Cart_Item WHERE UserID = " + userID + "AND ProductID = " + id;
            try
            {
                return (int)MyExecuteScalar(sql) > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }
        public bool updateQuantity(int userID, int id,int quantity)
        {
            string query = $"UPDATE Cart_Item SET Quantity = " + quantity + " WHERE UserID = " + userID + "AND ProductID = " + id;
            try
            {
                MyExecuteNonQuery(query);
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

    }
}
