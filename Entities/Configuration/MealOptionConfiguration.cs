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
    public class MealOptionConfiguration : IEntityTypeConfiguration<MealOption>
    {
        public void Configure(EntityTypeBuilder<MealOption> builder)
        {
            builder.HasData
                (

                new MealOption
                {
                    MealOptionId = new Guid("80abbca8-664d-4b20-b5de-024705492d4a"),
                    MealSize = "big",
                    Extra = "salad",
                },

                new MealOption
                {
                    MealOptionId = new Guid("80abbca8-645d-4b20-b5de-024705490d4a"),
                    MealSize = "small",
                    Extra = "french fries",
                },

                new MealOption
                {
                    MealOptionId = new Guid("80abbca8-664d-4b20-b5de-024705447d4a"),
                    MealSize = "medium",
                    Extra = "mushroom",
                }




                );
        }
    }
}
