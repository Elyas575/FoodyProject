using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customers = await _repository.Customer.GetAllCustomersAsync(trackChanges: false);
            var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);
            return Ok(customerDto);
        }

        [HttpGet("{customerId}", Name = "CustomerById")]
        public async Task<IActionResult> GetCustomerAsync(int customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
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
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto customer)
        {
            if (customer == null)
            {
                return BadRequest("CompanyForCreationDto object is null");
            }
            var customerEntity = _mapper.Map<Customer>(customer);
            _repository.Customer.CreateCustomer(customerEntity);
            await _repository.SaveAsync();
            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
            return Ok(customerToReturn);            
            // return Ok(customerToReturn);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerForRestaurant(int customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }
            _repository.Customer.DeleteCustomer(customer);
            await _repository.SaveAsync();
            return Ok();
        }*/

        ///  Create Customer Contact  
        ///  
        [HttpPost("{customerId}/CustomerContact")]
        public async Task<IActionResult> CreateCustomerContact(int customerId, [FromBody] CustomerContactForCreationDto customercontact)
        {

            if (customercontact == null)
            {
                return BadRequest("CustomerContactForCreationDto object is null");
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
            //return CreatedAtRoute("CustomerContactById", new { customerId, id = customercontactToReturn.CustomerContactId }, customercontactToReturn);
            return Ok(customercontactToReturn);
        }


        //// Get all Customer Contact  
        ///
        [HttpGet("contacts")]
        public async Task<IActionResult> GetAllCustomerContactAsync()
        {
            var customer = await _repository.Customer.GetAllCustomersAsync(trackChanges: false);
            var customercontactFromDb = await _repository.CustomerContact.GetAllCustomerContactAsync(trackChanges: false);
            return Ok(customercontactFromDb);
        }
       // Get a Single Customer Contact 

        [HttpGet("{customerId}/contacts/{id}", Name = "CustomerContactById")]

        public async Task<IActionResult> GetCustomerContactAsync(int customerId, int id)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {

                return NotFound();
            }
            var customercontactDb = await _repository.CustomerContact.GetCustomerContactAsync(customerId, id, trackChanges: false);
            if (customercontactDb == null)
            {

                return NotFound();
            }
            var customercontact = _mapper.Map<CustomerContactDto>(customercontactDb);
            return Ok(customercontact);
        }

            [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer (int customerId, int id)
        {
            var customercontact = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customercontact == null)
            {
                return NotFound();
            }

            _repository.Customer.DeleteCustomer(customercontact);
            await _repository.SaveAsync();

            return NoContent();
        }
       
        [HttpPut("{customerid}")]
        public async Task<IActionResult> UpdateCustomerContactForCustomer(int customerid, int customercontactid, [FromBody] CustomerContactForUpdateDto customercontact)
        {
            if (customercontact == null)
            {
         
                return BadRequest(" object is null");
            }
            var customer = await _repository.Customer.GetCustomerAsync(customerid, trackChanges: false);
            if (customer == null)
            {  
            return NotFound();
            }
            var customercontactentity = _repository.CustomerContact.GetCustomerContactAsync(customerid, customercontactid);
            if (customercontactentity == null)
            {
             
                return NotFound();
            }
            await _mapper.Map(customercontact, customercontactentity);
            await _repository.SaveAsync();
            return NoContent();
        }

    }
}

