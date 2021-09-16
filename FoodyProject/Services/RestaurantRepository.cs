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
    public class  RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<Restaurant>> GetAllRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(e => e.Name)
        .Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
        .Take(restaurantParameters.PageSize)
        .ToListAsync();

        public async Task<Restaurant> GetRestaurantByCityAsync(string city, bool trackChanges) =>
        await FindByCondition(c => c.City.Equals(city), trackChanges)
            .SingleOrDefaultAsync();

        public async Task <Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges) =>
            await FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<IEnumerable<Restaurant>> GetRestaurantByNameAsync(string name, RestaurantParameters restaurantParameters, bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(e => e.Name)
        .Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
        .Take(restaurantParameters.PageSize)
        .ToListAsync();


        //GetBestRestaurantAsync

        public async Task<IEnumerable<Restaurant>> GetBestRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges) =>
        public async Task<IEnumerable<Restaurant>> GetBestRestaurantAsync(bool trackChanges) =>
         await FindAll(trackChanges)
           .OrderBy(c => c.Rate)
           .ToListAsync();

        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }

        public void CreateRestaurant(Restaurant restaurant)
        {
            Create(restaurant);
        }
    }
}