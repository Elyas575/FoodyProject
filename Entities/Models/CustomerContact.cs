using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class CustomerContact
    {
        [Column("CustomerContactId")]
        public Guid CustomerContactId { get; set; }

        [Required(ErrorMessage = "CustomerAddress is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the CustomerAddress is 60 characters.")]
        public string CustomerAddress { get; set; }

        public int RestaurantContactId { get; set; }


    }
}
