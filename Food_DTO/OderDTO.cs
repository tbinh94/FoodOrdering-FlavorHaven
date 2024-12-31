using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_DTO
{
    public class OderDTO
    {
        public int OderID { get; set; }
        public int UserID { get; set; }
        public DateTime OderDate { get; set; }
        public List<Tuple<int, int, decimal>> OrderItemsList { get; set; }
        public decimal Total { get; set; }

    }
}
