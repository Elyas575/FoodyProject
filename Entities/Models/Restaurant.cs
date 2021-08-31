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
        
        public Guid RestaurantId { get; set; }

        [Required(ErrorMessage = "Resturant name is a required field.")]
        [MaxLength(75, ErrorMessage = "Maximum length for the Name is 75 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resturant Email is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Email is 60 characters.")]
        public string Email { get; set; }

     
        [MaxLength(60, ErrorMessage = "Maximum length for the Password is 60 characters.")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

   
     

        [Required(ErrorMessage = "Resturant Address is a required field.")]
        [MaxLength(200, ErrorMessage = "Maximum length for the Address is 200 characters")]
        public string Address { get; set; }

        public string Logo { get; set; }

        [Required(ErrorMessage = "Resturant AvgDeliveryTime is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the AvgDeliveryTime is 60 characters")]
        public int AvgDeliveryTime { get; set; }

        [Required(ErrorMessage = "Resturant MinPrice is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the MinPrice is 60 characters")]
        public int MinPrice { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<RestaurantContact> RestaurantContacts { get; set; }


    }
}
