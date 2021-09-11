using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class OrderForCreationDto
    {

        [Required(ErrorMessage = "Order description is a required field")]
        [MaxLength(80, ErrorMessage = "Maximum length for the Order description is 80 characters.")]
        public string TypeOfPayment { get; set; }


        [Required(ErrorMessage = "Order description is a required field")]
        [MaxLength(150, ErrorMessage = "Maximum length for the Order description is 150 characters.")]
        public string OrderDescription { get; set; }
    }
}