using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WMS_AGorbunovas.Models
{   
    public class CustomerType
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int TypeId { get; set; }
        public LoyaltyType LoyaltyType { get; set; }
    }
}
