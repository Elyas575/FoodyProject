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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindAll(trackChanges)
                .OrderBy(c => c.CategoryName)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }

        public async Task<PagedList<Category>> GetAllCategoriesByRestaurantId(int restaurantId, CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
                .OrderBy(e => e.CategoryName)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }
             
        public async Task<PagedList<Category>> GetCategoriesByNameAsync(string categoryName, CategoryParameters categoryParameters, bool trackChanges)
        {
            var category = await FindByCondition(e => e.CategoryName.Equals(categoryName), trackChanges)
                .OrderBy(e => e.CategoryName)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize)
                .ToListAsync();

            var count = await FindByCondition(e => e.CategoryName.Equals(categoryName), trackChanges).CountAsync();

            return new PagedList<Category>(category, categoryParameters.PageNumber, categoryParameters.PageSize, count);
        }

        public async Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges) =>
             await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.CategoryId.Equals(categoryId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateCategory(int restaurantId, Category category)
        {
            category.RestaurantId = restaurantId;
            Create(category);
        }

        public void DeleteCategory(Category category) => Delete(category);
    }
}