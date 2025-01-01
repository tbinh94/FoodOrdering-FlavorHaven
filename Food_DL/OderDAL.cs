using Food_DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Food_DL
{
    public class OderDAL : DataProvider
    {
        public bool AddOrder(OderDTO order)
        {
            string sql = "INSERT INTO Orders (CustomerID, OrderDate,OrderItemsList,TotalAmount) VALUES ( @CustomerID, @OrderDate, @OrderItemsList, @TotalAmount)";
            var orderItemsJson = JsonConvert.SerializeObject(order.OrderItemsList);
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                    { "@CustomerID", order.UserID },
                    { "@OrderDate",order.OderDate },
                    { "@OrderItemsList", orderItemsJson },
                    { "@TotalAmount", order.Total }
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
        public OderDTO getOderByID(int id)
        {
            return OderDTO_reader("SELECT* FROM Orders WHERE OrderID = " + id);
        }
        public List<OderDTO> getOderByUserID(int userId)
        {
            string sql = "SELECT* FROM Orders WHERE CustomerID = " + userId;
            List<OderDTO> list = new List<OderDTO>();

            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    var orderItemsJson = reader[3].ToString();
                    var orderItems = JsonConvert.DeserializeObject<List<Tuple<int, int, decimal>>>(orderItemsJson);
                    list.Add(new OderDTO
                    {
                        OderID = int.Parse(reader[0].ToString()),
                        UserID = int.Parse(reader[1].ToString()),
                        OderDate = reader.GetDateTime(2),
                        OrderItemsList = orderItems,
                        Total = decimal.Parse(reader[4].ToString()),

                    });
                }
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

        public OderDTO OderDTO_reader(string text)
        {
            string sql = text;
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                if (reader.Read())
                {
                    var orderItemsJson = reader[3].ToString();
                    var orderItems = JsonConvert.DeserializeObject<List<Tuple<int, int, decimal>>>(orderItemsJson);
                    return new OderDTO
                    {
                        OderID = int.Parse(reader[0].ToString()),
                        UserID = int.Parse(reader[1].ToString()),
                        OderDate = reader.GetDateTime(2),
                        OrderItemsList = orderItems,
                        Total = decimal.Parse(reader[4].ToString()),

                    };
                }
                return null;
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
