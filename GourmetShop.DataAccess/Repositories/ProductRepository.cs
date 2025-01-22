using GourmetShop.DataAccess.Entities;
using System.Collections.Generic;

namespace GourmetShop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(string connectionString) : base(connectionString, "Product")
        {
        }
    }
}