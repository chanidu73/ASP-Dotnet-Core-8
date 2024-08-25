using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class LikeModel
    {
        public int LikeId { get ;set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserModel User {get; set ;}
        public DateTime CreatedDate { get; set; }
        
    }
}