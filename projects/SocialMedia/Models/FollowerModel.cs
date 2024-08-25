using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class FollowerModel
    {
        [Key]
        public int FollowerId { get;set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string User { get ;set; }
        // [ForeignKey("Following")]
        // public string FollowingId { get; set; } // use UserId Instead of followingId 
        // public UserModel Following { get; set; }

    }
}