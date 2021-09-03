using Contracts;
using Entities;
using Entities.Models;
using Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RestaurantContactRepository : RepositoryBase<RestaurantContact>, IRestaurantContactRepository
    {
        public RestaurantContactRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public RestaurantContact GetRestaurantContactForRestaurant(Guid restaurantconatctId, bool trackChanges) =>
           FindByCondition(c => c.RestaurantContactId.Equals(restaurantconatctId), trackChanges)
           .SingleOrDefault();

    }
}


