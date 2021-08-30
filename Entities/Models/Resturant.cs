﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Resturant
    {
        [Required(ErrorMessage = "Resturant Id is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Id is 60 characters")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Resturant name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resturant Email is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Email is 60 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Resturant Password is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Password is 60 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Resturant Address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 characters")]
        public string Address { get; set; }

        public string Logo { get; set; }

        [Required(ErrorMessage = "Resturant AvgDeliveryTime is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the AvgDeliveryTime is 60 characters")]
        public int AvgDeliveryTime { get; set; }

        [Required(ErrorMessage = "Resturant MinPrice is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the MinPrice is 60 characters")]
        public int MinPrice { get; set; }

        [Required(ErrorMessage = "Resturant Taste is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Taste is 60 characters")]
        public int Taste { get; set; }

        [Required(ErrorMessage = "Resturant Speed is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Speed is 60 characters")]
        public int Speed { get; set; }

        [Required(ErrorMessage = "Resturant PrceForValue is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the PrceForValue is 60 characters")]
        public int PrceForValue { get; set; }

    }
}
