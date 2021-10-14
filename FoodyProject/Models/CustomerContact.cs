using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.Models
{
    public class CustomerContact
    {
        [Key]
        public int Id { get; set; }

        [ReadOnly(true)]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Country Field is Required.")]
        public string Country { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "City Field is Required.")]
        public string City { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Street Field is Required.")]
        public string Street { get; set; }

        [StringLength(50, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Building Field is Required.")]
        public string Building { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}