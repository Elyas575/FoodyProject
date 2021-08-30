using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class CustomerContact
    {
        public Guid CustomerContactId { get; set; }
        [Required(ErrorMessage = "Phone number should be added")]

        public string CustomerAddress { get; set; }


        public int ResturantContactId { get; set; }


    }
}
