using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.CustomerContact
{
    public abstract class CustomerContactForManipulationDto
    {
        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Country is 50 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Country is 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Country is 50 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Country is 50 characters")]
        public string State { get; set; }
    }
}
