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
    public class  RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {

        }
        public IEnumerable<Restaurant> GetAllRestaurant(bool trackChanges) =>
           FindAll(trackChanges)
           .OrderBy(c => c.Name)
           .ToList();

        public Restaurant GetRestaurant(Guid restaurantId, bool trackChanges) =>
             FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
             .SingleOrDefault();




        public void DeleteRestaurant(Restaurant restaurant)
        {
            Delete(restaurant);
        }


        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);



    }

}
