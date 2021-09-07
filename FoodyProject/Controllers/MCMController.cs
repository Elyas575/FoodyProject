﻿using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using AutoMapper;
using Entities.Models;

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
        public async Task<IActionResult> GetAllCategoriesAsync(Guid restaurantId)
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

        [HttpGet("{restauratnId}/category/{categoryId}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryAsync(Guid restauratnId, Guid categoryId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restauratnId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }
            var categoryDb = await _repository.Category.GetCategoryAsync(restauratnId, categoryId, trackChanges: false);
            if (categoryDb == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryDto>(categoryDb);

            return Ok(category);

        }




        [HttpPost("{restaurantId}/Category")]
        public async Task<IActionResult> CreateCategory(Guid restaurantId, [FromBody] CategoryForCreationDto category)
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

        [HttpGet("{restaurantId}/meal")]
        public async Task<IActionResult> GetAllMealsAsync(Guid restaurantId, Guid categoryId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }
            var categoryDb = _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: false);
            if (categoryDb == null)
            {
                return NotFound();
            }

            var mealFromDb = _repository.Meal.GetAllMealsAsync(restaurantId, categoryId, trackChanges: false);

            var MealDto = _mapper.Map<IEnumerable<MealDto>>(mealFromDb);

            return Ok(MealDto);
        }

        [HttpGet("{restaurantId}/{categoryId}/{mealId}", Name = "GetMealForCategory")]
        public async Task<IActionResult> GetMealAsync(Guid restaurantId, Guid categoryId, Guid mealId)
        {
            var restaurant = await _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: false);

            if (category == null)
            {
                return NotFound();
            }

            var MealDb = _repository.Meal.GetMealAsync(restaurantId, categoryId, mealId, trackChanges: false);

            if (MealDb == null)
            {
                return NotFound();
            }

            var meal = _mapper.Map<MealDto>(MealDb);

            return Ok(meal);
        }


        [HttpPost("{restaurantId}/{categorytId}")]
        public async Task<IActionResult> CreateMealForCategoryAsync(Guid restaurantId, Guid categorytId, [FromBody] MealForCreationDto meal)
        {
            if (meal == null)
            {
                return BadRequest("MealForCreationDto object is null");
            }

            var restaurant = _repository.Restaurant.GetRestaurantAsync(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = _repository.Category.GetCategoryAsync(restaurantId, categorytId, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            var mealEntity = _mapper.Map<Meal>(meal);

            _repository.Meal.CreateMealForCategory(categorytId, mealEntity);

            await _repository.SaveAsync();

            var mealToReturn = _mapper.Map<MealDto>(mealEntity);


            return CreatedAtRoute("GetMealForCategory", new { categorytId, mealId = mealEntity.MealId }, mealToReturn);
        }


        //[HttpDelete("{Id}/meal/{Id}")]
        //public IActionResult DeleteMeal(Guid restaurantId, Guid categoryId, Guid mealId)
        //{
        //    var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    var category = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: false);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    var mealDb = _repository.Meal.GetMeal(restaurantId, categoryId, mealId, trackChanges: false);
        //    if (mealDb == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.Meal.DeleteMeal(mealDb);
        //    _repository.Save();

        //    return NoContent();
        //}


        //[HttpPut("{Id}/meal/{Id}")]
        //public IActionResult UpdateMealForCategory(Guid restaurantId, Guid categoryId, Guid mealId, [FromBody] MealForUpdateDto meal)
        //{
        //    if (meal == null)
        //    {
        //        return BadRequest("CategoryForUpdateDto object is null");
        //    }

        //    var category = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: false);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);

        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    var mealEntity = _repository.Meal.GetMeal(restaurantId, categoryId, mealId, trackChanges: true);

        //    if (mealEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    _mapper.Map(meal, mealEntity);
        //    _repository.Save();
        //    return NoContent();


        //}
    }
}

        

      /*  [HttpDelete("{id}")]
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


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryForRestaurant(Guid restaurantId, Guid categoryId, [FromBody] CategoryForUpdateDto category)
        {
            if (category == null)
            {
                return BadRequest("CategoryForUpdateDto object is null");
            }

            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);

            if (restaurant == null)
            {
                return NotFound();
            }

            var categoryEntity = _repository.Category.GetCategory(restaurantId, categoryId, trackChanges: true);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(category, categoryEntity);
            await _repository.SaveAsync();

            return NoContent();
        } 
    } 
}
       */ 

        ///////////////////////// Meal /////////////////////////

        

       
    

