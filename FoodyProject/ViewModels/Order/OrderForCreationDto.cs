using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Order
{
    public class OrderForCreationDto : OrderBase
    {
        [Required(ErrorMessage = "Order's PaymentMethod Field is Required.")]
        [StringLength(50, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string PaymentMethod { get; set; }

        [StringLength(150, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string Description { get; set; }
    }
}