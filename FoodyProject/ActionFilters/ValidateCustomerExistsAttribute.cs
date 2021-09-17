using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{
    public class ValidateCustomerExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateCustomerExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;        
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
            var customerId = (int)context.ActionArguments["customerId"];
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges);
            
            if (customer == null)
            {             
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("customer", customer);
                await next();
            }
        }
    }
}
  