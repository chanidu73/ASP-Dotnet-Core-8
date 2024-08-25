using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFood.Models
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set ; }
        [ForeignKey("Order")]
        public int OrderId { get; set ;}
        public OrderModel Order { get; set; }
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public MenuItemModel Menu { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        
    }
}