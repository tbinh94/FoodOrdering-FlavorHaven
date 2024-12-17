using System.Data;
using System.Data.SqlClient;

namespace foodordering
{
    internal class SQL
    {
        public static readonly string con_string = "Data Source=(localdb)\\localLap; Initial Catalog=Test; Integrated Security=True;";
        public static SqlConnection con = new SqlConnection(con_string);

        public static bool IsValidUser(string username, string pass)
        {
            bool isValid = false;
            string qry = @"Select * from Users where Username ='" + username + "' and Password ='" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
