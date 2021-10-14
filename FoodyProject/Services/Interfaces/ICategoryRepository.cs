using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters categoryParameters, bool trackChanges);
        Task<PagedList<Category>> GetAllCategoriesByRestaurantIdAsync(int restaurantId, CategoryParameters categoryParameters, bool trackChanges);
        Task<PagedList<Category>> GetCategoriesByNameAsync(string categoryName, CategoryParameters categoryParameters, bool trackChanges);
        Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges);
        void CreateCategory(int restaurantId, Category category);
        void DeleteCategory(Category category);
    }
}