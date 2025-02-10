using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GourmetShop.DataAccess.Entities
{
    public class CustomerCart : Cart
    {
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string Package { get; set; }
    }
}
