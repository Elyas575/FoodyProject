using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using FoodyProject.ActionFilters;
using FoodyProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/restaurant")]
   // [ApiController]
    public class RestuarantController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public RestuarantController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // get all reataurants 
        [HttpGet]
        public async Task<IActionResult> GetAllRestaurant()
        {
            var restaurants = await _repository.Restaurant.GetAllRestaurantAsync(trackChanges: false);
            var restaurantDto = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
            return Ok(restaurantDto);
        }

        // get restaurant by id 
        [HttpGet("{restaurantId}", Name = "RestaurantById")]
        public async Task<IActionResult> GetRestaurantByIdAsync(int restaurantId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);
        }

        //get restaurant by name
        [HttpGet("name/{name}", Name = "name")]
        public async Task<IActionResult> GetRestaurantByNameAsync(string name)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantByNameAsync(name, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);
        }
        
        //get restaurant by city 
        [HttpGet("city/{city}", Name = "city")]
        public async Task<IActionResult> GetRestaurantByCityAsync(string city )
        {
            var restaurant = await _repository.Restaurant.GetRestaurantByCityAsync(city, trackChanges : false);
            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);

        }
        
       
        //get the best restaurant 
        [HttpGet("best")]
        public async Task<IActionResult> GetBestRestaurantAsync()
        {
            var restaurants = await _repository.Restaurant.GetBestRestaurantAsync(trackChanges: false);
            var maxRate = restaurants.ToArray().Max();

            var restaurantDto = _mapper.Map<IEnumerable<RestaurantDto>>(maxRate);
            return Ok(restaurantDto);
        }

        //create a restaurant 
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

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
            return Ok(restaurantToReturn);
        }

        // update restaurant
        [HttpPut("{restaurantId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

        public async Task<IActionResult> UpdateRestaurant(int restaurantId, [FromBody] RestaurantForUpdateDto restaurant)
        {

            var restaurantEntity = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: true);

            if (restaurant == null)
            {
                return BadRequest("RestaurantDto object is null");
            }

            if (restaurantEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(restaurant, restaurantEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        //delete restaurant 
        [HttpDelete("{restaurantId}")]
        [ServiceFilter(typeof(ValidateRestaurantExistsAttribute))]

        public async Task<IActionResult> DeleteRestaurant(int restaurantId)
        {
            var restaurant = HttpContext.Items["restaurant"] as Restaurant;

            _repository.Restaurant.DeleteRestaurant(restaurant);
            await _repository.SaveAsync();
            return NoContent();
        }

        //Get all restaurant contacts 
        [HttpGet("contacts")]
        public async Task<IActionResult> GetAllRestaurantsContactsAsync()
        {
            var company = await _repository.Restaurant.GetAllRestaurantAsync( trackChanges: false);
            if (company == null)
            {
                return NotFound();
            }
            var restaurantcontactFromDb = await _repository.RestaurantContact.GetAllRestaurantsContactsAsync( trackChanges: false);
            return Ok(restaurantcontactFromDb);
        }

        // Get all contacts for a restaurant 

        [HttpGet("{restaurantId}/restaurantContacts")]
        public async Task <IActionResult> GetAllContactsForRestaurantAsync(int restaurantId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantContactFromDb = await _repository.RestaurantContact.GetAllContactsForRestaurantAsync(restaurantId, trackChanges: false);
            var restaurantDto = _mapper.Map<IEnumerable<RestaurantContactDto>>(restaurantContactFromDb);

            return Ok(restaurantDto);
        }

        // Get a single restaurant contact
        [HttpGet("{restaurantId}/contacts/{restaurantContactId}", Name = "RestaurantContactById")]
        public async Task <IActionResult> GetRestaurantContactAsync(int restaurantId, int restaurantContactId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var restaurantcontactDb = await _repository.RestaurantContact.GetRestaurantContactAsync(restaurantId, restaurantContactId, trackChanges:false);
            if (restaurantcontactDb == null)
            {
                return NotFound();
            } 

            var restaurantcontact = _mapper.Map<RestaurantContactDto>(restaurantcontactDb);
            return Ok(restaurantcontact);
        }

        // create restaurant contact 
        [HttpPost("{restaurantId}/RestaurantContact")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]

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
            return Ok(restaurantcontactToReturn);
        }

        //update restaurant contact 
        [HttpPut("{restaurantId}/contacts/{restaurantContactId}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateRestaurantContactExistsAttribute))]


        public async Task <IActionResult> UpdateRestaurantContact(int restaurantId, int restaurantContactId, [FromBody]
        RestaurantContactForUpdateDto restaurantcontact)
        {
            if (restaurantcontact == null)
            {
                return BadRequest("object is null");
            }

            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId,  trackChanges: true);

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

        // delete restaurant contact 
        [HttpDelete("{restaurantId}/contacts/{RestaurantContactId}")]
        [ServiceFilter(typeof(ValidateRestaurantContactExistsAttribute))]

        public async Task<IActionResult> DeleteRestaurantContact(int restaurantId, int RestaurantContactId)
        {
            var restaurantcontact = HttpContext.Items["restaurantcontact"] as RestaurantContact;
            if (restaurantcontact == null)
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
    }
}