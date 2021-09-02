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
<<<<<<< HEAD
=======

  


>>>>>>> dc07ab4fcb8ea4f3523fd2d15cd918233a278ec3
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
