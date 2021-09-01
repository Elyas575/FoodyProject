
using Contracts;
using Entities;
using Entities.Models;
using Repository;

namespace Repositoy
{
    public class MealRepository : RepositoryBase<Meal>, IMealRepository
    {
        public MealRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}