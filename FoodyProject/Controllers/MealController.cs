﻿using AutoMapper;
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

        [HttpPost("{restaurantId}/category/{categoryId}/meal/{orderid}")]
        public async Task<IActionResult> CreateMealForCategory(int restaurantId, int categoryId,  [FromBody] MealForCreationDto meal)
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

            _repository.Meal.CreateMealForCategory(restaurantId, categoryId, mealEntity);

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

            _repository.Category.DeleteCategory(categoryDb);
            await _repository.SaveAsync();


            return NoContent();
        }

*/



///////////////////////// Meal /////////////////////////


/*

            _repository.Meal.CreateMealForCategory(categorytId, mealEntity);

            _repository.Save();


       

        [HttpDelete("{Id}/meal/{Id}")]
        public IActionResult DeleteMeal(string restaurantId, string categoryId, string mealId)
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


        //[HttpDelete("{Id}/meal/{Id}")]
        //public IActionResult DeleteMeal(Guid restaurantId, Guid categoryId, Guid mealId)
        //{
        //    var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        [HttpPut("{Id}/meal/{Id}")]
        public IActionResult UpdateMealForCategory(string restaurantId, string categoryId, string mealId, [FromBody] MealForUpdateDto meal)
        {
            if (category == null)
            {
                return BadRequest("CategoryForUpdateDto object is null");
            }
                return BadRequest("CategoryForUpdateDto object is null");
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid restaurantId, Guid categoryId)
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
        public IActionResult DeleteMeal(Guid restaurantId, Guid categoryId, Guid mealId)
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


        
    }

*/