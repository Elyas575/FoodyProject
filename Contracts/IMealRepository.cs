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
        IEnumerable<Meal> GetAllMeals(Guid restaurantId, Guid categoryId, bool trackChanges);
        Meal GetMeal(Guid restaurantId, Guid categoryId, Guid mealId, bool trackChanges);

        void CreateMealForCategory(Guid categoryId, Meal meal);
        void DeleteMeal(Meal meal);
    }
}
