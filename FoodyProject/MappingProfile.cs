﻿using AutoMapper;
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
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<OrderForCreationDto, Order>();



        }
    }
}

 

