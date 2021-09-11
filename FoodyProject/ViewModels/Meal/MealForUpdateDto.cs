using FoodyProject.ViewModels.Meal;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class MealForUpdateDto : MealForManipulationDto
    {
        public bool IsDelete { get; set; }
        public bool IsAvailabe { get; set; }
    }
}