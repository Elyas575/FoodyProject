using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
  public  class MealOption
    {
        public int MealOptId { get; set; }
        [Required]
        public int MealSize { get; set; }

    }
}
