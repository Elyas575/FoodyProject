using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Meal
    {
        [Required(ErrorMessage = "Meal Id is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Id is 60 characters")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Meal name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Meal Description is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Description is 60 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Meal Price is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Price is 60 characters.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Meal Picture is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the Picture is 60 characters.")]
        public string Picture { get; set; }
    }
}
