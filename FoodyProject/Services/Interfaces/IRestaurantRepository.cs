using Entities.Models;
using FoodyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRestaurantRepository
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges);
        Task<IEnumerable<Restaurant>> GetRestaurantByCityAsync(string city, RestaurantParameters restaurantParameters, bool trackChanges);
        Task<Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges);
        Task<IEnumerable<Restaurant>> GetRestaurantByNameAsync(string name, RestaurantParameters restaurantParameters, bool trackChanges);
        Task<IEnumerable<Restaurant>>GetBestRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges);
        void DeleteRestaurant(Restaurant restaurant);
        void CreateRestaurant(Restaurant restaurant);
    }
}