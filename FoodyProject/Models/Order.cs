using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime DelieveredTime { get; set; }

        [Required(ErrorMessage = "Payment method is a required field")]
        [MaxLength(50, ErrorMessage = "Maximum length for the payment method is 50 characters.")]
        public string PaymentMethod { get; set; }

        [MaxLength(150, ErrorMessage = "Maximum length for the Order description is 150 characters.")]
        public string OrderDescription { get; set; }

        public bool IsDelivered { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurants { get; set; }
        
        public virtual ICollection<Meal> Meals { get; set; }
    }
}