using Entities.Models;
using FoodyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
    public interface IRestaurantContactRepository
    {
        Task<IEnumerable<RestaurantContact>> GetAllRestaurantContactsAsync(bool trackChanges, RestaurantContactParameters restaurantcontactParameters ); 
        Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges);
        Task<IEnumerable<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, bool trackChanges);
        void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact);
        void DeleteRestaurantContact(RestaurantContact restaurantcontact);
    }
}