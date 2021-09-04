using Contracts;
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
    [Route("api/restaurant/{restaurantId}/category")]
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


        [HttpGet]
        public IActionResult GetAllCategories(Guid restaurantId)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {

                return NotFound();
            }

            var categoryFromDto = _repository.Category.GetAllCategories(restaurantId, trackChanges: false);

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categoryFromDto);

            return Ok(categoryDto);
        }

        [HttpGet("{Id}", Name = "CategoryById")]
        public IActionResult GetCategory(Guid restauratnId, Guid categoryId)
        {
            var restaurant = _repository.Restaurant.GetRestaurant(restauratnId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }
            var categoryDb = _repository.Category.GetCategory(restauratnId, categoryId, trackChanges: false);
            if (categoryDb == null)
            {
                return NotFound();
            }

            var category = _mapper.Map<CategoryDto>(categoryDb);

            return Ok(category);

        }


        [HttpPost]
        public IActionResult CreateCategory(Guid restaurantId, [FromBody] CategoryForCreationDto category)
        {
            if (category == null)
            {
                return BadRequest("CategoryForCreationDto object is null");
            }

            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var categoryEntity = _mapper.Map<Category>(category);

            _repository.Category.CreatCategory(restaurantId, categoryEntity);

            _repository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("CategoryById", new { restaurantId, id = categoryToReturn.CategoryId }, categoryToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid restaurantId, Guid categoryId)
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
            _repository.Save();

            return NoContent();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCategoryForRestaurant(Guid restaurantId, Guid categoryId, [FromBody] CategoryForUpdateDto category)
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
            _repository.Save();
            return NoContent();
        }
        

        

                                             ///////////////////////// Meal /////////////////////////

        /*

        [HttpGet("{Id}/meal")]
        public IActionResult GetAllMeals(Guid restaurantId, Guid categoryId)
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

            var mealFromDb = _repository.Meal.GetAllMeals(restaurantId, categoryId, trackChanges: false);

            var MealDto = _mapper.Map<IEnumerable<MealDto>>(mealFromDb);

            return Ok(MealDto);
        }

        [HttpGet("{Id}/meal/{Id}", Name = "GetMealForCategory")]
        public IActionResult GetMeal(Guid restaurantId, Guid categoryId, Guid mealId)
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

            var MealDb = _repository.Meal.GetMeal(restaurantId, categoryId, mealId, trackChanges: false);

            if (MealDb == null)
            {
                return NotFound();
            }

            var meal = _mapper.Map<MealDto>(MealDb);

            return Ok(meal);
        }


        [HttpPost("{Id}/meal")]
        public IActionResult CreateMealForCategory(Guid restaurantId, Guid categorytId, [FromBody] MealForCreationDto meal)
        {
            if (meal == null)
            {
                return BadRequest("MealForCreationDto object is null");
            }

            var restaurant = _repository.Restaurant.GetRestaurant(restaurantId, trackChanges: false);
            if (restaurant == null)
            {
                return NotFound();
            }

            var category = _repository.Category.GetCategory(restaurantId, categorytId, trackChanges: false);
            if (category == null)
            {
                return NotFound();
            }

            var mealEntity = _mapper.Map<Meal>(meal);

            _repository.Meal.CreateMealForCategory(categorytId, mealEntity);

            _repository.Save();

            var mealToReturn = _mapper.Map<MealDto>(mealEntity);

            return CreatedAtRoute("GetMealForCategory", new { categorytId, mealId = mealEntity.MealId }, mealToReturn);
        }


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


        [HttpPut("{Id}/meal/{Id}")]
        public IActionResult UpdateMealForCategory(Guid restaurantId, Guid categoryId, Guid mealId, [FromBody] MealForUpdateDto meal)
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


        } */
    }
}