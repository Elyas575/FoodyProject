
using Contracts;
using Entities;
using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositoy
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Meal> GetAllMeals(Guid categoryId, bool trackChanges) =>
              FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges)
               .OrderBy(e => e.Name);

        public Meal GetMeal(Guid categoryId, Guid mealid, bool trackChanges) =>
             FindByCondition(e => e.CategoryId.Equals(categoryId) && e.MealId.Equals(mealid), trackChanges)
             .SingleOrDefault();

        public void CreateMealForCategory(Guid categoryId, Meal meal)
        {
            meal.CategoryId = categoryId;
            Create(meal);
        }

    }
}