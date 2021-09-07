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
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>();

            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();

            CreateMap<CustomerContact, CustomerContactDto>();
            CreateMap<CustomerContactForCreationDto, CustomerContact>();
            CreateMap<CustomerContactForUpdateDto, CustomerContact>();

            CreateMap<Meal, MealDto>();
            CreateMap<MealForCreationDto, Meal>();
            CreateMap<MealForUpdateDto, Meal>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();

            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<RestaurantForUpdateDto, Restaurant>();

            CreateMap<RestaurantContact, RestaurantContactDto>();
            CreateMap<RestaurantContactForCreationDto, RestaurantContact>();
            CreateMap<RestaurantContactForUpdateDto, RestaurantContact>();
        }
    }
}