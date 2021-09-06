using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
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
        public  RestaurantContactRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task <IEnumerable<RestaurantContact>> GetAllRestaurantContactAsync(Guid restaurantId, bool trackChanges) =>
         await FindAll(trackChanges)
         .OrderBy(e => e.PhoneNumber)
            .ToListAsync();


        public async Task <RestaurantContact> GetRestaurantContactAsync(Guid restaurantId, Guid id, bool trackChanges) =>
 await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.RestaurantContactId.Equals(id),
trackChanges)
 .SingleOrDefaultAsync();



        public void CreateRestaurantContact(Guid restaurantId, RestaurantContact restaurantcontact)
        {
            restaurantcontact.RestaurantId = restaurantId;
            Create(restaurantcontact);
        }

        public void DeleteRestaurantContact(RestaurantContact restaurantcontact)
        {
            Delete(restaurantcontact);
        }






    }
}


