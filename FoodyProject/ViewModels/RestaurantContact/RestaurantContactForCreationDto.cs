using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantContactForCreationDto
    {

        [Required(ErrorMessage = "PhoneNumber is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the PhoneNumber is 60 characters.")]
        [Phone]
        public string PhoneNumber { get; set; }
    }
}