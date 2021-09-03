using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public  class OrderDto
    {
        public Guid OrderId { get; set; }

        public Guid MealId { get; set; }

        public string OrderDescription { get; set; }
    }
}
