namespace Food_DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Discount { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int SellerID { get; set; }

        public int Inventory { get; set; }
        public int CategoryID { get; set; }

    }
}
