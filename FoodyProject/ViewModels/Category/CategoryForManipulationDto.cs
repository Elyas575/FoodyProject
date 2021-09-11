using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FoodyProject.ViewModels.Category
{
    public abstract class CategoryForManipulationDto
    {
        [Required(ErrorMessage = "Category name is a required field.")]
        [MaxLength(30, ErrorMessage = "Max length for category name is 30 characters.")]
        public string CategoryName { get; set; }
    }
}
