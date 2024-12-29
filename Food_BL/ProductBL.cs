using Food_DL;
using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Food_BL
{
    public class ProductBL
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string DiscountText { get; set; }
        public string Address { get; set; }
        public int id { get; set; }

        private ProductDAL productDAL;
        public static ProductBL FromDTO(ProductDTO dto)
        {
            return new ProductBL
            {
                Name = dto.ProductName,
                Price = dto.Price,
                Description = dto.Description,
                Image = dto.ImagePath,
                DiscountText = dto.Discount,
                Address = dto.Address,
                id = dto.ProductID
            };
        }

        public ProductBL()
        {
            productDAL = new ProductDAL();
        }

        public List<ProductDTO> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }
        public ProductDTO GetProductCart(int id, int iduser)
        {
            try
            {
                return (new ProductDAL().getProductCart(id, iduser));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public ProductDTO GetProduct(int id)
        {
            try
            {
                return (new ProductDAL().getProduct(id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<ProductDTO> GetProducts_Seller(int id = 1)
        {
            try
            {
                return (new ProductDAL().getProduct_Seller(id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<ProductDTO> GetProducts_byCategorieID(int id = 1)
        {
            try
            {
                return (new ProductDAL().getProduct_byCategorieID(id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool save_product(string ProductName, decimal Price, string ImagePath, string Description, int CategoryID, string Address, int idseller)
        {
            try
            {
                return new ProductDAL().save_product(ProductName, Price, ImagePath, Description, CategoryID, Address, idseller);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<string> CategoryProduct()
        {
            try
            {
                return (new ProductDAL().CategoryProduct());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<ProductDTO> GetRandomProducts(int count)
        {
            ProductDAL productDAL = new ProductDAL();
            return productDAL.GetRandomProducts(count);
        }

        public bool edit_product(int idproduct, decimal price, string description, string address, int sl)
        {
            try
            {
                return productDAL.edit_product(idproduct, price, description, address, sl);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool remove_product(int id)
        {
            try
            {
                return (productDAL.removeProduct(id));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<string> GetProductSuggestions(string searchText) // lấy 10 sp
        {
            try
            {
                var suggestions = productDAL.GetProductNames(searchText)
                    .Take(10)
                    .ToList();

                System.Diagnostics.Debug.WriteLine($"BL returned {suggestions.Count} suggestions");
                return suggestions;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BL Error: {ex.Message}");
                throw;
            }
        }
        public ProductDTO GetProductDetails(string productName) // gợi ý truyền qua ItemDetail
        {
            return productDAL.GetProductByName(productName);
        }
        public List<ProductDTO> FilterProductsByDistrict(List<ProductDTO> products, HashSet<string> districts)
        {
            if (districts.Count == 0)
                return products;

            return products.Where(p => districts.Any(d =>
                p.Address != null && p.Address.Trim().Equals(d.Trim(), StringComparison.OrdinalIgnoreCase)
            )).ToList();
        }
        public List<ProductDTO> FilterProductsBySearch(List<ProductDTO> products, string searchQuery)
        {
            if (string.IsNullOrEmpty(searchQuery))
                return products;

            return products.Where(p =>
                p.ProductName.ToLower().Contains(searchQuery.ToLower()) ||
                p.Description.ToLower().Contains(searchQuery.ToLower())
            ).ToList();
        }
    }

}
