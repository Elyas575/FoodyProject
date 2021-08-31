using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }
        
        
        [Required(ErrorMessage = "Category name is a required field")]
        public string CategoryName { get; set; }

    }
}
