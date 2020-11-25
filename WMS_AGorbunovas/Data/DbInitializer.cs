using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WMS_AGorbunovas.Models;

namespace WMS_AGorbunovas.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customer.Any())
            {
                return;
            }

            var customers = new Customer[]
                 {
                     new Customer
                     {
                         FirstName = "Kaulas",
                         LastName = "Kaulevičius",
                         BirthDate = DateTime.Parse("1980-08-10"),
                         PhoneNumber = 865264526
                     }
                 };
            foreach (Customer customer in customers)
            {
                context.Customer.Add(customer);
            }
            context.SaveChanges();
        }
    }
}
