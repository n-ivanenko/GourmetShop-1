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
            _getall = "GourmetShopGetAllOrders";
        }
    }
}
