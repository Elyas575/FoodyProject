using FoodyProject.ViewModels.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantForUpdateDto : RestaurantForManipulationDto
    {
        public bool IsDelete { get; set; }
    }
}