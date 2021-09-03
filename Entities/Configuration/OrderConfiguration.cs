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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData
                (
                new Order
                {
                    OrderId = new Guid("7e712d90-6559-4fd2-bc73-6ed7eaa17ed7"),
                    MealId = new Guid("40ead250-3678-46c9-b733-1b9d79c43f0b"),
                    OrderDescription = "this is the order description",

                },

                new Order
                {
                    OrderId = new Guid("9598cc95-59c7-4105-9ec2-5b8cd5948c91"),
                    MealId = new Guid("80abbca8-664d-4b20-b5de-02470549654e"),
                    OrderDescription = "this is the order description",
                },

                new Order
                {
                    OrderId = new Guid("8889eaef-865d-4cc9-8e26-7dc408e86a2c"),
                    MealId = new Guid("80abbca8-664d-4b20-b5de-024705497d4e"),
                    OrderDescription = "this is the order description",
                }
                );
        }
    }
}
