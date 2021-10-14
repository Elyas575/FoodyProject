using System.ComponentModel.DataAnnotations;

namespace FoodyProject.ViewModels.Category
{
    public abstract class CategoryBase
    {
        [Required(ErrorMessage = "Category's Name Field is Required.")]
        [StringLength(30, ErrorMessage = "Category's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }
    }
}
