using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities 
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerContactConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new MealOptionConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantContactConfiguration());

        }


        public DbSet<Restaurant> Resturants { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<CustomerContact> CustomerContacts { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealOption> MealOptions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<RestaurantContact> RestaurantContacts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }

}
