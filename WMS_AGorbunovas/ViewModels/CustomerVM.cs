using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WMS_AGorbunovas.Models;

namespace WMS_AGorbunovas.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }

        [Display(Name = "Vardas")]
        [Required(ErrorMessage = "Įveskite vardą")]
        [StringLength(20, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} ir ne ilgesnis nei {1} simbolių.", MinimumLength = 4)]
        [RegularExpression("[^0-9]+$", ErrorMessage = "Naudokite tik raides")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Įveskite pavardę")]
        [Display(Name = "Pavardė")]
        [RegularExpression("[^0-9]+$", ErrorMessage = "Pavardei naudokite tik raides")]
        [StringLength(30, ErrorMessage = "{0} turi būti ne trumpesnis nei {2} ir ne ilgesnis {1} simbolių.", MinimumLength = 4)]
        public string LastName { get; set; }
               
        [DataType(DataType.Date)]
        [Display(Name = "Gimimo data")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Įveskite telefono numerį")]
        [Display(Name = "Telefonas")]
        [RegularExpression(@"^[8][6]\d{7}$", ErrorMessage = "Įveskite telefono numerį formatu 86xxxxxxx")]
        public int? PhoneNumber { get; set; }
        public List<Customer> Customer { get; set; }

        [Display(Name = "Lojalumo grupė")]
        public List<LoyaltyType> LoyaltyTypeList { get; set; } = new List<LoyaltyType>();
        public List<SelectListItem> LoyaltyTypes { get; set; }
        [Required(ErrorMessage = "Pasirinkite lojalumo grupę")]
        public string[] LoyaltyTypeName { get; set; }
    }
}
