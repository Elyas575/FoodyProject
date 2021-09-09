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
        [Key]
        public int  CustomerContactId { get; set; }
        
        public string CustomerAddress { get; set; }
        
        public int CustomerId { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Area { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}