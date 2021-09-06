using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantForUpdateDto
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        public string Logo { get; set; }
        public int AvgDeliveryTime { get; set; }
        public int MinPrice { get; set; }


        public IEnumerable<RestaurantContactForCreationDto> RestaurantContact { get; set; } 

    }
}
