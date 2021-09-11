﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
   public class MealDto
    {
        public int MealId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MealOptions { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public bool IsDelete { get; set; }
        public bool IsAvailabe { get; set; }
    }
}
