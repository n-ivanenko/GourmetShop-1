using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using GourmetShop.DataAccess.Entities;

// added OrderRepository -Nina (02/08)

namespace GourmetShop.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(string connectionString) : base(connectionString, "Order")
        {
            _insert = "GourmetShopInsertOrder";
            _getone = "GourmetShopGetOrderById";
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var comm = new SqlCommand("GourmetShopGetAllOrders", connection))
                {
                    comm.CommandType = CommandType.StoredProcedure; 

                    using (var reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                                OrderNumber = reader.GetString(reader.GetOrdinal("OrderNumber")),
                                CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                            });
                        }
                    }
                }
            }

            return orders;
        }
    }
}
