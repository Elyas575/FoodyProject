using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class MCMController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public MCMController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{restaurantId}/categories")]
        public async Task<IActionResult> GetAllCategoriesAsync(int restaurantId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {

                return NotFound();
            }

            var categoryFromDto = await _repository.Category.GetAllCategoriesAsync(restaurantId, trackChanges: false);

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categoryFromDto);

            return Ok(categoryDto);
        }

        [HttpGet("{restaurantId}/category/{categoryId}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryAsync(int restaurantId, int categoryId)
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

            var category = _mapper.Map<CategoryDto>(categoryDb);

            return Ok(category);
        }
        
        [HttpPost("{restaurantId}/Category")]
        public async Task<IActionResult> CreateCategory(int restaurantId, [FromBody] CategoryForCreationDto category)
        {
            if (category == null)
            {
                return BadRequest("CategoryForCreationDto object is null");
            }

            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreateCategory(restaurantId, categoryEntity);

            await _repository.SaveAsync();


            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return Ok(categoryToReturn);
        }

        [HttpDelete("{restaurantId}/category/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int restaurantId, int categoryId)
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

            _repository.Category.DeleteCategory(categoryDb);
            await _repository.SaveAsync();

            return NoContent();
        }


        [HttpGet("{restaurantId}/category/{categoryId}/meal")]
        public async Task<IActionResult> GetAllMealsAsync(int restaurantId, int categoryId)
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

            var mealFromDb = await _repository.Meal.GetAllMealsAsync(restaurantId, categoryId, trackChanges: false);

            var MealDto = _mapper.Map<IEnumerable<MealDto>>(mealFromDb);

            return Ok(mealFromDb);
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

        [HttpPost("{restaurantId}/category/{categoryId}/meal/{orderId}")]
        public async Task<IActionResult> CreateMealForCategory(int restaurantId, int categoryId, int orderId, [FromBody] MealForCreationDto meal)
        {
            var order = await _repository.Order.GetOrderAsync(orderId, trackChanges: false);
            if (order == null) {
                return BadRequest("orderforcreationdto object is null");

            }
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

            _repository.Meal.CreateMealForCategory(restaurantId, categoryId,orderId, mealEntity);

            await _repository.SaveAsync();

            var mealToReturn = _mapper.Map<MealDto>(mealEntity);

            return Ok(mealToReturn);
        }

        [HttpDelete("{restaurantId}/category/{categoryId}/meal/{mealId}")]
        public async Task<IActionResult> DeleteMealAsync(int restaurantId, int categoryId, int mealId)
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

            var mealDb = await _repository.Meal.GetMealAsync(restaurantId, categoryId, mealId, trackChanges: false);
            if (mealDb == null)
            {
                return NotFound();
            }

            _repository.Meal.DeleteMeal(mealDb);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}

/*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryForRestaurant(string restaurantId, string categoryId, [FromBody] CategoryForUpdateDto category)
        {
            if (category == null)
            {
                return BadRequest("CategoryForUpdateDto object is null");
            }
                return BadRequest("CategoryForUpdateDto object is null");
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string restaurantId, string categoryId)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var categoryDb = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: false);
            if (categoryDb == null)
            {
                return NotFound();
            }

            _repository.Category.DeleteCategory(categoryDb);
            await _repository.SaveAsync();


            return NoContent();
        }

*/



///////////////////////// Meal /////////////////////////


/*

       


       

        [HttpDelete("{Id}/meal/{Id}")]
        public IActionResult DeleteMeal(string restaurantId, string categoryId, string mealId)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            var mealDb = _repository.Meal.GetMeal(restaurantId, categoryId, mealId, trackChanges: false);
            if (mealDb == null)
            {
                return NotFound();
            }

            _repository.Meal.DeleteMeal(mealDb);
            _repository.Save();

            return NoContent();
        }


        [HttpPut("{Id}/meal/{Id}")]
        public IActionResult UpdateMealForCategory(string restaurantId, string categoryId, string mealId, [FromBody] MealForUpdateDto meal)
        {
            if (meal == null)
            {
                return BadRequest("CategoryForUpdateDto object is null");
            }

            var category = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: false);

            if (category == null)
            {
                return NotFound();
            }

            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);

            if (restaurant == null)
            {
                return NotFound();
            }

            var mealEntity = _repository.Meal.GetMeal(restaurantId, categoryId, mealId, trackChanges: true);

            if (mealEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(meal, mealEntity);
            _repository.Save();
            return NoContent();


        }
    }

}*/