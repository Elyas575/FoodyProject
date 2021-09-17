using Contracts;
using Entities;
using Entities.Models;
using FoodyProject.Models;
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
        public RestaurantContactRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<RestaurantContact>> GetAllRestaurantContactsAsync( RestaurantContactParameters restaurantcontactParameters,bool trackChanges)
        {

            var restauarntcontact = await FindAll(trackChanges)
                   .OrderBy(e => e.PhoneNumber)
                   .Skip((restaurantcontactParameters.PageNumber - 1) * restaurantcontactParameters.PageSize)
                     .Take(restaurantcontactParameters.PageSize)
                     .ToListAsync();


            var count = await FindAll(trackChanges).CountAsync();


            return new PagedList<RestaurantContact>(restauarntcontact, restaurantcontactParameters.PageNumber, restaurantcontactParameters.PageSize, count);
        }
        public async Task<PagedList<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, RestaurantContactParameters restaurantcontactParameters,  bool trackChanges)
        {
            var restaurantcontact = await FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
            .OrderBy(e => e.PhoneNumber)
            .Skip((restaurantcontactParameters.PageNumber - 1) * restaurantcontactParameters.PageSize)
               .Take(restaurantcontactParameters.PageSize)
               .ToListAsync();


            var count = await FindAll(trackChanges).CountAsync();


            return new PagedList<RestaurantContact>(restaurantcontact, restaurantcontactParameters.PageNumber, restaurantcontactParameters.PageSize, count);
        }
          

        public async Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges) =>
            await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.RestaurantContactId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact)
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