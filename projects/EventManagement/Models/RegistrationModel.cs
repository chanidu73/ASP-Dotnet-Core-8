using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Models
{
    public class RegistrationModel
    {
        public int RegisterationId { get;set; }
        [ForeignKey("Event")]
        public int EventId { get;set; }
        public EventModel Event { get;set; }
        [ForeignKey("User")]
        public int UserId { get;set; }
        public UserModel User { get; set; }
        public DateTime RegisterationDate { get ; set ; }
        
    }
}