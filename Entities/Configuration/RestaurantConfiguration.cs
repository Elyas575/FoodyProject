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
                     RestaurantId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
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
                        RestaurantId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
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
