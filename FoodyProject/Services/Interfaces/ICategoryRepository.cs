using Entities.Models;
using FoodyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
   public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<PagedList<Category>> GetAllCategoriesByRestaurantId(int restaurantId, CategoryParameters categoryParameters, bool trackChanges);
        Task<PagedList<Category>> GetCategoriesByNameAsync(string categoryName, CategoryParameters categoryParameters, bool trackChanges);
        Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges);
        void CreateCategory(int restaurantId, Category category);
        void DeleteCategory(Category category);
    }
}