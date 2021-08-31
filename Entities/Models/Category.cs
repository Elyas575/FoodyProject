using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Category
    {
        [Column("CategoryId")]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public Guid RestaurantId { get; set; }
        public Restaurant Restaurants { get; set; }
        public ICollection<Meal> Meals { get; set; }

    }
}
