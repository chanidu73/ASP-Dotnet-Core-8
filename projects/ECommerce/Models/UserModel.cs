using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Models
{
    public class UserModel :IdentityUser
    {
        public int UserId { get; set; }
        public string Name { get;set;}
        public string UserName { get; set; }
        public string PasswordHash {get; set; }
        public ICollection<OrderModel>Orders { get; set; }
        public ICollection<CartItemModel> CartItems { get; set; }
    }
}