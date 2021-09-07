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
       Task< IEnumerable<Meal>> GetAllMealsAsync(string restaurantId, string categoryId, bool trackChanges);
        Task <Meal> GetMealAsync(string restaurantId, string categoryId, string mealId, bool trackChanges);

        void CreateMealForCategory(string restaurantId, string categoryId, Meal meal);
        void DeleteMeal(Meal meal);
    }
}
