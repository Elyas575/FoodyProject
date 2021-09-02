using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

          
        public CustomerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers =  _repository.Customer.GetAllCustomers( trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDto);
        }


        [HttpGet("{id}")]
        public  IActionResult GetCustomer(Guid id)
        {
            var customer =  _repository.Customer.GetCustomer(id, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            else
            {
                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Ok(customerDto);
            }
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                
                
            return BadRequest("CompanyForCreationDto object is null");
            }
            var customerEntity = _mapper.Map<Customer>(customer);
            _repository.Customer.CreateCustomer(customerEntity);
            _repository.Save();
            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
            return CreatedAtRoute("CustomerById", new { id = customerToReturn.CustomerId },customerToReturn);
        }



        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerForRestaurant(Guid customerId, Guid id)
        {
            var customer =  _repository.Customer.GetCustomer(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok();
        }


    }

    }
