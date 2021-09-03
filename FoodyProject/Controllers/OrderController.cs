
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;


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

            var order =  _repository.Order.GetOrder(id, trackchanges);

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
        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderDto order, bool trackChanges)
        {
            if (order == null)
            {
                return BadRequest("object is null");
            }

            var orderentity = _mapper.Map<Order>(order);

            _repository.Order.CreateOrder(orderentity, trackChanges);

            _repository.Save();

            var Ordertoreturn = _mapper.Map<OrderDto>(orderentity);

            return CreatedAtRoute("OrderById", new { id = Ordertoreturn.OrderDescription}, Ordertoreturn);
        }
    }
}
     

 