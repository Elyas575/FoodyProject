using Entities.Models;
using System;
using System.Linq;

namespace FoodyProject.Services.NewFolder
{
    public static class RepositorRestaurantExtensions
    {

        public static IQueryable<Restaurant> Search(this IQueryable<Restaurant> restauarnts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return restauarnts;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return restauarnts.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
