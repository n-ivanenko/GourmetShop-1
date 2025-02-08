using GourmetShop.DataAccess.Entities;
using System;
using System.Collections.Generic;
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
        }
    }
}
