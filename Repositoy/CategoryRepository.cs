using Contracts;
using Entities;
using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositoy
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Category> GetAllCategories(Guid restaurantId, bool trackChanges) =>
          FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
          .OrderBy(e => e.CategoryName);


        public Category GetCategory(Guid restaurantId, Guid categoryId, bool trackChanges) =>
             FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.CategoryId.Equals(categoryId), trackChanges)
             .SingleOrDefault();

        public void CreatCategory(Guid restaurantId, Category category)
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