
using Contracts;
using Entities;
using Entities.Models;
using Repository;

namespace Repositoy
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}