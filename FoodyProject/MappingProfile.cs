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
            CreateMap<Order, OrderDto>();

            CreateMap<CustomerContactDto, Customer>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<RestaurantContactForCreationDto, RestaurantContact>();
            CreateMap<RestaurantContact, RestaurantContactDto>();
            
            CreateMap<Meal, MealDto>();
            CreateMap<MealForCreationDto, Meal>();

            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<Category, CategoryDto>();

            CreateMap<Meal, MealDto>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<RestaurantContactForUpdateDto, RestaurantContact>();
        }
    }
}