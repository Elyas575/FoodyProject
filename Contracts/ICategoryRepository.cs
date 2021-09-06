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
         Task<IEnumerable<Category>> GetAllCategoriesAsync(Guid restaurantId, bool trackChanges);
         Task <Category> GetCategoryAsync(Guid restaurantId, Guid categoryId, bool trackChanges);

        void CreatCategory(Guid restaurantId, Category category);

        void DeleteCategory(Category category);

    }
}
