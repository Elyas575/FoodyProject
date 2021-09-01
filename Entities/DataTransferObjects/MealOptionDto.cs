using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class MealOptionDto
    {
        public Guid MealOptionId { get; set; }
        public string MealSize { get; set; }
        public string Extra { get; set; }
    }
}
