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
    [Route("api/restaurant")]
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


        ////////////////////////////////////// Create Restaurant //////////////////////////////////



        [HttpPost]
        public IActionResult CreateRestaurant([FromBody] RestaurantForCreationDto restaurant)
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


        /////////////////////////// Get All Restaurants //////////////////////////////////

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


        ///////////////////////////// Get restaurant by id ///////////////////////////////////////
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

        ///////////////////////////////////////// Get all Restaurant Contact  /////////////////////////////////////////




        [HttpGet("{restaurantId}/contacts")]
        public IActionResult GetAllRestaurantContact(Guid restaurantId)
        {
            var company = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (company == null)
            {

                return NotFound();
            }
            var restaurantcontactFromDb = _repository.RestaurantContact.GetAllRestaurantContact(restaurantId,
           trackChanges: false);
            return Ok(restaurantcontactFromDb);
        }





        ////////////////////////////////////////// Get a Single Restaurant Contact For a Restaurant /////////////////////////////////////
        [HttpGet("{restaurantId}/contact", Name = "RestaurantContactById")]
       
        public IActionResult GetRestaurantContact(Guid restaurantId, Guid id)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {

                return NotFound();
            }
            var restaurantcontactDb = _repository.RestaurantContact.GetRestaurantContact(restaurantId, id, trackChanges:
           false);
            if (restaurantcontactDb == null)
            {

                return NotFound();
            } 
            var restaurantcontact = _mapper.Map<RestaurantContactDto>(restaurantcontactDb);
            return Ok(restaurantcontact);
        }


        /////////////////////////////////////////      Create Restaurant Contact        ///////////////////////////////////// 


        [HttpPost("{restaurantId}/RestaurantContact")]
        public IActionResult CreateRestaurantContact(Guid restaurantId, [FromBody] RestaurantContactForCreationDto restaurantcontact)
        {
/*resturatn = company 
 * resturantcontact = employee */     
            if (restaurantcontact == null)
            {

                return BadRequest("RestaurantContactForCreationDto object is null");
            }
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {

                return NotFound();
            }
            var restaurantcontactEntity = _mapper.Map<RestaurantContact>(restaurantcontact);

            _repository.RestaurantContact.CreateRestaurantContact(restaurantId, restaurantcontactEntity);
            _repository.Save();
            var restaurantcontactToReturn = _mapper.Map<RestaurantContactDto>(restaurantcontactEntity);
            return CreatedAtRoute("RestaurantContactById", new
            {
                restaurantId,id = restaurantcontactToReturn.RestaurantContactId  }, restaurantcontactToReturn);


        }

    }
}
       
        