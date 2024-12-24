using Food_DL;
using Food_DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Food_BL
{
    public class DiscountBL
    {
        private DiscountDAL discountDAL;
        public SqlConnection cnString;
        public DiscountBL()
        {
            discountDAL = new DiscountDAL();
            cnString = new SqlConnection("Data Source = (localdb)\\localPC; Initial Catalog = Test; Integrated Security = True");
        }

        public List<DiscountDTO> GetActiveDiscounts()
        {
            return discountDAL.GetActiveDiscounts();
        }

    }
}
