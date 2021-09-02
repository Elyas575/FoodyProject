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
    [Route("api/mcmcontroller")]
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
        public IActionResult GetAllCategories()
        {
            var categories = _repository.Category.GetAllCategories(trackChanges: false);

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return Ok(categoryDto);
        }

        [HttpGet("{id}", Name = "CategoryById")]
        public IActionResult GetCompany(Guid id)
        {
            var company = _repository.Category.GetCategory(id, trackChanges: false);
            
                var companyDto = _mapper.Map<CategoryDto>(company);

                return Ok(companyDto);
            
        }


        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryForCreationDto category)
        {
            var categoryEntity = _mapper.Map<Category>(category);
            _repository.Category.CreatCategory(categoryEntity);
            _repository.Save();

            var categoryToReturn = _mapper.Map<CategoryDto>(categoryEntity);

            return CreatedAtRoute("CategoryById", new { id = categoryToReturn.CategoryId }, categoryToReturn);
        }

    }
}
