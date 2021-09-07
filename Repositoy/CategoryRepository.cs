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

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(string restaurantId, bool trackChanges) =>
          await FindAll(trackChanges)
          .OrderBy(c => c.CategoryName)
           .ToListAsync();



        public async Task <Category> GetCategoryAsync(string restaurantId, string categoryId, bool trackChanges) =>
             await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.CategoryId.Equals(categoryId), trackChanges)
             .SingleOrDefaultAsync();

        public void CreateCategory(string restaurantId, Category category)
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