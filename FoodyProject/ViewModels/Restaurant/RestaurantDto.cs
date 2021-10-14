using FoodyProject.ViewModels.RestaurantContact;
using System.Collections.Generic;

namespace FoodyProject.ViewModels.Restaurant
{
    public class RestaurantDto : RestaurantBase
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public float Rate { get; set; }

        public ICollection<RestaurantContactDto> RestaurantContacts { get; set; }
    }
}