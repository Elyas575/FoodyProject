using FoodyProject.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using FoodyProject.Services.Extensions.Utility;

namespace FoodyProject.Services.NewFolder
{
    public static class RepositorRestaurantExtensions
    {

        //searchig method 

        public static IQueryable<Restaurant> Search(this IQueryable<Restaurant> restauarnts, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) return restauarnts;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return restauarnts.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }


        //sorting method 

        public static IQueryable<Restaurant> Sort(this IQueryable<Restaurant> Restaurant, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return Restaurant.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Restaurant>(orderByQueryString);

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Restaurant).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
               pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;

                var direction = param.EndsWith("desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }
            var orderQuery1 = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
                return Restaurant.OrderBy(e => e.Name);
            return Restaurant.OrderBy(orderQuery);
}
    }
}
