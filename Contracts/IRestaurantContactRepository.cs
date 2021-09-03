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
        RestaurantContact GetRestaurantContactForRestaurant(Guid restaurantContactId, bool trackChanges);
        




    }
}
