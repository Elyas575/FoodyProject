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
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderedTime { get; set; }
        public DateTime DelieveredTime { get; set; }
        public string OrderDescription { get; set; }
        public string PaymentMethod { get; set; }
        public bool IsDelivered { get; set; }
    }
}