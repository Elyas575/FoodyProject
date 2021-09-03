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
    [Route("api/categorycontroller")]
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
        
                [HttpGet("{id}", Name = "CategoryById")]
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
                public IActionResult CreateCategory(Guid restaurantId,[FromBody] CategoryForCreationDto category)
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

                    return CreatedAtRoute("CategoryById", new { id = categoryToReturn.CategoryId }, categoryToReturn);
                }
        /*
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var category = HttpContext.Items["category"] as Category;


            _repository.Category.DeleteCategory(category);

            _repository.Save();

            return NoContent();
        }


        ///////////////////////// Meal /////////////////////////
        
        
        [HttpGet("meal/{Id}")]
        public IActionResult GetAllMeals(Guid categoryId)
               {
                   var category = _repository.Category.GetCategory(categoryId, trackChanges: false);

                   if (category == null)
                   {
                       return NotFound();
                   }

                   var mealFromDb = _repository.Meal.GetAllMeals(categoryId, trackChanges: false);

                   var MealDto = _mapper.Map<IEnumerable<MealDto>>(mealFromDb);

                   return Ok(MealDto);
               }


               [HttpGet("{id}", Name = "GetMealForCategory")]
               public IActionResult GetMeal(Guid categoryId, Guid id)
               {
                   var category = _repository.Category.GetCategory(categoryId, trackChanges: false);

                   if (category == null)
                   {
                       return NotFound();
                   }

                   var MealDb = _repository.Meal.GetMeal(categoryId, id, trackChanges: false);

                   if (MealDb == null)
                   {
                       return NotFound();
                   }

                   var meal = _mapper.Map<MealDto>(MealDb);

                   return Ok(meal);
               }


               [HttpPost]
               public IActionResult CreateMealForCategory(Guid categoryId, [FromBody] MealForCreationDto meal)
               {
                   if (meal == null)
                   {
                       return BadRequest("EmployeeForCreationDto object is null");
                   }
                   var category = _repository.Category.GetCategory(categoryId, trackChanges: false);
                   if (category == null)
                   {

                   return NotFound();
                   }
                   var mealEntity = _mapper.Map<Meal>(meal);

                   _repository.Meal.CreateMealForCategory(categoryId, mealEntity);
                   _repository.Save();


                   var mealToReturn = _mapper.Map<MealDto>(mealEntity);
                   return CreatedAtRoute("GetMealForCategory", new
                   {
                       categoryId,
                       id = mealToReturn.MealId
                   },
                   mealToReturn);
               }
       */
    }
}
