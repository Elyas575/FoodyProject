using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodyProject.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Restaurant's Name Field is Required.")]
        [StringLength(40, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Restaurant's EmailAddress Field is Required.")]
        [StringLength(50, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characteers.")]
        [RegularExpression(@"^([\w_\-\.]+)@([\w_\-\.]+)\.(([\w]{2,4})+)", ErrorMessage = "You are Not Allowed to Use any Symbol Character Other Than These ( '.' , '-' , and '_')")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password Field is Required")]
        [MinLength(8, ErrorMessage = "Password Can't be less than 8 Characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

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

        [ReadOnly(true)]
        public string Location { get; set; }

        [StringLength(30, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Latitude Field is Required.")]
        public string Latitude { get; set; }

        [StringLength(30, ErrorMessage = "{0} Field Can't Exceed {1} Characters.")]
        [Required(ErrorMessage = "Longitude Field is Required.")]
        public string Longitude { get; set; }

        [Required(ErrorMessage = "Restaurant's Status Field is Required.")]
        [StringLength(25, ErrorMessage = "Restaurant's {0} Field Can't Exceed {1} Characters.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Resturant's AvgDeliveryTime Field is Required.")]
        [Range(typeof(int), "0", "21000", ErrorMessage = "Resturant's {0} Can't be less than {1}.")]
        public int AvgDeliveryTime { get; set; }

        [Required(ErrorMessage = "Restaurant's MinPrice Field is Required.")]
        [Column(TypeName = "decimal(18,2")]
        [Range(typeof(decimal), "0", "2000", ErrorMessage = "Restaurant's {0} Can't be less than {1}")]
        public decimal MinPrice { get; set; }

        [Range(0.0, 10.0, ErrorMessage = "Restaurant's Rate Should be between 0.0 and 10.0.")]
        public float Rate { get; set; }

        public string Cuisine { get; set; }
        public bool IsDelete { get; set; }
        public string Logo { get; set; }
        public string Note { get; set; }
        
        public ICollection<Order> Orders { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<RestaurantContact> RestaurantContacts { get; set; }
    }
}