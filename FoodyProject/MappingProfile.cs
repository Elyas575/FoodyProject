using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodyProject
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
            {

        CreateMap<RestuarantForCreationDto, Restaurant>();



            }

       
    }
}
