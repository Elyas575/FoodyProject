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
        [Key]
        public int  CustomerContactId { get; set; }
        public string CustomerAddress { get; set; }
        public int CustomerId { get; set; }

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

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}