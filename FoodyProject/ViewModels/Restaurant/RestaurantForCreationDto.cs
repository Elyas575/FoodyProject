using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class RestaurantForCreationDto
    {
       

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


        [Required(ErrorMessage = "Resturant Logo is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Logo is 60 characters")]
        public string Logo { get; set; }


        [Required(ErrorMessage = "Resturant AvgDeliveryTime is a required field.")]
        public int AvgDeliveryTime { get; set; }



        [Required(ErrorMessage = "Resturant MinPrice is a required field.")]

        public float MinPrice { get; set; }


        [Required(ErrorMessage = "Resturant country is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Country is 60 characters")]
        public string Country { get; set; }


        [Required(ErrorMessage = "Resturant city  is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the city is 60 characters")]
        public string City { get; set; }


        [Required(ErrorMessage = "Resturant Street  is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Street is 60 characters")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Resturant WorkingHours  is a required field.")]
        public DateTime WorkingHours { get; set; }


        [Required(ErrorMessage = "Resturant Street  is a required field.")]
        public bool Status { get; set; }


        public string Note { get; set; }





        public int Rate { get; set; }


    }
}