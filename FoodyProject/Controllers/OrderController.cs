
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;

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
        [HttpGet("{id}")] public IActionResult GetOrder(Guid id) {

            var order =  _repository.Order.GetOrder(id);

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
    }
}
     

 