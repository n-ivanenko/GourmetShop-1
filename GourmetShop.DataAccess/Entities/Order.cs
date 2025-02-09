using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// added Order Entity class -Nina (02/08)

namespace GourmetShop.DataAccess.Entities
{
    public class Order : ITable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

