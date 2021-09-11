using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.Customer
{
    public abstract class CustomerForManipulationDto
    {
        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Address is 40 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Email is 30 characters.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "minimum length for password is 8 charchters ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
