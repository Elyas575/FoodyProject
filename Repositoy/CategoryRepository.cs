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

        public IEnumerable<Category> GetAllCategories(bool trackChanges) =>
             FindAll(trackChanges)
             .OrderBy(c => c.CategoryName)
             .ToList();

        public Category GetCategory(Guid categoryId, bool trackChanges) =>
             FindByCondition(c => c.CategoryId.Equals(categoryId), trackChanges)
             .SingleOrDefault();

        public void CreatCategory(Category category) => Create(category);


    }
}