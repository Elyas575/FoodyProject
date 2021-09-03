using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantContactForCreationDto
    {
        public string PhoneNumber { get; set; }
        public Guid RestaurantContactId { get; set; }


    }
}
