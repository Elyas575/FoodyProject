﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;

namespace FoodyProject.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public CategoryController(IRepositoryManager repository, IMapper mapper)
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

        [HttpPost("{restaurantId}/category")]
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

        [HttpPut("{restaurantId}/category/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int restaurantId, int categoryId,  [FromBody] CategoryForUpdateDto category)
        {
            if (category == null)
            {
                return BadRequest("CompanyForUpdateDto object is null");
            }
            var categoryEntity = await _repository.Category.GetCategoryAsync(restaurantId, categoryId, trackChanges: true);
            if (categoryEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(category, categoryEntity);
            await _repository.SaveAsync();
            return NoContent();
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
    }
}
