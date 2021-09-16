﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Customer name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is a required field")]
        [MinLength(8, ErrorMessage = "minimun length for password is 8 charchters ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Phone]
        [Required(ErrorMessage = "Phone number is a required field")]
        [MaxLength(15, ErrorMessage = "Maximum length for the PhoneNumber is 15 characters.")]
        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ICollection<CustomerContact> CustomerContacts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}