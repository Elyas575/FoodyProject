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
        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }
        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
    }
}