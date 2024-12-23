using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_DTO;
namespace Food_DL
{
    public class DiscountDAL : DataProvider
    {
        public List<DiscountDTO> GetActiveDiscounts()
        {
            List<DiscountDTO> discounts = new List<DiscountDTO>();

            using (cn)
            {
                string query = @"
                SELECT *
                FROM Discount
                WHERE IsActive = 1";

                SqlCommand command = new SqlCommand(query, cn);
                try
                {
                    cn.Open(); 

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DiscountDTO discount = new DiscountDTO
                            {
                                DiscountID = reader.GetInt32(0),
                                ProductID = reader.GetInt32(1),
                                DiscountRate = (float)reader.GetDouble(2),
                                StartDate = reader.GetDateTime(3),
                                EndDate = reader.GetDateTime(4),
                                IsActive = reader.GetBoolean(5),
                                Description = reader.GetString(6),
                                Image = reader.IsDBNull(7) ? null : reader.GetString(7),
                            };
                            discounts.Add(discount);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return discounts;
        }
        

    }
}
