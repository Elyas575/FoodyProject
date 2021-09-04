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

        public IEnumerable<RestaurantContact> GetAllRestaurantContact(Guid restaurantId, bool trackChanges) =>
 FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
 .OrderBy(e => e.PhoneNumber);


        public RestaurantContact GetRestaurantContact(Guid restaurantId, Guid id, bool trackChanges) =>
 FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.RestaurantContactId.Equals(id),
trackChanges)
 .SingleOrDefault();



        public void CreateRestaurantContact(Guid restaurantId, RestaurantContact restaurantcontact)
        {
            restaurantcontact.RestaurantId = restaurantId;
            Create(restaurantcontact);
        }




    }
}


