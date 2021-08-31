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
                CustomerContactId = new Guid("80abbca8-664d-4b20-b5de-024735495l4s"),
                CustomerPhone = 0533654251,
                CustomerAddress = " Prime Living",
                CustomerId   = new Guid ("80abbca8-664d-4b20-b5de-024705497d4a "),



            },
            new CustomerContact
            {
                CustomerContactId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb25d"),
                CustomerPhone = 0566585452 ,
                CustomerAddress = "EMU Campus",
                CustomerId = new Guid ( "86dba8c0-5252-41e7-938c-ed49778fb52a"), 


            },
            new CustomerContact
            {
                CustomerContactId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                CustomerPhone = 0566585452,
                CustomerAddress = "EMU Campus",
                CustomerId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
            


            }
            );
        }
    }
}

