﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
  public  class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int RestaurantId { get; set; }
        public bool IsDelete { get; set; }
    }
}