using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("Post")]
        public int PostId{ get; set; }
        public PostModel Post { get;set; }
        [ForeignKey("User")]
        public int UserId { get;set; }
        public UserModel User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } =  DateTime.Now;
    }
}