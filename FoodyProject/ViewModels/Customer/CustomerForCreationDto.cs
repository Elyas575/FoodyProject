using System;
using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Customer
{
    public class CustomerForCreationDto : CustomerBase
    {
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "Employee's DOB Field is Required.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}