using System;
using System.Collections.Generic;

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
