using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WMS_AGorbunovas.Models
{   
    public class CustomerType
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [ForeignKey("LoyaltyType")]
        public int TypeId { get; set; }
        public LoyaltyType LoyaltyType { get; set; }
    }
}
