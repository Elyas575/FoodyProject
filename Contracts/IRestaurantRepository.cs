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


        Restaurant GetRestaurant(Guid restaurantId, bool trackChanges);
        IEnumerable<Restaurant> GetAllRestaurant(bool trackChanges);
        void DeleteRestaurant(Restaurant restaurant);
        void CreateRestaurant(Restaurant restaurant);

    }
}
