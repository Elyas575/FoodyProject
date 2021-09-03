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
    public class CustomerContactConfiguration : IEntityTypeConfiguration<CustomerContact>
    {
        public void Configure(EntityTypeBuilder<CustomerContact> builder)
        {
            builder.HasData
            (
            new CustomerContact
            {
                CustomerContactId = new Guid("9562a45f-4413-43b2-a2c2-39ddfb2b45bc"),
                CustomerPhone = 0533654251,
                CustomerAddress = " Prime Living",
                CustomerId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
            },
            new CustomerContact
            {
                CustomerContactId = new Guid("ca023307-3d14-44aa-ab5a-8d0618495723"),
                CustomerPhone = 0566585452 ,
                CustomerAddress = "EMU Campus",
                CustomerId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),


            },
            new CustomerContact
            {
                CustomerContactId = new Guid(" fa47c6b3-1f89-43e7-9b5f-ca7543f88f49 "),
                CustomerPhone = 0566585452,
                CustomerAddress = "EMU Campus",
                CustomerId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
            }
            );
        }
    }
}

