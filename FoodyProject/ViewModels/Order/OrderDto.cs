using System;

namespace FoodyProject.ViewModels.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public double Rate { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime DelieveredTime { get; set; }
        public DateTime TimeOfDelivery { get; set; }
        public string Description { get; set; }
        public string PaymentMethod { get; set; }
    }
}