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

        [Required(ErrorMessage = "Category name is a required field.")]
        [MaxLength(30, ErrorMessage = "Max length for category name is 30 characters.")]
        public string CategoryName { get; set; }

        public int RestaurantId { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurants { get; set; }     
        public virtual ICollection<Meal> Meals { get; set; }
    }
}