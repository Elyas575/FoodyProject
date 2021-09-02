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
  public  class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
            new Category
            {
                CategoryName = "Burger",
                CategoryId =  new Guid("4cbd7f6e-004d-4710-ab81-01ba2674ad76"),
                RestaurantId = new Guid("7e712d21-6559-4fd2-bc73-6ed7eaa17ed7"),
            },
            new Category
            {
                CategoryName = "Pizza",
                CategoryId = new Guid("fed47027-a32a-418c-84cc-a09e338d86fd"),
                RestaurantId = new Guid("7e712d21-6559-4fd2-bc73-6ed7eaa17ed7"),
            },
            new Category
            {
                CategoryName = "Drinks",
                CategoryId = new Guid("febb74f3-e934-44d8-b276-634940fceef8"),
                RestaurantId = new Guid("7e712d90-6559-4fd2-bc73-6ed7eaa17ea3"),

            },
            new Category
                {
                    CategoryName = "Doner",
                    CategoryId = new Guid("c8d868ee-b938-4737-aa25-002fdaae1d07"),
                     RestaurantId = new Guid("7e712d90-6559-4fd2-bc73-6ed7eaa17ea3"),
                }
            );
        }
    }
}
