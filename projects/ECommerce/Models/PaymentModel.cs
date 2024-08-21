using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymetnId { get; set; }
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}