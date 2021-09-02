using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
  public  class MealOption
    {
        
       [Key]
        public Guid MealOptionId { get; set; }
        public string MealSize { get; set; }
        public Guid OrderId { get; set; }
        public string Extra { get; set; }

        [ForeignKey(nameof(Meal))]
        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
    }
}
