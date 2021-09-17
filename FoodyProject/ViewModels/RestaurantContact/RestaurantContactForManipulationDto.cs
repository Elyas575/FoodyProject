using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.RestaurantContact
{
    public abstract class RestaurantContactForManipulationDto
    {
        [Phone]
        [Required(ErrorMessage = "PhoneNumber is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum length for the PhoneNumber is 15 characters.")]
        public string PhoneNumber { get; set; }
    }
}
