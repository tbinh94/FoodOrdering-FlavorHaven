using Food_DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Food_DL
{

    public class ProductDAL : DataProvider
    {
        public List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                SqlCommand command = new SqlCommand("SELECT ProductID, ProductName, Price, Image, Address FROM Products", cn);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductDTO
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            ImagePath = reader.GetString(3),
                            Address = reader.GetString(4),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting products: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            return products;
        }
        public ProductDTO getProductCart(int id, int iduser)
        {
            string sql = "select p.* from Cart_Item c, Products p where c.UserID=" + iduser + " AND c.ProductID =" + id + " AND p.ProductID=c.ProductID";
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                if (reader.Read())
                    return new ProductDTO
                    {
                        ProductID = int.Parse(reader[0].ToString()),
                        ProductName = reader[1].ToString(),
                        Price = decimal.Parse(reader[2].ToString()),
                        Description = reader[3].ToString(),
                        CategoryID = int.Parse(reader[4].ToString()),
                        ImagePath = reader[5].ToString(),
                        Address = reader[6].ToString(),
                        SellerID = int.Parse(reader[7].ToString()),
                        Inventory = int.Parse(reader[8].ToString())
                    };
                else
                    return null;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { Disconnect(); }
        }

        public ProductDTO getProduct(int id)
        {
            string sql = "select * from Products where ProductID =" + id;
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                if (reader.Read())
                    return new ProductDTO
                    {
                        ProductID = int.Parse(reader[0].ToString()),
                        ProductName = reader[1].ToString(),
                        Price = decimal.Parse(reader[2].ToString()),
                        Description = reader[3].ToString(),
                        ImagePath = reader[5].ToString(),
                        Address = reader[6].ToString(),
                        SellerID = int.Parse(reader[7].ToString()),
                        Inventory = int.Parse(reader[8].ToString())
                    };
                else
                    return null;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { Disconnect(); }
        }
        public List<ProductDTO> getProduct_Seller(int id)
        {

            string sql = "select * from Products p where SellerID='" + id + "'";
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    list.Add(new ProductDTO
                    {
                        ProductID = int.Parse(reader[0].ToString()),
                        ProductName = reader[1].ToString(),
                        Price = decimal.Parse(reader[2].ToString()),
                        Description = reader[3].ToString(),
                        ImagePath = reader[5].ToString(),
                        Address = reader[6].ToString()
                    });
                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { Disconnect(); }
        }
        public List<ProductDTO> getProduct_byCategorieID(int id)
        {

            string sql = "select p.* from Categories c, Products p where c.CategoryID = p.CategoryID AND c.CategoryID =" + id;
            List<ProductDTO> list = new List<ProductDTO>();
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    list.Add(new ProductDTO
                    {
                        ProductID = int.Parse(reader[0].ToString()),
                        ProductName = reader[1].ToString(),
                        Price = decimal.Parse(reader[2].ToString()),
                        Description = reader[3].ToString(),
                        ImagePath = reader[5].ToString(),
                        Address = reader[6].ToString()
                    });
                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { Disconnect(); }
        }

        public bool save_product(string ProductName, decimal Price, string ImagePath, string Description, int CategoryID, string Address, int idseller)
        {
            string sql = $"INSERT INTO Products (ProductName, Price, Image, Description,CategoryID,Address, SellerID,Inventory) " +
                         "VALUES (@ProductName, @Price, @ImagePath, @Description,@CategoryID,@Address, @SellerID,0)";

            Dictionary<string, object> parameters = new Dictionary<string, object>
                {
                    { "@ProductName", ProductName },
                    { "@Price", Price },
                    { "@ImagePath",ImagePath },
                    { "@Description", Description },
                    { "@CategoryID", CategoryID },
                    { "@Address", Address },
                    { "@SellerID", idseller }
                };

            try
            {
                MyExecuteNonQuery(sql, parameters);
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<string> CategoryProduct()
        {
            string sql = "select * from Categories";
            List<string> list = new List<string>();
            try
            {
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    list.Add(reader.GetString(1));
                }
                return list;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally { Disconnect(); }
        }

        public List<ProductDTO> GetRandomProducts(int count)
        {
            string query = "SELECT TOP (@count) * FROM Products ORDER BY NEWID()"; // SQL Server hỗ trợ NEWID() để lấy ngẫu nhiên
            List<ProductDTO> products = new List<ProductDTO>();

            using (cn)
            {
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@count", count);

                cn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ProductDTO product = new ProductDTO
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Price = reader.GetDecimal(2)
                    };

                    products.Add(product);
                }
            }
            return products;
        }
        public bool edit_product(int idproduct, decimal price, string description, string address, int sl)
        {
            try
            {
                using (cn)
                {
                    cn.Open();
                    string query = $"UPDATE Products SET Price = @Price,Description = @Description, Address=@Address,Inventory = @Inventory WHERE ProductID = @ProductID";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@Inventory", sl);
                        cmd.Parameters.AddWithValue("ProductID", idproduct);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool removeProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductID = " + id;
            try
            {
                MyExecuteNonQuery(sql);
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                Disconnect();
            }
        }

        public List<string> GetProductNames(string searchText)
        {
            List<string> productNames = new List<string>();

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                string query = "SELECT DISTINCT ProductName FROM Products WHERE ProductName LIKE @searchText";
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        productNames.Add(name);
                        System.Diagnostics.Debug.WriteLine($"DAL found product: {name}");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"DAL Error: {ex.Message}");
                throw;
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }

            System.Diagnostics.Debug.WriteLine($"DAL returned {productNames.Count} products");
            return productNames;
        } // để gợi ý
        public ProductDTO GetProductByName(string productName) // để lấy truyền qua itemdetail
        {
            ProductDTO product = null;
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                string query = "SELECT ProductID, ProductName, Price, Image, Address FROM Products WHERE ProductName = @productName";
                SqlCommand command = new SqlCommand(query, cn);
                command.Parameters.AddWithValue("@productName", productName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        product = new ProductDTO
                        {
                            ProductID = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            ImagePath = reader.GetString(3),
                            Address = reader.GetString(4)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting product details: " + ex.Message);
            }
            finally
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            return product;
        }

    }


}