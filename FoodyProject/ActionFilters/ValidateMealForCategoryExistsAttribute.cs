using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateMealForCategoryExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateMealForCategoryExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;
            var restaurantId = (int)context.ActionArguments["restaurantId"];
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, false);
            var categoryId = (int)context.ActionArguments["categoryId"];
            var category = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, false);

            if (restaurant == null)
            {
                context.Result = new NotFoundResult();
                return;
            }

            if(category == null)
            {
                context.Result = new NotFoundResult();
                return;
            }

            var mealId = (int)context.ActionArguments["mealId"];
            var meal = await _repository.Meal.GetMealAsync(restaurantId, categoryId, mealId, trackChanges);

            if (meal == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("meal", meal);
                await next();
            }
        }
    }
}
