using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{ 
    public class ValidateOrderForCustomerExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateOrderForCustomerExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true :  false;
            //var restaurantId = (int)context.ActionArguments["restaurantId"];
            //var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, false);
            //var customerId = (int)context.ActionArguments["customerId"];
            //var customer = await _repository.Customer.GetCustomerAsync(customerId, false);

            //if (restaurant == null)
            //{
            //    context.Result = new NotFoundResult();
            //    return;
            //}

            //if (customer == null)
            //{
            //    context.Result = new NotFoundResult();
            //    return;
            //}

            var orderId = (int)context.ActionArguments["orderId"];
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges);
            if (order == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("order", order);
                await next();
            }
        }
    }
}