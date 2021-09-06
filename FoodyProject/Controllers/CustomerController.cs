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
        public async Task<IActionResult> GetCustomerAsync(Guid customerId)
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
            return CreatedAtRoute("CustomerById", new { id = customerToReturn.CustomerId }, customerToReturn);
            // return Ok(customerToReturn);

        }



        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomerForRestaurant(Guid customerId)
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

        //CreateCustomerContact//

        [HttpPost("{customerId}/CustomerContact")]
        public async Task<IActionResult> CreateCustomerContact(Guid customerId, [FromBody] CustomerContactForCreationDto customercontact)
        {
            if (customercontact == null)
            {

                return BadRequest("customerContactForCreationDto object is null");
            }
            var customer = _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {

                return NotFound();
            }

            var customercontactEntity = _mapper.Map<CustomerContact>(customercontact);

            _repository.CustomerContact.CreateCustomerContact(customerId, customercontactEntity);
            await _repository.SaveAsync();



            var customercontactToReturn = _mapper.Map<CustomerContactDto>(customercontactEntity);
            return CreatedAtRoute("CustomerContactById", new { customerId, id = customercontactToReturn.CustomerContactId }, customercontactToReturn);


        }

        [HttpGet("{customerId}/contacts")]
        public async Task<IActionResult> GetAllCustomersContactAsync(Guid customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {

                return NotFound();
            }
            var customercontactFromDb = _repository.CustomerContact.GetAllCustomersContactAsync(customerId,
           trackChanges: false);
            return Ok(customercontactFromDb);
        }

        [HttpGet("{customerId}/contact", Name = "CustomerContactById")]

        public async Task<IActionResult> GetCustomerContactAsync(Guid customerId, Guid id)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {

                return NotFound();
            }
            var customercontactDb = await _repository.CustomerContact.GetCustomerContactAsync(customerId, id, trackChanges:
           false);
            if (customercontactDb == null)
            {

                return NotFound();
            }
            var customercontact = _mapper.Map<CustomerContactDto>(customercontactDb);
            return Ok(customercontact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerContact (Guid customerId, Guid id)
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
        public async Task<IActionResult> UpdateCustomerContactForCustomer(Guid customerid, Guid customercontactid, [FromBody] CustomerContactForUpdateDto customercontact)
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
            var customercontactentity = _repository.CustomerContact.GetCustomerContactAsync(customerid, customercontactid, trackChanges:
           true);
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

