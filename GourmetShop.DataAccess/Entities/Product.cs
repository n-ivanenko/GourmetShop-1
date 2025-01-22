using System;

namespace GourmetShop.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public Boolean IsDiscontinued { get; set; }
    }
}