using Entities.Models;
using System;
using System.Linq;

namespace FoodyProject.Services.NewFolder
{
    public static class RestauranrContactExtensions


    {

        public static IQueryable<RestaurantContact> Search(this IQueryable<RestaurantContact> restauranrContact, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return restauranrContact;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return restauranrContact.Where(e => e.PhoneNumber.ToLower().Contains(lowerCaseTerm));
        }
    }
}
