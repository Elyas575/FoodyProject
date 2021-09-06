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

        Task<IEnumerable<RestaurantContact>>  GetAllRestaurantContactAsync(Guid restaurantId, bool trackChanges);
        Task<RestaurantContact> GetRestaurantContactAsync(Guid restaurantId, Guid id, bool trackChanges);


        void CreateRestaurantContact(Guid restaurantId, RestaurantContact restaurantcontact);

        void DeleteRestaurantContact(RestaurantContact restaurantcontact); 
    }









    }

