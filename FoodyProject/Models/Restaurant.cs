using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required(ErrorMessage = "Resturant name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resturant Email is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
        [EmailAddress]
        public string Email { get; set; }
     
        [MinLength(8, ErrorMessage = "Minimum length for the Password is 8 characters.")]
        [Required(ErrorMessage = "Password is a required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Country is 50 characters")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Resturant city  is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the city is 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Resturant city  is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Area is 50 characters")]
        public string Area { get; set; }

        [Required(ErrorMessage = "Resturant Street  is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Street is 60 characters")]
        public string Street { get; set; }

        [MaxLength(120, ErrorMessage = "Maximum length for the Location is 120 characters")]
        public string Location { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Latitude is 60 characters")]
        public string Latitude { get; set; }

        [MaxLength(60, ErrorMessage = "Maximum length for the Longitude is 60 characters")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Resturant Street  is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Status is 50 characters")]
        public string Status { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum length for the Logo is 100 characters")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Resturant AvgDeliveryTime is a required field.")]
        public int AvgDeliveryTime { get; set; }

        [Range(0.1, float.MaxValue, ErrorMessage = "Price is required and it can't be lower than 0.1")]
        public float MinPrice { get; set; }
       
        public string AvailablePaymentMethods { get; set; }
        public string Cuisine { get; set; }
        public string Note { get; set; }
        public bool IsDelete { get; set; }
        public float Rate { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<RestaurantContact> RestaurantContacts { get; set; }
    }
}