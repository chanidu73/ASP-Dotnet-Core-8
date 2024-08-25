using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFood.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User { get;set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public RestaurantModel Restaurant { get; set;}

        [ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        public MenuItemModel MenuItem { get; set;}
        public DateTime OrderDateTime { get; set; }
        public string OrderStatus { get; set ;}
        public decimal TotalAmount { get ;set; }
        public string PaymentStatus { get; set; }
        public PaymentModel Payment { get; set; }
        public DeliveryModel Delivery { get; set; }
        public string DeliveryAddress { get; set; }

        public ICollection<OrderItemModel> OrderItems { get; set; }


        
    }
}