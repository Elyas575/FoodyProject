using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Order
{
    public abstract class OrderBase
    {
        [Required(ErrorMessage = "Order's Status Field is Required.")]
        [StringLength(25, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string Status { get; set; }
    }
}
