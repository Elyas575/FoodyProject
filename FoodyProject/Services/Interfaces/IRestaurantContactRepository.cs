using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using System.Threading.Tasks;

namespace FoodyProject.Services.Interfaces
{
    public interface IRestaurantContactRepository
    {
        Task<PagedList<RestaurantContact>> GetAllRestaurantContactsAsync( RestaurantContactParameters restaurantcontactParameters, bool trackChanges ); 
        Task<PagedList<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, RestaurantContactParameters restaurantcontactParameters,  bool trackChanges);
        Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges);
        void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact);
        void DeleteRestaurantContact(RestaurantContact restaurantcontact);
    }
}