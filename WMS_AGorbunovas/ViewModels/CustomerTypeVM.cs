using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS_AGorbunovas.Models;

namespace WMS_AGorbunovas.ViewModels
{
    public class CustomerTypeVM
    {
        public CustomerType CustomerType { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<CustomerType> CustomerTypeList { get; set; }
        public IEnumerable<SelectListItem> LoyaltyTypeList { get; set; }
    }
}
