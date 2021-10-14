using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.RestaurantContact
{
    public abstract class RestaurantContactBase
    {
        [Phone]
        [StringLength(20, ErrorMessage = "Restaurant's {0} Number Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Restaurant's Phone Number Field is Required.")]
        public string Phone { get; set; }
    }
}
