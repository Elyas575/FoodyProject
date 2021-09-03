using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/restuarantcontroller")]
    [ApiController]
    public class RestuarantController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;


        public RestuarantController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        ////////////////////////////////////// Crate Restaurant //////////////////////////////////



        [HttpPost]
        public IActionResult CreateRestaurant([FromBody]  RestuarantForCreationDto restaurant)
        {
            if (restaurant == null)
            {
                
            return BadRequest("RestaurantForCreationDto object is null");
            }
            var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
            _repository.Restaurant.CreateRestaurant(restaurantEntity);
            _repository.Save();
            var restaurantToReturn = _mapper.Map<RestaurantDto>(restaurantEntity);
            return CreatedAtRoute("RestaurantById", new { id = restaurantToReturn.RestaurantId },
           restaurantToReturn);
        }













        /////////////////////////// Get All Restaurant //////////////////////////////////

        [HttpGet]
        public IActionResult GetAllRestaurant()
        {
            var restaurants = _repository.Restaurant.GetAllRestaurant(trackChanges: false);

            var restaurantDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return Ok(restaurantDto);
        }



        //////////////////////////Delete Restaurant///////////////////////

        [HttpDelete("{restaurantid}")]
        public IActionResult DeleteRestaurant(Guid restaurantId, Guid id)
        {

            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);


            _repository.Restaurant.DeleteRestaurant(restaurant);
            _repository.Save();
            return NoContent();
        }
         

        ///////////////////////////// 
        [HttpGet("{id}", Name = "RestaurantById")]
        public IActionResult GetRestaurantById(Guid id)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(id, trackChanges: false);

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restaurantDto);

        }

        /////////////////////////////// update restuarant ////////////////////////////////

        [HttpPut("{id}")]
        public IActionResult UpdateEmployeeForCompany(Guid restaurantId, Guid id, [FromBody] RestaurantForUpdateDto restaurant)
        {
            
           
            var restaurantEntity = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: true);
           
            _mapper.Map(restaurant, restaurantEntity);
            _repository.Save();
            return NoContent();
        }



      















    }
}
