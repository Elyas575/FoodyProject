using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Customer
    {
        [Column("CustomerId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Coustomer  address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Customer Email is a required field")]
        [MaxLength(60, ErrorMessage = "Maximum length for Customer is 60 characters ")]

        public string Email { get; set; }

        [Required(ErrorMessage = "password is a required field ")]
        [MaxLength(60, ErrorMessage = "maximun length dor passwod is 60 charchters ")]

        public int  Password { get; set; }


       
    }
}
