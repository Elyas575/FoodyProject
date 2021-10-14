using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface IMealRepository
    {
        Task<PagedList<Meal>> GetAllMealsAsync(int restaurantId, int categoryId, MealParameters mealParameters, bool trackChanges);
        Task <Meal> GetMealAsync(int restaurantId, int categoryId, int mealId, bool trackChanges);
        void CreateMeal(int restaurantId, int categoryId, Meal meal);
        void DeleteMeal(Meal meal);
    }
}