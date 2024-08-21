using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class CartItemModel
    {
        [Key]
        public int CartItemId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("UserId")]
        
        public int UserId { get; set; }
        public UserModel User { get; set; }

    }
}