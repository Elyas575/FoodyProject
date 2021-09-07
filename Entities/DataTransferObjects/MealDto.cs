using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class MealDto
    {
        public Guid MealId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string MealOptions { get; set; }


        public int Price { get; set; }
        public string Picture { get; set; }
    }
}
