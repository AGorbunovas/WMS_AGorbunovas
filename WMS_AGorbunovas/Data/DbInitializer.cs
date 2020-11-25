﻿using System;
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
                     },
                      new Customer
                     {
                         FirstName = "Tomas",
                         LastName = "Tomašauskas",
                         BirthDate = DateTime.Parse("1965-10-20"),
                         PhoneNumber = 862365487
                     },
                       new Customer
                     {
                         FirstName = "Laura",
                         LastName = "Lokatienė",
                         BirthDate = DateTime.Parse("1974-01-02"),
                         PhoneNumber = 863645897
                     },
                        new Customer
                     {
                         FirstName = "Simona",
                         LastName = "Butautė",
                         BirthDate = DateTime.Parse("1999-12-16"),
                         PhoneNumber = 863525987
                     }
                 };
            foreach (Customer customer in customers)
            {
                context.Customer.Add(customer);
            }
            context.SaveChanges();

            var loyalties = new LoyaltyType[]
                {
                    new LoyaltyType
                    {
                        LoyaltyName = "Įprastas"
                    },
                    new LoyaltyType
                    {
                        LoyaltyName = "Lojalus klientas"
                    }
                };
            foreach (LoyaltyType loyaltyType in loyalties)
            {
                context.LoyaltyType.Add(loyaltyType);
            }
            context.SaveChanges();
        }
    }
}
