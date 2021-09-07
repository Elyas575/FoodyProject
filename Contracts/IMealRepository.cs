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
        Task< IEnumerable<Meal>> GetAllMealsAsync(int restaurantId, int categoryId, bool trackChanges);
        Task <Meal> GetMealAsync(int restaurantId, int categoryId, int mealId, bool trackChanges);
        void CreateMealForCategory(int restaurantId, int categoryId,int orderId, Meal meal);
        void DeleteMeal(Meal meal);
    }
}