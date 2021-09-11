using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.CustomerContact
{
    public abstract class CustomerContactForManipulationDto
    {
        [Required(ErrorMessage = "Country is a required field.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City is a required field.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Street is a required field.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "State is a required field.")]
        public string State { get; set; }
    }
}
