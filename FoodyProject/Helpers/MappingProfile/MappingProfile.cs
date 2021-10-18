using AutoMapper;
using FoodyProject.Models;
using FoodyProject.ViewModels.Category;
using FoodyProject.ViewModels.Customer;
using FoodyProject.ViewModels.CustomerContact;
using FoodyProject.ViewModels.Meal;
using FoodyProject.ViewModels.Order;
using FoodyProject.ViewModels.Restaurant;
using FoodyProject.ViewModels.RestaurantContact;

namespace FoodyProject.Helpers.MappingProfile
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

            CreateMap<CustomerContact, CustomerContactDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Country + ", " + src.City + ", " + src.Street + ", " + src.Building));
            CreateMap<CustomerContactForCreationDto, CustomerContact>();
            CreateMap<CustomerContactForUpdateDto, CustomerContact>();

            CreateMap<Meal, MealDto>();
            CreateMap<MealForCreationDto, Meal>();
            CreateMap<MealForUpdateDto, Meal>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<OrderForUpdateDto, Order>();

            CreateMap<Restaurant, RestaurantDto>()
                .ForMember( dest => dest.Location , opt => opt.MapFrom(src=>src.Latitude+", "+src.Longitude))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Country + ", " + src.City + ", " + src.Street + ", " + src.Building));
            CreateMap<RestaurantContact, RestaurantDto>();
            CreateMap<RestaurantForCreationDto, Restaurant>();
            CreateMap<RestaurantForUpdateDto, Restaurant>();

            CreateMap<RestaurantContact, RestaurantContactDto>();
            CreateMap<RestaurantContactForCreationDto, RestaurantContact>();
            CreateMap<RestaurantContactForUpdateDto, RestaurantContact>();
        }
    }
}