
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

        public async Task<IEnumerable<Meal>> GetAllMealsAsync(Guid restaurantId, Guid categoryId, bool trackChanges) =>
              await FindAll(trackChanges)
               .OrderBy(c => c.Name)
               .ToListAsync();

        public async Task<Meal> GetMealAsync(Guid restaurantId, Guid categoryId, Guid mealId, bool trackChanges) =>
            await FindByCondition(m => m.CategoryId.Equals(categoryId) && m.MealId.Equals(mealId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateMealForCategory(Guid categoryId, Meal meal)
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