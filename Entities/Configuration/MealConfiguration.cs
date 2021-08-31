using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MealConfiguration : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            builder.HasData
            (
            new Meal
            {
                MealId = new Guid("8"),
                Name = "Chicken fried rice",
                Description = "Chicken fried rice with chicken",
                Price = 48,
                Picture = "Logo",

            },
            new Meal
            {
                MealId = new Guid("6"),
                Name = "Menu burger",
                Description = "Chicken burger",
                Price = 45,
                Picture = "Logo",

            },
            new Meal
            {
                MealId = new Guid("7"),
                Name = "Pizza",
                Description = "BBQ pizza",
                Price = 58,
                Picture = "Logo",
            }
            );
        }
    }
}