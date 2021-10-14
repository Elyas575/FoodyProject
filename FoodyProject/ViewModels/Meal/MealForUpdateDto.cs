namespace FoodyProject.ViewModels.Meal
{
    public class MealForUpdateDto : MealBase
    {
        public bool IsDelete { get; set; }
        public bool IsAvailabe { get; set; }
    }
}