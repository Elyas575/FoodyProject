using FoodyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateCategoryForRestaurantExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateCategoryForRestaurantExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
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

            var categoryId = (int)context.ActionArguments["categoryId"];
            var category = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges);

            if (category == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("category", category);
                await next();
            }
        }
    }
}
