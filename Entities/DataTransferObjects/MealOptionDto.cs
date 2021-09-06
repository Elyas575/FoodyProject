using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{ /* we arent using this anymore its inside the meal table */
   public class MealOptionDto
    {
   
        public Guid MealOptionId { get; set; }
        public string MealSize { get; set; }
        public string Extra { get; set; }
    }
}
