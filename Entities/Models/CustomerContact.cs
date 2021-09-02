using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class CustomerContact
    {
        
        public Guid CustomerContactId { get; set; }
        public string CustomerAddress { get; set; }

        public int CustomerPhone { get; set;  }


        [ForeignKey(nameof(Customer))]
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }



    }
}
