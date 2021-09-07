
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositoy
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task <IEnumerable<Meal> >GetAllMealsAsync(int restaurantId, int categoryId, bool trackChanges) =>
             await FindAll(trackChanges)
            .OrderBy(c => c.Name)
            .ToListAsync();

        public async Task <Meal> GetMealAsync(int restaurantId, int categoryId, int mealId, bool trackChanges) =>
             await FindByCondition(e => e.CategoryId.Equals(categoryId) && e.MealId.Equals(mealId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateMealForCategory(int restaurantId, int categoryId, int orderId, Meal meal)
        {
            meal.CategoryId = categoryId;
            Create(meal);
        }

        public void DeleteMeal(Meal meal)
        {
            Delete(meal);

        }
    }
}