using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entities.Models
{
   public class RestaurantContact
    {
        public int RestaurantContactId { get; set; }
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "PhoneNumber is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the PhoneNumber is 60 characters.")]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
    }
}