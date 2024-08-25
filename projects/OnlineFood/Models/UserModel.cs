using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnlineFood.Models
{
    public class UserModel :IdentityUser
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserRole { get; set; }

        public ICollection<OrderModel> Orders { get; set; }
        public ICollection<RestaurantModel> Restaurants { get; set; }
        public ICollection<DeliveryModel> Deliveries { get; set; }
        
        
    }
}