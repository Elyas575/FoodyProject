using Entities;
using FoodyProject.Helpers.CollectionHelper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using FoodyProject.Services.NewFolder;
using FoodyProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Services
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
                   .OrderBy(e => e.Id)
                     .Search(restaurantcontactParameters.SearchTerm)
                     .Skip((restaurantcontactParameters.PageNumber - 1) * restaurantcontactParameters.PageSize)
                     .Take(restaurantcontactParameters.PageSize)
                     .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<RestaurantContact>(restauarntcontact, restaurantcontactParameters.PageNumber, restaurantcontactParameters.PageSize, count);
        }

        public async Task<PagedList<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, RestaurantContactParameters restaurantcontactParameters,  bool trackChanges)
        {
            var restaurantcontact = await FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
            .Search(restaurantcontactParameters.SearchTerm)
            .OrderBy(e => e.Id)
            .Skip((restaurantcontactParameters.PageNumber - 1) * restaurantcontactParameters.PageSize)
            .Take(restaurantcontactParameters.PageSize)
            .ToListAsync();

            var count = await FindAll(trackChanges).CountAsync();

            return new PagedList<RestaurantContact>(restaurantcontact, restaurantcontactParameters.PageNumber, restaurantcontactParameters.PageSize, count);
        }

        public async Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges) =>
            await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateRestaurantContact(int restaurantId, RestaurantContact restaurantcontact)
        {
            restaurantcontact.RestaurantId = restaurantId;
            Create(restaurantcontact);
        }

        public void DeleteRestaurantContact(RestaurantContact restaurantcontact) => Delete(restaurantcontact);
    }
}