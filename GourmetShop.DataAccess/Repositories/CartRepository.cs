using FastMember;
using GourmetShop.DataAccess.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Repositories
{
    public class CartRepository : Repository<Cart>
    {
        public CartRepository(string connectionString) : base(connectionString, "Cart")
        {
            _insert = "GourmetShopAddProductToCart";
            _delete = "GourmetShopDeleteCart";
        }

        public void Checkout(int id, int OrderNumber)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var comm = new SqlCommand("GourmetShopMakeOrder", connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    comm.Parameters.AddWithValue("CustId", id);
                    comm.Parameters.AddWithValue("OrderNumber", OrderNumber);

                    comm.ExecuteNonQuery();

                }

            }
        }

        public List<CustomerCart> GetMyCart(int id)
        {
            var results = new List<CustomerCart>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("GourmetShopGetMyCart", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerCart ccart = new CustomerCart();
                            ccart.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            ccart.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            ccart.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                            ccart.Package = reader.GetString(reader.GetOrdinal("Package"));
                            ccart.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                            ccart.Quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));
                            ccart.CustomerId = id;
                            ccart.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));


                            results.Add(ccart);
                        }
                    }
                }
            }
            return results;

        }

        public void UpdateCartQuantity(int id, int quantity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
               
                using (var comm = new SqlCommand("GourmetShopUpdateCart", connection))
                {
                    comm.CommandType = System.Data.CommandType.StoredProcedure;            
                    
                    comm.Parameters.AddWithValue("Id", id);
                    comm.Parameters.AddWithValue("Quantity", quantity);
               
                    comm.ExecuteNonQuery();

                }
                
            }
        }
    }
    
}
