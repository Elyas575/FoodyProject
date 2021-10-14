using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order's Status Field is Required.")]
        [StringLength(25, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string Status { get; set; }

        [ReadOnly(true)]
        public DateTime OrderedTime = DateTime.Now;

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{MM/dd/yyyy hh:mm:ss tt}", ApplyFormatInEditMode = true)]
        //public DateTime DeliveredTime { get; set; }
        [ReadOnly(true)]
        public DateTime DeliveredTime => Status == "Delivered" ? DateTime.Now : DateTime.MinValue;

        [ReadOnly(true)]
        public TimeSpan TimeOfDelivery => Status == "Delivered" ? DeliveredTime.Subtract(OrderedTime) : TimeSpan.Zero;

        public double Rate { get; set; }

        [Required(ErrorMessage = "Order's PaymentMethod Field is Required.")]
        [StringLength(50, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string PaymentMethod { get; set; }

        [StringLength(150, ErrorMessage = "Order's {0} Field Can't Exceed {1} Characters.")]
        public string Description { get; set; }

        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customer { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurants { get; set; }
        
        public virtual ICollection<Meal> Meals { get; set; }
    }
}