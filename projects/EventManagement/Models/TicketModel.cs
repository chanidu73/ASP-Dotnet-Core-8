using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Models
{
    public class TicketModel
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public EventModel Event { get; set; }
        [ForeignKey("User")]
        public int UserId { get;set ; }
        public UserModel User { get; set; }
        public DateTime BookingDate { get; set; }
        public int TicketNumber { get; set; }
        public int Price { get; set; } 



    }
}