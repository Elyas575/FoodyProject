using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.CustomerContact
{
    public abstract class CustomerContactBase
    {
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
    }
}
