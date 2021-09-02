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
                MealId = new Guid("40ead250-3678-46c9-b733-1b9d79c43f0b"),
                Name = "Chicken fried rice",
                Description = "Chicken fried rice with chicken",
                Price = 48,
                Picture = "Logo",

            },
            new Meal
            {
                MealId = new Guid("80abbca8-664d-4b20-b5de-02470549654e"),
                Name = "Menu burger",
                Description = "Chicken burger",
                Price = 45,
                Picture = "Logo",

            },
            new Meal
            {
                MealId = new Guid("80abbca8-664d-4b20-b5de-024705497d4e"),
                Name = "Pizza",
                Description = "BBQ pizza",
                Price = 58,
                Picture = "Logo",
            }
            );
        }
    }
}