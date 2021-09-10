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
    public class  RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task <IEnumerable<Restaurant>> GetAllRestaurantAsync(bool trackChanges) =>
          await FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToListAsync();

        public async Task <Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges) =>
            await FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
             .SingleOrDefaultAsync();

        public async Task<Restaurant> GetRestaurantByNameAsync(string name , bool trackChanges) =>
        await FindByCondition(c => c.Name.Equals(name), trackChanges)
        .SingleOrDefaultAsync();

        public async Task<Restaurant> GetRestaurantByCityAsync(string city, bool trackChanges) =>
        await FindByCondition(c => c.City.Equals(city), trackChanges)
            .SingleOrDefaultAsync();
        
        //GetBestRestaurantAsync

        public async Task<IEnumerable<Restaurant>> GetBestRestaurantAsync(bool trackChanges) =>
         await FindAll(trackChanges)
           .OrderBy(c => c.Rate)
           .ToListAsync();

        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }

        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
    }
}