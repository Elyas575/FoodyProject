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
                CategoryId =  new Guid("1"),
            },
            new Category
            {
                CategoryName = "Pizza",
                CategoryId = new Guid("2"),

            },
            new Category
            {
                CategoryName = "Drinks",
                CategoryId = new Guid("3"),

            },
            new Category
                {
                    CategoryName = "Doner",
                    CategoryId = new Guid("4"),

                }
            );
        }
    }
}
