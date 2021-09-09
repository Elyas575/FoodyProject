
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

        /*  this should be get all orders for one restaurant*/
        public async Task<IActionResult>  GetAllOrdersAsync()
        {
            var orders =await _repository.Order.GetAllOrdersAsync(trackChanges: false);
            return Ok(orders);
        }

        [HttpGet("{id}", Name = "OrderById")]
        public async Task <IActionResult> GetOrderAsync(int id, bool trackchanges) {

            var order = await _repository.Order.GetOrderAsync(id, trackchanges);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var orderdto = _mapper.Map<OrderDto>(order);

                return Ok(orderdto);
            }
        }

        [HttpPost("customers/{customerId}")]
        public async  Task<IActionResult> CreateOrder(int customerId, [FromBody] OrderForCreationDto order)
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

        [HttpDelete("{orderId}")]
        public async  Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges: false);

            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("customers/{customerid}/{orderid}")]
        public async Task<IActionResult> UpdateOrderForCustomer(int customerid, int orderid, [FromBody]OrderForUpdateDto order)
        {
            if (order == null)
            {
                return BadRequest(" object is null");
            }
            var customer = await _repository.Customer.GetCustomerAsync(customerid, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }
            var orderEntity = await _repository.Order.GetOrderAsync(orderid, trackChanges: true);
            if (orderEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(order, orderEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}