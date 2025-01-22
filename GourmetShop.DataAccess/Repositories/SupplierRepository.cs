using GourmetShop.DataAccess.Entities;
using System.Collections.Generic;

namespace GourmetShop.DataAccess.Repositories
{
    public class SupplierRepository : Repository<Supplier>
    {
        public SupplierRepository(string connectionString) : base(connectionString, "Supplier")
        {
        }
    }
}