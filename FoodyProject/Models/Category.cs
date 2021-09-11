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
        [Required(ErrorMessage = "Order description is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Order description is 50 characters.")]
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurants { get; set; }     
        public virtual ICollection<Meal> Meals { get; set; }
    }
}