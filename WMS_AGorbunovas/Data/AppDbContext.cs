using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WMS_AGorbunovas.Models;

namespace WMS_AGorbunovas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoyaltyType> LoyaltyTypes { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<CustomerType>().ToTable("CustomerType");
            modelBuilder.Entity<LoyaltyType>().ToTable("LoyaltyType");


            modelBuilder.Entity<CustomerType>()
                .HasKey(customerType => new { customerType.CustomerId, customerType.TypeId});
        }

    }
}
