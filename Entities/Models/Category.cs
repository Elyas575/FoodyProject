using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
       [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string RestaurantId { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public virtual Restaurant Restaurants { get; set; }     
        public virtual ICollection<Meal> Meals { get; set; }
        

    }
}
