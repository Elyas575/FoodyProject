using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class MealOptionConfiguration : IEntityTypeConfiguration<MealOption>
    {
        public void Configure(EntityTypeBuilder<MealOption> builder)
        {
            builder.HasData
                (

                new MealOption
                {
                    MealId = new Guid("40ead250-3678-46c9-b733-1b9d79c43f0b"),
                    MealOptionId = new Guid("56aadd32-5401-4087-a7ca-7123af7fe4a9"),
                    MealSize = "big",
                    Extra = "salad",
                    OrderId = new Guid("7e712d90-6559-4fd2-bc73-6ed7eaa17ed7"),
                },

                new MealOption
                {
                    MealId = new Guid("80abbca8-664d-4b20-b5de-02470549654e"),
                    MealOptionId = new Guid("be79e424-e4f3-4b1c-a7e7-e56fe9471519"),
                    MealSize = "small",
                    Extra = "french fries",
                    OrderId = new Guid("9598cc95-59c7-4105-9ec2-5b8cd5948c91"),
                },
                    
                new MealOption
                {
                    MealId = new Guid("80abbca8-664d-4b20-b5de-024705497d4e"),

                    MealOptionId = new Guid("b5e44230-8719-441e-8575-6395b95c5190"),
                    MealSize = "medium",
                    Extra = "mushroom",
                    OrderId = new Guid("8889eaef-865d-4cc9-8e26-7dc408e86a2c"),
                } );
        }
    }
}
