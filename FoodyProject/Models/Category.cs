using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category's Name Field is Required.")]
        [StringLength(30, ErrorMessage = "Category's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        public int RestaurantId { get; set; }
        public bool IsDelete { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurants { get; set; }     
        
        public virtual ICollection<Meal> Meals { get; set; }
    }
}