using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.Models
{
    public class RestaurantContact
    {
        [Key]
        public int Id { get; set; }

        [Phone]
        [StringLength(20, ErrorMessage = "Restaurant's {0} Number Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Restaurant's Phone Number Field is Required.")]
        public string Phone { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
    }
}