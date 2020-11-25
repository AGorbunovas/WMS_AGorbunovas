using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WMS_AGorbunovas.Models
{
    public class LoyaltyType
    {
        [Key]
        public int TypeId { get; set; }
        public string LoyaltyName { get; set; }
    }
}
