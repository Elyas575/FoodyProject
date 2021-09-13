using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateRestauranContactExistsAttribute
    {
        public class ValidateRestaurantContactExistsAttribute : IAsyncActionFilter
        {
            private readonly IRepositoryManager _repository;
            public ValidateRestaurantContactExistsAttribute(IRepositoryManager repository)
            {
                _repository = repository;
            }
            public async Task OnActionExecutionAsync(ActionExecutingContext context,
           ActionExecutionDelegate next)
            {


                var method = context.HttpContext.Request.Method;
                var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;

                var restaurantId = (int)context.ActionArguments["restaurantId"];
                var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, false);
                if (restaurant == null)
                {


                    context.Result = new NotFoundResult();
                    return;
                }
                var restaurantContactId = (int)context.ActionArguments["restaurantcontactId"];
                var restaurantcontact = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantId, restaurantContactId,
               trackChanges);
                if (restaurantcontact == null)
                {

                    context.Result = new NotFoundResult();
                }
                else
                {
                    context.HttpContext.Items.Add("restaurantcontact", restaurantcontact);
                    await next();
                }
            }
        }
    }
}
