using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateCompanyExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;
        public ValidateCompanyExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var restaurantId = (int)context.ActionArguments["restaurantId"];
            var restaurant = await _repository.Restaurant.GetRestaurantAsync( restaurantId, trackChanges);
            if (restaurant == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("restaurant", restaurant);
                await next();
            }
        }
    }
}
