using Food_DL;
using Food_DTO;
using System;
using System.Data.SqlClient;

namespace Food_BL
{
    public class UserBL
    {
        private readonly User_DL loginDL = new User_DL();

        // Đăng nhập
        public bool Login(UserDTO acc, bool isSeller = false)
        {
            try
            {
                return loginDL.Login(acc, isSeller);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Đăng ký
        public bool Signup(UserDTO acc, bool isSeller)
        {
            try
            {
                if (loginDL.IsUsernameExists(acc.Username))
                {
                    throw new Exception("Tên đăng nhập đã tồn tại.");
                }

                return loginDL.Signup(acc, isSeller);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool IsUsernameExists(string username)
        {
            User_DL userDL = new User_DL();
            return userDL.IsUsernameExists(username);
        }

        public int getUserID(string username, bool isSeller)
        {
            try
            {
                return loginDL.getUserID(username, isSeller);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public UserDTO getUser(int id, bool isSeller)
        {
            try
            {
                return loginDL.getUser(id, isSeller);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
