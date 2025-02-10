using GourmetShop.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace GourmetShop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(string connectionString) : base(connectionString, "Product")
        {
            _getall = "GourmetShopGetAllProduct";
            _insert = "GourmetShopInsertProduct";
            _update = "GourmetShopUpdateProduct";
            _delete = "GourmetShopDeleteProduct";

        }

        public List<CustomerProduct> GetAllCurrent()
        {
            var results = new List<CustomerProduct>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GourmetShopGetAllCurrentProduct", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerProduct cprod = new CustomerProduct();
                            cprod.Id = reader.GetInt32(reader.GetOrdinal("ProductId"));
                            cprod.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            cprod.SupplierId = reader.GetInt32(reader.GetOrdinal("SupplierId"));
                            cprod.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                            cprod.Package = reader.GetString(reader.GetOrdinal("Package"));
                            cprod.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));

                            results.Add(cprod);
                        }
                    }
                }
            }
            return results;

        }
    }

 
}