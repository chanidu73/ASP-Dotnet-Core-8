using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EventManagement.Models
{
    public class EventModel
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set ;}
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get;set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<RegistrationModel>Registrations { get; set; }
        public ICollection<TicketModel>Tickets { get; set; }
        
    }
}