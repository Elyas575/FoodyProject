using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRestaurantRepository
    {
        Task <Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges);
        Task <IEnumerable<Restaurant>> GetAllRestaurantAsync(bool trackChanges);
        Task<Restaurant> GetRestaurantByNameAsync(string name, bool trackChanges);
        Task<Restaurant> GetRestaurantByCityAsync(string city, bool trackChanges);

        
        Task<IEnumerable<Restaurant>>GetBestRestaurantAsync(bool trackChanges);
        
        

        void DeleteRestaurant(Restaurant restaurant);
        void CreateRestaurant(Restaurant restaurant);
    }
}