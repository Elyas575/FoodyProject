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
    [Route("api/Restuarant")] 
    [ApiController]
    public class RestuarantController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;


        public RestuarantController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }




      



    }

}
