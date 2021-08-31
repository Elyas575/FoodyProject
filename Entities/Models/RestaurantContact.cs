using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class RestaurantContact
    {
        
        public Guid ResturantContactId { get; set; }
        [Required(ErrorMessage ="Phone number should be added")]
        public int PhoneNumber { get; set; }
        public int RestaurantId { get; set; }

        TestingThebranch

    }
}
