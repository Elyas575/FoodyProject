using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

          
        public CustomerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _repository.Customer.GetAllCustomers(trackChanges: false);
            var companiesDto = _mapper.Map<IEnumerable<CustomerDto>>(companies);
            return Ok(companiesDto);
        }


    }

    }
