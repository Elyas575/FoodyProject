using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class Order
    {
        [Column("OrderId")]

        public Guid Orderid { get; set; }

        public int  MaeilId { get; set; }


        public string OrederDescription { get; set; }


      
        public int MailId { get; set; }


        public int Ammount { get; set;  }


        public int TypeOfPayment { get; set;  }

        public int TimeOfDelivery { get; set; } 

        public string  Status { get; set; }
       














    }
}
