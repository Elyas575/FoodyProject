using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
    public interface IRestaurantContactRepository
    {
        Task<IEnumerable<RestaurantContact>>  GetAllRestaurantContactAsync( bool trackChanges);
        Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges);
        void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact);
        void DeleteRestaurantContact(RestaurantContact restaurantcontact); 
    }
}