using FoodyProject.Models;
using System.Linq;

namespace FoodyProject.Services.NewFolder
{
    public static class RestauranrContactExtensions
    {
        public static IQueryable<RestaurantContact> Search(this IQueryable<RestaurantContact> restauranrContact, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return restauranrContact;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return restauranrContact.Where(e => e.Phone.ToLower().Contains(lowerCaseTerm));
        }
    }
}
