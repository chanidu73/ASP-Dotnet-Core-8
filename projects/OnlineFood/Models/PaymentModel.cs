using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFood.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId{ get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
        public string PaymentMethod { get ;set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public int TransactionId { get; set; }
        
    }
}