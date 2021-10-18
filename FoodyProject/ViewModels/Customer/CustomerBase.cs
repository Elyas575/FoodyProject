using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Customer
{
    public abstract class CustomerBase
    {
        [Required(ErrorMessage = "Customer's Name Field is Required.")]
        [StringLength(40, ErrorMessage = "Customer's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Customers's EmailAddress Field is Required.")]
        [StringLength(50, ErrorMessage = "Customer's {0} Field Can't Exceed {1} Characteers.")]
        [RegularExpression(@"^([\w_\-\.]+)@([\w_\-\.]+)\.(([\w]{2,4})+)", ErrorMessage = "You are Not Allowed to Use any Symbol Character Other Than These ( '.' , '-' , and '_')")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password Field is Required")]
        [MinLength(8, ErrorMessage = "Password Can't be less than 8 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        [StringLength(20, ErrorMessage = "Customer's {0} Number Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Customer's Phone Number Field is Required.")]
        public string Phone { get; set; }
    }
}
