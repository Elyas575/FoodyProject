using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
////////////////////////////////////////////////////// DUJA's Controller/////////////////////////////////////////////
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
        ////////////////////////////////////////////////////////////////////////////////////// Create Restaurant ///////////////////////////////////////////////////////////////////////////////
        [HttpPost]
        public async Task<IActionResult>  CreateRestaurant([FromBody] RestaurantForCreationDto restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest("RestaurantForCreationDto object is null");
            }

            var restaurantEntity = _mapper.Map<Restaurant>(restaurant);
            _repository.Restaurant.CreateRestaurant(restaurantEntity);
            await _repository.SaveAsync();


            var restaurantToReturn = _mapper.Map<RestaurantDto>(restaurantEntity);
            return CreatedAtRoute("RestaurantById", new { id = restaurantToReturn.RestaurantId },
            restaurantToReturn);
        }
        ////////////////////////////////////////////////////////////////// Get All Restaurants //////////////////////////////////
        [HttpGet]
        public async Task <IActionResult> GetAllRestaurant()
        {
            var restaurants = await _repository.Restaurant.GetAllRestaurantAsync(trackChanges: false);

            var restaurantDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

            return Ok(restaurantDto);
        }
        //////////////////////////Delete Restaurant///////////////////////
        [HttpDelete("{restaurantid}")]
        public async Task<IActionResult> DeleteRestaurant(int restaurantId, int id)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            _repository.Restaurant.DeleteRestaurant(restaurant);
            await _repository.SaveAsync();
            return NoContent();
        }
        ///////////////////////////// Get restaurant by id ///////////////////////////////////////
        [HttpGet("{id}", Name = "RestaurantById")]
        public async Task <IActionResult> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(id, trackChanges: false);

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return Ok(restaurantDto);
        }
        /////////////////////////////// update restuarant ////////////////////////////////
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, [FromBody] RestaurantForUpdateDto restaurant)
        {
            if (restaurant == null)
            {
                return BadRequest("CompanyForUpdateDto object is null");
            }
            var restaurantEntity= await _repository.Restaurant.GetRestaurantAsync(id, trackChanges: true);
            if (restaurantEntity == null)
            {
              
                return NotFound();
            }
            _mapper.Map(restaurant, restaurantEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        ///////////////////////////////////////// Get all Restaurant Contact  /////////////////////////////////////////
        [HttpGet("contacts")]
        public async Task<IActionResult> GetAllRestaurantContactAsync()
        {
            var company = await _repository.Restaurant.GetAllRestaurantAsync( trackChanges: false);
            if (company == null)
            {
                return NotFound();
            }
            var restaurantcontactFromDb = await _repository.RestaurantContact.GetAllRestaurantContactAsync( trackChanges: false);
            return Ok(restaurantcontactFromDb);
        }
        ////////////////////////////////////////// Get a Single Restaurant Contact For a Restaurant /////////////////////////////////////
        [HttpGet("{restaurantId}/contacts/{id}", Name = "RestaurantContactById")]
       
        public async  Task <IActionResult> GetRestaurantContactAsync(int restaurantId, int id)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {

                return NotFound();
            }
            var restaurantcontactDb = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantId, id, trackChanges:
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
        public async Task <IActionResult> CreateRestaurantContact(int restaurantId, [FromBody] RestaurantContactForCreationDto restaurantcontact)
        {
        /*resturatn = company 
        * resturantcontact = employee */     
            if (restaurantcontact == null)
            {
                return BadRequest("RestaurantContactForCreationDto object is null");
            }
            var restaurant = await  _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }
            var restaurantcontactEntity = _mapper.Map<RestaurantContact>(restaurantcontact);

            _repository.RestaurantContact.CreateRestaurantContact(restaurantId, restaurantcontactEntity);
            await _repository.SaveAsync();
            var restaurantcontactToReturn = _mapper.Map<RestaurantContactDto>(restaurantcontactEntity);
            return CreatedAtRoute("RestaurantContactById", new { restaurantId, id = restaurantcontactToReturn.RestaurantContactId  }, restaurantcontactToReturn);
        }
        //////////////////////////////////////////////////// Delete a Restaurant Contact ////////////////////////////////////////////////////////
        [HttpDelete("{restaurantId}/contacts/{RestaurantContactId}")]
        public async  Task<IActionResult> DeleteRestaurantContact(int restaurantId, int RestaurantContactId )
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
            return NotFound();
            }
            var restaurantContact = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantId, RestaurantContactId,
           trackChanges: false);
            if (restaurantContact == null)
            {
                return NotFound();
            }
            _repository.RestaurantContact.DeleteRestaurantContact(restaurantContact);
            await _repository.SaveAsync();
            return NoContent();
        }
        ///////////////////////////////////////////////// Update Restaurant Contact //////////////////////////////////
        [HttpPut("{restaurantId}/contacts/{restaurantContactId}")]
        public async   Task <IActionResult> UpdateRestaurantContact(int restaurantId, int restaurantContactId, [FromBody]
        RestaurantContactForUpdateDto restaurantcontact)
        {
            if (restaurantcontact == null)
            {
                return BadRequest("object is null");
            }
            var restaurant =await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
            return NotFound();
            }
            var restaurantcontactEntity = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantId, restaurantContactId, trackChanges : true);
            if (restaurantcontactEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(restaurantcontact, restaurantcontactEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}