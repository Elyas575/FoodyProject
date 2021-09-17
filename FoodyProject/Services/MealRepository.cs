
using Contracts;
using Entities;
using Entities.Models;
using FoodyProject.Models;
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

        public async Task <PagedList<Meal> >GetAllMealsAsync(int restaurantId, int categoryId, MealParameters mealParameters, bool trackChanges)
        {
            var meal = await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Skip((mealParameters.PageNumber - 1) * mealParameters.PageSize)
                .Take(mealParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Meal>(meal, mealParameters.PageNumber, mealParameters.PageSize, count);
        }

        public async Task <Meal> GetMealAsync(int restaurantId, int categoryId, int mealId, bool trackChanges) =>
             await FindByCondition(e => e.CategoryId.Equals(categoryId) && e.MealId.Equals(mealId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateMealForCategory(int restaurantId, int categoryId, Meal meal)
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