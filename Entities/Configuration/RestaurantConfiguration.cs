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
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData
            (
                 new Restaurant
                 {
                     RestaurantId = new Guid("7e712d21-6559-4fd2-bc73-6ed7eaa17ed7"),
                     Name = "Ekor",
                     Email = "ekor@gmail.com",
                     Password = "11223344",
                     Address = "Famagusta/ EMU",
                     Logo = "This is Ekor's logo",
                     AvgDeliveryTime = 35,
                     MinPrice = 30
                 },
                    new Restaurant
                    {
                        RestaurantId = new Guid("7e712d90-6559-4fd2-bc73-6ed7eaa17ea3"),
                        Name = "Burger Point",
                        Email = "burgerpoint@gmail.com",
                        Password = "55667788",
                        Address = "Famagusta/ Kaliland",
                        Logo = "This is Burgur point's logo",
                        AvgDeliveryTime = 40,
                        MinPrice = 50
                    }
            );
        }
    }
}
