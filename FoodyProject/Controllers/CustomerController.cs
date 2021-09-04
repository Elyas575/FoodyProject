﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FoodyProject.Controllers
{
    [Route("api/customers")]
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
            var customers = _repository.Customer.GetAllCustomers(trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDto);
        }


        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult GetCustomer(Guid id)
        {
            var customer = _repository.Customer.GetCustomer(id, trackChanges: false);
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
            return CreatedAtRoute("CustomerById", new { id = customerToReturn.CustomerId }, customerToReturn);
            // return Ok(customerToReturn);

        }



        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomerForRestaurant(Guid customerId)
        {
            var customer = _repository.Customer.GetCustomer(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }
            _repository.Customer.DeleteCustomer(customer);
            _repository.Save();


            return Ok();
        }

        //CreateCustomerContact//

        [HttpPost("{customerId}/CustomerContact")]
        public IActionResult CreateCustomerContact(Guid customerId, [FromBody] CustomerContactForCreationDto customercontact)
        {
            if (customercontact == null)
            {

                return BadRequest("customerContactForCreationDto object is null");
            }
            var customer = _repository.Customer.GetCustomer(customerId, trackChanges: false);
            if (customer == null)
            {

                return NotFound();
            }

            var customercontactEntity = _mapper.Map<CustomerContact>(customercontact);

            _repository.CustomerContact.CreateCustomerContact(customerId, customercontactEntity);
            _repository.Save();


            var customercontactToReturn = _mapper.Map<CustomerContactDto>(customercontactEntity);
            return CreatedAtRoute("CustomerContactById", new { customerId, id = customercontactToReturn.CustomerContactId }, customercontactToReturn);


        }
    }
}

