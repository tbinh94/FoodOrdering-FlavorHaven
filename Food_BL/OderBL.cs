using Food_DL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Food_BL
{
    public class OderBL
    {
        public bool addOder(OderDTO oder)
        {
            try
            {
                return new OderDAL().AddOrder(oder);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public OderDTO getOderByID(int id)
        {
            try
            {
                return new OderDAL().getOderByID(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<OderDTO> getOderByUserID(int userid)
        {
            try
            {
                return new OderDAL().getOderByUserID(userid);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
