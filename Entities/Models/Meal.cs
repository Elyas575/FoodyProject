using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Meal
    {
        
        public Guid MealId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string MealOptions { get; set; }
     
        public int Price { get; set; }
        public string Picture { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey(nameof(Order))]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
   
    }
}
