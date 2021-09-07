using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMealRepository
    {
        Task<IEnumerable<Meal>> GetAllMealsAsync(Guid restaurantId, Guid categoryId, bool trackChanges);
        Task<Meal> GetMealAsync(Guid restaurantId, Guid categoryId, Guid mealId, bool trackChanges);

        void CreateMealForCategory(Guid categoryId, Meal meal);
        void DeleteMeal(Meal meal);
    }
}
