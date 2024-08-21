using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class OrderItemModel
    {
        [Key]
        public int OrderItemId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public int Quantity { get ;set; }
        public decimal Price { get; set; }  
    }
}