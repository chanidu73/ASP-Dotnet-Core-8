using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnlineFood.Models
{
    public class RestaurantModel
    {
        [Key]
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string ContactInfomations { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }
        public UserModel Owner { get; set; }
        public int OpeningHours { get; set; }

        public ICollection<MenuItemModel> MenuItems { get; set; }
        public ICollection<OrderModel>Orders { get; set; }
    }
}