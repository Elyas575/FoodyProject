﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantDto
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }    
        public string Password { get; set; }
        public string Address { get; set; }      
        public string Logo { get; set; }       
        public int AvgDeliveryTime { get; set; }       
        public float MinPrice { get; set; }
        public string Country { get; set; }      
        public string City { get; set; }    
        public string Street { get; set; }      
        public DateTime WorkingHours { get; set; }
        public bool Status { get; set; }
        public string Note { get; set; }
        public bool IsDelete { get; set; }
        public int Rate { get; set; }


    }
}