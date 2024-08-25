using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFood.Models
{
    public class MenuItemModel
    {
        [Key]
        public int MenuItemId { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public RestaurantModel Restaurant { get; set; }
        public string Name  { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
        public string AvailabilityStatus { get; set; }
        
        
    }
}