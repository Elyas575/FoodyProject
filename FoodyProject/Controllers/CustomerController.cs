﻿using AutoMapper;
using FoodyProject.Helpers.RequestParameters;
using FoodyProject.Models;
using FoodyProject.Services.Interfaces;
using FoodyProject.ViewModels.Customer;
using FoodyProject.ViewModels.CustomerContact;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllCustomersAsync([FromQuery] CustomerParameters customerParameters)
        {
            var customers = await _repository.Customer.GetAllCustomersAsync(trackChanges: false, customerParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customers.MetaData));
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return Ok(customerDto);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCUstomerByIdAsync(int customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Ok(customerDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                return BadRequest("CompanyForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var customerEntity = _mapper.Map<Customer>(customer);
            _repository.Customer.CreateCustomer(customerEntity);

            await _repository.SaveAsync();
            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);

            return Ok(customerToReturn);            
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(int customerId, [FromBody] CustomerForUpdateDto customer)
        {
            if (customer == null)
            {
                return BadRequest("Object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var customerEntity = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: true);
            if (customerEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(customer, customerEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(int customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            _repository.Customer.DeleteCustomer(customer);
            await _repository.SaveAsync();

            return Ok();
        }

        [HttpGet("contacts")]
        public async Task<IActionResult> GetAllCustomersContactsAsync([FromQuery] CustomerContactParameters customerContactParameters)
        {
            var customercontactFromDb = await _repository.CustomerContact.GetAllCustomersContactsAsync(customerContactParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customercontactFromDb.MetaData));
            var customerDto = _mapper.Map<IEnumerable<CustomerContactDto>>(customercontactFromDb);
            return Ok(customerDto);
        }

        [HttpGet("{customerId}/cutomerContact")]
        public async Task<IActionResult> GetAllContactsForCustomerAsync(int customerId, [FromQuery] CustomerContactParameters customerContactParameters)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            var customerContactFromDb = await _repository.CustomerContact.GetAllContactsForCustomerAsync(customerId, customerContactParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customerContactFromDb.MetaData));
            var customerDto = _mapper.Map<IEnumerable<CustomerContactDto>>(customerContactFromDb);

            return Ok(customerDto);
        }

        [HttpGet("{customerId}/contacts/{customercontactId}", Name = "CustomerContactById")]
        public async Task<IActionResult> GetCustomerContactAsync(int customerId, int customercontactId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            var customercontactDb = await _repository.CustomerContact.GetCustomerContactAsync(customerId, customercontactId, trackChanges: false);
            if (customercontactDb == null)
            {
                return NotFound();
            }

            var customercontact = _mapper.Map<CustomerContactDto>(customercontactDb);
            
            return Ok(customercontact);
        }

        [HttpPost("{customerId}/CustomerContact")]
        public async Task<IActionResult> CreateCustomerContact(int customerId, [FromBody] CustomerContactForCreationDto customercontact)
        {

            if (customercontact == null)
            {
                return BadRequest("CustomerContactForCreationDto object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            var customercontactEntity = _mapper.Map<CustomerContact>(customercontact);
            _repository.CustomerContact.CreateCustomerContact(customerId, customercontactEntity);
            
            await _repository.SaveAsync();
            var customercontactToReturn = _mapper.Map<CustomerContactDto>(customercontactEntity);
            
            return Ok(customercontactToReturn);
        }

        [HttpPut("{customerId}/contacts/{customerContactId}")]
        public async Task<IActionResult> UpdateCustomerContact(int customerId, int customerContactId, [FromBody] CustomerContactForUpdateDto customerContact)
        {
            if (customerContact == null)
            {
                return BadRequest("Object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {  
                return NotFound();
            }

            var customerContactEntity = await _repository.CustomerContact.GetCustomerContactAsync(customerId, customerContactId, trackChanges:true);
            if (customerContactEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(customerContact, customerContactEntity);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{customerId}/contacts/{customerContactId}")]
        public async Task<IActionResult> DeleteCuGstomerContact(int customerId, int customerContactId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            var customerContact = await _repository.CustomerContact.GetCustomerContactAsync(customerId, customerContactId, trackChanges: false);
            if (customerContact == null)
            {
                return NotFound();
            }

            _repository.CustomerContact.DeleteCustomerContact(customerContact);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}