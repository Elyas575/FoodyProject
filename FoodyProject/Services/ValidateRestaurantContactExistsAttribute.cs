using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Services
{

    public class ValidateRestaurantContactExistsAttribute
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
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true :
           false;
            var restaurantid = (int)context.ActionArguments["restaurantid"];
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantid, false);
            if (restaurant == null)
            {


                context.Result = new NotFoundResult();
                return;
            }
            var restaurantContactId = (int)context.ActionArguments["restaurantContactId"];
            var restaurantcontact = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantid, restaurantContactId,
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


