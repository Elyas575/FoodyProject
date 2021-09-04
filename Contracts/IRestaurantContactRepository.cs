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

        IEnumerable<RestaurantContact> GetAllRestaurantContact(Guid restaurantId, bool trackChanges);
        RestaurantContact GetRestaurantContact(Guid restaurantId, Guid id, bool trackChanges);


        void CreateRestaurantContact(Guid restaurantId, RestaurantContact restaurantcontact);
    }









    }

