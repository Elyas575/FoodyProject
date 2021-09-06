
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{

    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public OrderController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _repository.Order.GetAllOrders(trackChanges: false);
            return Ok(orders);
        }
        [HttpGet("{id}", Name = "OrderById")]
        public IActionResult GetOrder(Guid id, bool trackchanges) {

            var order = _repository.Order.GetOrder(id, trackchanges);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var companyDto = _mapper.Map<OrderDto>(order);

                return Ok(companyDto);
            }
        }
        [HttpPost("customers/{customerId}")]
        public async  Task<IActionResult> CreateOrder(Guid customerId, [FromBody] OrderForCreationDto order)
        {
            if (order == null)
            {              
                return BadRequest("OrderForCreationDto object is null");
            }
            var customer = _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);

            if (customer == null)

            {
                
            return NotFound();
            }

            var orderEntity = _mapper.Map<Order>(order);

            _repository.Order.CreateOrder(customerId, orderEntity);
            await _repository.SaveAsync();


            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return CreatedAtRoute("",new
            {customerId,id = orderToReturn.OrderId }, orderToReturn); }

        [HttpDelete("{OrderId}")]
        public async  Task<IActionResult> DeleteOrder(Guid orderId, Guid id)
        {
            var order = _repository.Order.GetOrder(orderId, trackChanges: false);

            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
     

 