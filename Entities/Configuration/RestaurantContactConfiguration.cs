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
    public class RestaurantContactConfiguration : IEntityTypeConfiguration<RestaurantContact>
    {
        public void Configure(EntityTypeBuilder<RestaurantContact> builder)
        {
            builder.HasData
            (
                 new RestaurantContact
                 {
                     RestaurantContactId = new Guid("76d6866e-2bb4-4f55-9729-9439bc0e26e3"),
                     PhoneNumber = 054823763,

                     RestaurantId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")                   
                 },
                    new RestaurantContact
                    {
                        RestaurantContactId = new Guid("4c827d94-25c2-4045-a223-c694891a75a6"),
                        PhoneNumber = 0538657659,

                        RestaurantId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")                       
                    }
            );
        }
    }
}
