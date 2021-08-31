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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData
            (
            new Customer
            {
                CustomerId = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "Duja",
                Email = "dojashelabyh@gmail.com",
                Password = "1223344",


            },
            new Customer
            {
                CustomerId = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                Name = "Tameem foody",
                Email = "tameem@gmail.com",
                Password = "123456789",

            },
            new Customer
            {
                CustomerId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Name = "farhad foody",
                Email = "farhad@gmail.com",
                Password = "147852369",

            }
            );
        }
    }
}