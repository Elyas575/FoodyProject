﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.ViewModels.Meal
{
    public abstract class MealBase
    {
        [Required(ErrorMessage = "Meal's Name Field is Required")]
        [StringLength(40, ErrorMessage = "Meal's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        [StringLength(150, ErrorMessage = "Meal's {0} Field Can't Exceed {1} Characters.")]
        public string Description { get; set; }

        [StringLength(50, ErrorMessage = "Meal's {0} Field Can't Exceed {1} Characters.")]
        public string Option { get; set; }

        [Required(ErrorMessage = "Meal's Price Field is Required.")]
        [Column(TypeName = "decimal(18,2")]
        public decimal Price { get; set; }

        public string Picture { get; set; }
    }
}
