using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Order
    {
       
        

        
        public Guid OrderId { get; set; }

        public int  MealId { get; set; }
        
        public string OrderDescription { get; set; }

        public ICollection<Meal> Meals { get; set; }

        public ICollection<MealOption> MealOptions { get; set; }

        public virtual Customer Customer   { get; set; }
           





    }
}
