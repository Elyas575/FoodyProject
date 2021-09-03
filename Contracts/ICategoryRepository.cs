using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories(Guid restaurantId, bool trackChanges);
        Category GetCategory(Guid restaurantId, Guid categoryId, bool trackChanges);

        void CreatCategory(Guid restaurantId, Category category);

        void DeleteCategory(Category category);

    }
}
