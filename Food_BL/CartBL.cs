using Food_DL;
using Food_DTO;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Food_BL
{
    public class CartBL
    {
        public List<CartDTO> GetCart(int id)
        {
            try
            {
                return (new CartDAL().getAllItem(id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool add_Item_Cart(int userID = 1, int id = 1)
        {
            try
            {
                return (new CartDAL().addCard(userID, id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool remove_Item_Cart(int userID = 1, int id = 1)
        {
            try
            {
                return (new CartDAL().removeCart(userID, id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool check_Exist(int userID = 1, int id = 1)
        {
            try
            {
                return (new CartDAL().check_Exist(userID, id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

    }
}
