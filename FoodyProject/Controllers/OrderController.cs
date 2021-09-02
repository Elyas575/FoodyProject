
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;

using Microsoft.AspNetCore.Mvc;
using System;


namespace FoodyProject.Controllers
{

    [Route("api/companies")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
           private readonly IMapper _mapper;
        public OrderController(IRepositoryManager repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            try
            {
                var orders = _repository.Order.GetAllOrders(trackChanges: false);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet] public IActionResult GetOrder(int id) {

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
     

 