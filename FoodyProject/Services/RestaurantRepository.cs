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
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public async Task<PagedList<Restaurant>> GetAllRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges)
        {
            var restauarnt = await FindAll(trackChanges)
                .Include(x=>x.RestaurantContacts)
                 .OrderBy(e => e.Name)
                 .Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
                   .Take(restaurantParameters.PageSize)
                   .ToListAsync();

            var count = await FindAll( trackChanges).CountAsync();


            return new PagedList<Restaurant>(restauarnt, restaurantParameters.PageNumber, restaurantParameters.PageSize, count);

        }


        public async Task<PagedList<Restaurant>> GetRestaurantByCityAsync(string city, RestaurantParameters restaurantParameters, bool trackChanges)
        {
            var cities = await FindByCondition(c => c.City.Equals(city), trackChanges)
                .OrderBy(e => e.City)
                .Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
                   .Take(restaurantParameters.PageSize)
                   .ToListAsync();


            var count = await FindAll(trackChanges).CountAsync();


            return new PagedList<Restaurant>(cities, restaurantParameters.PageNumber, restaurantParameters.PageSize, count);



        }



        public async Task <Restaurant> GetRestaurantAsync(int restaurantId, bool trackChanges) =>
            await FindByCondition(c => c.RestaurantId.Equals(restaurantId), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<PagedList<Restaurant>> GetRestaurantByNameAsync(string name, RestaurantParameters restaurantParameters, bool trackChanges)
        {
            var names = await FindAll(trackChanges)
                .OrderBy(e => e.Name)
                .Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
                   .Take(restaurantParameters.PageSize)
                   .ToListAsync();


            var count = await FindAll(trackChanges).CountAsync();


            return new PagedList<Restaurant>(names, restaurantParameters.PageNumber, restaurantParameters.PageSize, count);


        }


        //GetBestRestaurantAsync
        public async Task<List<Restaurant>> GetBestRestaurantAsync(RestaurantParameters restaurantParameters, bool trackChanges)
        {
            var b = FindAll(trackChanges).Where(x=>x.Rate != null && x.Rate != 0 /* x.resId = id*/).ToList();
            var c = b.Sum(x => x.Rate);
            var rate = c / b.Count();

            var best = FindAll(trackChanges).Where(x=>x.Rate != null).ToList().GroupBy(x => x.Rate).OrderByDescending(x => x.Key).FirstOrDefault().AsEnumerable().ToList();
            //var b = best.ToList();
            //.OrderBy(e => e.Name)
            //.Skip((restaurantParameters.PageNumber - 1) * restaurantParameters.PageSize)
            //.Take(restaurantParameters.PageSize)
            //.ToListAsync()k

            var count = await FindAll(trackChanges).CountAsync();


            return new PagedList<Restaurant>(best, restaurantParameters.PageNumber, restaurantParameters.PageSize, count);

        }


        public void DeleteRestaurant(Restaurant restaurant) => Delete(restaurant);

        public void CreateRestaurant(Restaurant restaurant) => Create(restaurant);
    }
}