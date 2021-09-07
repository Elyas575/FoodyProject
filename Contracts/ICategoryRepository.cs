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
         Task<IEnumerable<Category>> GetAllCategoriesAsync(string restaurantId, bool trackChanges);
         Task <Category> GetCategoryAsync(string restaurantId, string categoryId, bool trackChanges);

        void CreateCategory(string restaurantId, Category category);

        void DeleteCategory(Category category);

    }
}
