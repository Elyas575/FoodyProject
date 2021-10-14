using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<PagedList<Restaurant>> GetAllRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges);
        Task<PagedList<Restaurant>> GetRestaurantByCityAsync(string city, RestaurantParameters restaurantParameters, bool trackChanges);
        Task<PagedList<Restaurant>> GetRestaurantByNameAsync(string name, RestaurantParameters restaurantParameters, bool trackChanges);
        Task<Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges);
        //Task<List<Restaurant>>GetBestRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges);
        void DeleteRestaurant(Restaurant restaurant);
        void CreateRestaurant(Restaurant restaurant);
    }
}