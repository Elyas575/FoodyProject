using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.ActionFilters
{ /* order = employee 
   * customer = company */
    public class ValidateEmployeeForCompanyExistsAttribute : IAsyncActionFilter
    {
        private readonly IRepositoryManager _repository;

        public ValidateEmployeeForCompanyExistsAttribute(IRepositoryManager repository)
        {
            _repository = repository;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
       ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            var trackChanges = (method.Equals("PUT") || method.Equals("PATCH")) ? true :  false;
            var orderId = (int)context.ActionArguments["companyId"];
            var order = await _repository.Order.GetOrderAsync(orderId, false);
            if (order == null)
            {
                context.Result = new NotFoundResult();
                return;
            }
            var id = (int)context.ActionArguments["id"];
            var employee = await _repository.Customer.GetCustomerAsync(orderId,
           trackChanges);
            if (employee == null)
            {

            }
            else
            {
                context.HttpContext.Items.Add("employee", employee);
                await next();
            }
        }
    }
}