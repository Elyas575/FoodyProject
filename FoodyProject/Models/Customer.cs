using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FoodyProject.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Customer's Name Field is Required.")]
        [StringLength(40, ErrorMessage = "Customer's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customers's EmailAddress Field is Required.")]
        [StringLength(50, ErrorMessage = "Customer's {0} Field Can't Exceed {1} Characteers.")]
        [RegularExpression(@"^[\w\.\_\-]+@[\w.-]+\.[\w]{2,4}+", ErrorMessage = "Email Address should Follow These Rules:\n" +
            "---> Use Lower & Upper Case Letters, Digits, and (_ . -) Symbols Before '@' Character.\n" +
            "---> Use Lower & Upper Case Letters, Digits, and (-) Symbol Before '.' Character.\n" +
            "---> Use From 2 to 4 Characters, From Lower & Upper Case Letters, and Digits after '.' Character.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password Field is Required")]
        [MinLength(8, ErrorMessage = "Password Can't be less than 8 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        [StringLength(20, ErrorMessage = "Customer's {0} Number Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Customer's Phone Number Field is Required.")]
        public string Phone { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Employee's DOB Field is Required.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [ReadOnly(true)]
        public int Age { get; set; }

        public ICollection<CustomerContact> CustomerContacts { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}