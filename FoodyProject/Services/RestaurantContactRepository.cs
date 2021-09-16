﻿using Contracts;
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

        public async Task<IEnumerable<RestaurantContact>> GetAllRestaurantContactsAsync(bool trackChanges, RestaurantContactParameters restaurantcontactParameters) =>
    await FindAll(trackChanges)
    .OrderBy(e => e.PhoneNumber)
    .Skip((restaurantcontactParameters.PageNumber - 1) * restaurantcontactParameters.PageSize)
    .Take(restaurantcontactParameters.PageSize)
    .ToListAsync();
        public async Task<IEnumerable<RestaurantContact>> GetAllRestaurantsContactsAsync(bool trackChanges) =>
         await FindAll(trackChanges)
         .OrderBy(e => e.RestaurantId)
         .ToListAsync();

        public async Task<IEnumerable<RestaurantContact>> GetAllContactsForRestaurantAsync(int restaurantId, bool trackChanges) =>
            await FindByCondition(e => e.RestaurantId.Equals(restaurantId), trackChanges)
            .OrderBy(e => e.RestaurantContactId)
            .ToListAsync();

        public async Task<RestaurantContact> GetRestaurantContactAsync(int restaurantId, int id, bool trackChanges) =>
         await FindByCondition(e => e.RestaurantId.Equals(restaurantId) && e.RestaurantContactId.Equals(id),
         trackChanges)
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