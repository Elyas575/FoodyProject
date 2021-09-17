using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using FoodyProject.ActionFilters;
using FoodyProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MealController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{restaurantId}/category/{categoryId}/meal")]
        public async Task<IActionResult> GetAllMealsAsync(int restaurantId, int categoryId, [FromQuery] MealParameters mealParameters)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var categoryDb = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: false);
            if (categoryDb == null)
            {
                return NotFound();
            }

            var mealFromDb = await _repository.Meal.GetAllMealsAsync(restaurantId, categoryId, mealParameters, trackChanges: false);
            Response.Headers.Add("X-Paganation", JsonConvert.SerializeObject(mealFromDb.MetaData));
            var MealDto = _mapper.Map<IEnumerable<MealDto>>(mealFromDb);

            return Ok(MealDto);
        }

        [HttpGet("{restaurantId}/category/{categoryId}/meal/{mealId}", Name = "GetMealForCategory")]
        public async Task<IActionResult> GetMealAsync(int restaurantId, int categoryId, int mealId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            var MealDb = await _repository.Meal.GetMealAsync(restaurantId, categoryId, mealId, trackChanges: false);
            if (MealDb == null)
            {
                return NotFound();
            }

            var meal = _mapper.Map<MealDto>(MealDb);

            return Ok(meal);
        }

        [HttpPost("{restaurantId}/category/{categoryId}/meal")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMealForCategory(int restaurantId, int categoryId, [FromBody] MealForCreationDto meal)
        {

            if (meal == null)
            {
                return BadRequest("MealForCreationDto object is null");
            }

            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            var mealEntity = _mapper.Map<Meal>(meal);
            mealEntity.CategoryId = category.CategoryId;

            _repository.Meal.CreateMealForCategory(restaurantId, categoryId, mealEntity);
            await _repository.SaveAsync();

            var mealToReturn = _mapper.Map<MealDto>(mealEntity);

            return Ok(mealToReturn);
        }

        [HttpPut("customers/{restaurantid}/{categoryid}/{mealid}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateMealForCategoryExistsAttribute))]
        public async Task<IActionResult> UpdateMealForCategory(int categoryid, int mealid, int restaurantid, [FromBody] MealForUpdateDto meal)
        {
            var mealentity = HttpContext.Items["meal"] as Meal;
            _mapper.Map(meal, mealentity);
            await _repository.SaveAsync();
            
            return NoContent();
        }

        [HttpDelete("{restaurantId}/category/{categoryId}/meal/{mealId}")]
        [ServiceFilter(typeof(ValidateMealForCategoryExistsAttribute))]
        public async Task<IActionResult> DeleteMealAsync(int restaurantId, int categoryId, int mealId)
        {
            var mealDb = HttpContext.Items["meal"] as Meal;
            _repository.Meal.DeleteMeal(mealDb);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
