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
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<RestaurantForUpdateDto, Restaurant>();

            CreateMap<CustomerForCreationDto, Customer>();

            
            CreateMap<Restaurant, RestaurantDto>();



            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Order, OrderDto>();
           
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<Category, CategoryDto>();

           CreateMap<RestaurantContactForCreationDto, RestaurantContact>();
           CreateMap<RestaurantContact, RestaurantContactDto>();

            CreateMap<Meal, MealDto>();
            CreateMap<CategoryForUpdateDto, Category>();

           


            CreateMap<RestaurantContactForUpdateDto, RestaurantContact>();












        }
    }
}

 

