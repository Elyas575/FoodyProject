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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool trackChanges) =>
          await FindAll(trackChanges)
          .OrderBy(c => c.CategoryName)
           .ToListAsync();

        public async Task<IEnumerable<Category>> GetAllCategoriesByRestaurantId(int restaurantId, bool trackChanges) =>
             await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
            .OrderBy(e => e.CategoryName)
            .ToListAsync();

        public async Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges) =>
             await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.CategoryId.Equals(categoryId), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Category>> GetCategoriesByNameAsync(string categoryName, bool trackChanges) =>
            await FindByCondition(e => e.CategoryName.Equals(categoryName), trackChanges)
            .OrderBy(e => e.CategoryName)
            .ToListAsync();

        public void CreateCategory(int restaurantId, Category category)
        {
            category.RestaurantId = restaurantId;
            Create(category);
        }
        public void DeleteCategory(Category category)
        {
            Delete(category);
        }
    }
}