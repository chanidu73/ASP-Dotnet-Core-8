using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFood.Models
{
    public class DeliveryModel
    {
        [Key]
        public int DeliveryId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get ;set ;}
        public OrderModel Order { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        public string DeliveryStatus { get; set; }
        [ForeignKey("DeliveryPerson")]
        public int DeliveryPersonId { get; set; }
        public UserModel DeliveryPerson { get; set; }
        
        
    }
}