using Entities;
using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using FoodyProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Services
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        //Test all meal ???
        public async Task <PagedList<Meal>> GetAllMealsAsync(int restaurantId, int categoryId, MealParameters mealParameters, bool trackChanges)
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
             await FindByCondition(e => e.CategoryId.Equals(categoryId) && e.Id.Equals(mealId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateMeal(int restaurantId, int categoryId, Meal meal)
        {
            meal.CategoryId = categoryId;
            Create(meal);
        }

        public void DeleteMeal(Meal meal) => Delete(meal);
    }
}