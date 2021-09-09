using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class CustomerContactForCreationDto
    {
        public string CustomerAddress { get; set; }
        public int CustomerPhone { get; set; }
    }
}