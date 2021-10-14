using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Restaurant
{
    public class RestaurantForUpdateDto : RestaurantBase
    {
        [Required(ErrorMessage = "Password Field is Required")]
        [MinLength(8, ErrorMessage = "Password Can't be less than 8 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Country Field is Required.")]
        public string Country { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "City Field is Required.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Street Field is Required.")]
        public string Street { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Building Field is Required.")]
        public string Building { get; set; }

        [StringLength(30, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Latitude Field is Required.")]
        public string Latitude { get; set; }

        [StringLength(30, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Longitude Field is Required.")]
        public string Longitude { get; set; }

        public bool IsDelete { get; set; }
    }
}