using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class FriendRequestModel
    {
        [Key]
        public int RequestId { get; set; }
        [ForeignKey("User")]
        public int SenderId { get; set; }
        public UserModel User { get; set; }
        [ForeignKey("Receiver")]
        public int ReceiverId { get; set; }
        public UserModel Receiver { get; set; }
        public string Status { get; set; }
        public DateTime SentDate{ get; set; }

        
    }
}