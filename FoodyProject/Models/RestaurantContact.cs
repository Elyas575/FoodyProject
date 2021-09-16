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
        [Key]
        public int RestaurantContactId { get; set; }
        public int RestaurantId { get; set; }

        [Phone]
        [Required(ErrorMessage = "PhoneNumber is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum length for the PhoneNumber is 15 characters.")]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
    }
}