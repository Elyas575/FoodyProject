
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using FoodyProject.ActionFilters;
using FoodyProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult>  GetAllOrdersAsync([FromQuery] OrderParameters orderParameters)
        {

            var orders =await _repository.Order.GetAllOrdersAsync(trackChanges: false, orderParameters);
            return Ok(orders);
        }

        [HttpGet("OrderByCustomerId/{customerId}", Name = "OrderByCustomerId")]
        public async Task<IActionResult> GetOrderByCustomerId(int customerId)
        {
            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)
            {
                return NotFound();
            }

            var order = await _repository.Order.GetOrderByCustomerIdAsync(customerId, trackChanges: false);
            if (order == null)
            {
                return NotFound();
            }
         
            var orderdto = _mapper.Map<IEnumerable<OrderDto>>(order);
            return Ok(orderdto);
        }

        [HttpGet("{orderId}", Name = "OrderById")]
        public async Task <IActionResult> GetOrderAsync(int orderId, bool trackchanges) {

            var order = await _repository.Order.GetOrderAsync(orderId, trackchanges);

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
        [HttpGet("OrderByRestaurantId/{ResturantId}")]
        public async Task<IActionResult> GetOrdersForRestaurant(int ResturantId, [FromQuery] OrderParameters orderParameters)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(ResturantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var orderfromdb = await _repository.Order.GetOrdersForRestaurantAsync(ResturantId, orderParameters, trackChanges: false);
            var orderdto = _mapper.Map<IEnumerable<OrderDto>>(orderfromdb);
            return Ok(orderdto);

   
        }


        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost("restaurant/{restaurantId}/customers/{customerId}")]
        public async  Task<IActionResult> CreateOrder(int customerId, int restaurantId, [FromBody] OrderForCreationDto order)
        {
          

            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return BadRequest("OrderForCreationDto object is null");
            }

            var customer = await _repository.Customer.GetCustomerAsync(customerId, trackChanges: false);
            if (customer == null)

            {
                return NotFound();
            }

            var orderEntity = _mapper.Map<Order>(order);

            _repository.Order.CreateOrder(customerId, restaurantId, orderEntity);
            await _repository.SaveAsync();
            var orderToReturn = _mapper.Map<OrderDto>(orderEntity);
            return Ok(orderToReturn);
        }

        [HttpDelete("{orderId}")]
        public async  Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges: false);

            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();

            return NoContent();
        }
     

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateEmployeeForCompanyExistsAttribute))]
        [HttpPut("customers/{customerid}/{orderid}")]
        public async Task<IActionResult> UpdateOrderForCustomer(int customerid, int orderid, [FromBody]OrderForUpdateDto order)
        {
            var orderEntity = HttpContext.Items["customer"] as Customer;
            _mapper.Map(order, orderEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}