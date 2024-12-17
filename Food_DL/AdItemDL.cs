using Food_DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Food_DL
{
    public class AdItemDL : DataProvider
    {
        public List<AdItemDTO> GetAllAdsFromDatabase()
        {
            List<AdItemDTO> adList = new List<AdItemDTO>();

            string query = "SELECT * FROM Discount"; // Query lấy dữ liệu từ cơ sở dữ liệu

            using (cn)
            {
                SqlCommand cmd = new SqlCommand(query, cn);
                cn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AdItemDTO adItem = new AdItemDTO
                    {
                        Id = (int)reader["DiscountID"],
                        AdDescription = reader["Description"].ToString(),
                        Image = reader["Image"].ToString(),
                    };
                    adList.Add(adItem);
                }
            }

            return adList;
        }
    }

}
