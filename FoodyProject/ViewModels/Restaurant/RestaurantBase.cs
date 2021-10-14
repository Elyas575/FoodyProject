using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.ViewModels.Restaurant
{
    public abstract class RestaurantBase
    {
        [Required(ErrorMessage = "Restaurant's Name Field is Required.")]
        [StringLength(40, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant's EmailAddress Field is Required.")]
        [StringLength(50, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characteers.")]
        [RegularExpression(@"^[\w\.\_\-]+@[\w.-]+\.[\w]{2,4}+", ErrorMessage = "Email Address should Follow These Rules:\n" +
           "---> Use Lower & Upper Case Letters, Digits, and (_ . -) Symbols Before '@' Character.\n" +
           "---> Use Lower & Upper Case Letters, Digits, and (-) Symbol Before '.' Character.\n" +
           "---> Use From 2 to 4 Characters, From Lower & Upper Case Letters, and Digits after '.' Character.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Restaurant's Status Field is Required.")]
        [StringLength(25, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characters.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Resturant's AvgDeliveryTime Field is Required.")]
        [Range(typeof(int), "0", "21000", ErrorMessage = "Resturant's {0} Can't be less than {1}.")]
        public int AvgDeliveryTime { get; set; }

        [Required(ErrorMessage = "Restaurant's MinPrice Field is Required.")]
        [Column(TypeName = "decimal(18,2")]
        [Range(typeof(decimal), "0", "2000", ErrorMessage = "Restaurant's {0} Can't be less than {1}")]
        public decimal MinPrice { get; set; }

        public string Cuisine { get; set; }
        public string Logo { get; set; }
        public string Note { get; set; }
    }
}
