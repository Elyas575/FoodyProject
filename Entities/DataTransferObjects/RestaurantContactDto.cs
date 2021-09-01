using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    class RestaurantContactDto
    {
        public Guid RestaurantContactId { get; set; }
        public int PhoneNumber { get; set; }
    }
}
