namespace FoodyProject.ViewModels.Meal
{
    public class MealDto : MealBase
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public bool IsAvailabe { get; set; }
    }
}
