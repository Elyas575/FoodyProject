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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }

        public async Task<PagedList<Category>> GetAllCategoriesByRestaurantIdAsync(int restaurantId, CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
                .OrderBy(e => e.Name)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }
             
        public async Task<PagedList<Category>> GetCategoriesByNameAsync(string categoryName, CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindByCondition(e => e.Name.Equals(categoryName), trackChanges)
                .OrderBy(e => e.Name)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(e => e.Name.Equals(categoryName), trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }

        public async Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges) =>
             await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.Id.Equals(categoryId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateCategory(int restaurantId, Category category)
        {
            category.RestaurantId = restaurantId;
            Create(category);
        }

        public void DeleteCategory(Category category) => Delete(category);
    }
}