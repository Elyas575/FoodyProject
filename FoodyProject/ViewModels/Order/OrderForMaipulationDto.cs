using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ViewModels.Order
{
    public abstract class OrderForMaipulationDto
    {
        [Required(ErrorMessage = "Payment method is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the payment method is 50 characters.")]
        public string PaymentMethod { get; set; }

        [MaxLength(150, ErrorMessage = "Maximum length for the Order description is 150 characters.")]
        public string OrderDescription { get; set; }
    }
}
