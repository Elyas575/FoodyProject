using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public  class OrderDto
    {
        public int OrderId { get; set; }
        public int MealId { get; set; }
         
        public int CustomerId { get; set; }

        public string OrderStatus { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime DelieveredTime { get; set; }

    


        [Required(ErrorMessage = "Order description is a required field")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Order description is 150 characters.")]
        public string OrderDescription { get; set; }

        [Required(ErrorMessage = "Order description is a required field")]
        [MaxLength(100, ErrorMessage = "Maximum length for the Order description is 100 characters.")]
        public string TypeOfPayment { get; set; }
        public bool IsDelivered { get; set; }

        public int RestaurantId { get; set; }
    }
}