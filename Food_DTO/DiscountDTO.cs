using System;

namespace Food_DTO
{
    public class DiscountDTO
    {
        public int DiscountID { get; set; }
        public int ProductID { get; set; }
        public float DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
