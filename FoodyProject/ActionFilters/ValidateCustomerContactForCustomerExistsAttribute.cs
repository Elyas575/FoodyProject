using FoodyProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateCustomerContactForCustomerExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateCustomerContactForCustomerExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true : false;
            var customerId = (int)context.ActionArguments["customerId"];
            var customer = await _repository.Customer.GetCustomerAsync(customerId, false);

            if (customer == null)
            {
                context.Result = new NotFoundResult();
                return;
            }

            var customerContactId = (int)context.ActionArguments["customerContactId"];
            var customerContact = await _repository.CustomerContact.GetCustomerContactAsync(customerId, customerContactId, trackChanges);

            if (customerContact == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("restaurantContact", customerContact);
                await next();
            }
        }
    }
}
