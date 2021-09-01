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
                    OrderId = new Guid("80ajuca8-664d-5b20-b5de-024985497d4a"),
                    MealId = new Guid(""),
                    OrderDescription = "this is the order description",

                },

                new Order
                {
                    OrderId = new Guid("80ajuca8-664d-5b20-b5de-024985497d4a"),
                    MealId = new Guid(),
                    OrderDescription = "this is the order description",
                },

                new Order
                {
                    OrderId = new Guid("80apjca8-664d-5b20-b5de-024987697d4b"),
                    MealId = new Guid(),
                    OrderDescription = "this is the order description",
                }





                );
        }
    }
}
