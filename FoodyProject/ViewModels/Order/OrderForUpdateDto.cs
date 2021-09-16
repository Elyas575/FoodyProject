using FoodyProject.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class OrderForUpdateDto : OrderForMaipulationDto
    {
        public string OrderStatus { get; set; }
        public bool IsDelivered { get; set; }
    }
}