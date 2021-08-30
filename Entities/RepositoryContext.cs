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
        public DbSet<Restaurant> resturants { get; set; }
        public DbSet<Customer> customers { get; set; }

        public DbSet<CustomerContact> customerContacts { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealOption> mealOptions { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<RestaurantContact> RestaurantContacts { get; set; }

        public DbSet<Category> categories { get; set; }
    }

}
