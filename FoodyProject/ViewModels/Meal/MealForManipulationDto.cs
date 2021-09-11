using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.Meal
{
    public abstract class MealForManipulationDto
    {
        [Required(ErrorMessage = "Meal name is a required field.")]
        [MaxLength(30, ErrorMessage = "Max length for meal name is 30 characters.")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Max length for meal description is 150 characters.")]
        public string Description { get; set; }

        [MaxLength(50, ErrorMessage = "Max length for meal options is 50 characters.")]
        public string MealOptions { get; set; }

        [Range(0.1, float.MaxValue, ErrorMessage = "Price is required and it can't be lower than 0.1")]
        public float Price { get; set; }

        public string Picture { get; set; }
    }
}
