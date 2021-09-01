using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        public CustomerController(IRepositoryManager repository)
        {
            _repository = repository;

        }
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customer = _repository.Customer.GetAllCustomers(trackChanges: false);
                return Ok(customer);
            }


            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");

            }


        }
    }
}