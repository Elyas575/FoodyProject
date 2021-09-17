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
        Task<PagedList<RestaurantContact>> GetAllRestaurantContactsAsync( RestaurantContactParameters restaurantcontactParameters, bool trackChanges ); 
        Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges);
        Task<PagedList<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, RestaurantContactParameters restaurantcontactParameters,  bool trackChanges);
        void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact);
        void DeleteRestaurantContact(RestaurantContact restaurantcontact);
    }
}