using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public  class Orders
    {
        [Column("OrderId")]

        public Guid Orderid { get; set; }

        public int  MaeilId { get; set; }


        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for Order Description is 200 characters.")] 
        public string OrederDescription { get; set; }


      
        public int MailId { get; set; }


        public int Ammount { get; set;  }


        public int TypeOfPayment { get; set;  }

        public int TimeOfDelivery { get; set; } 

        public string  Status { get; set; }
       














    }
}
