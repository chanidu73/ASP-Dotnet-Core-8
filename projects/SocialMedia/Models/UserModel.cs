using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SocialMedia.Models
{
    public class UserModel:IdentityUser
    {
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set ;}
        public string ProfileImageUrl { get; set; }
        public string Bio { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<PostModel> Posts { get; set; }
        public ICollection<FollowerModel> Followers { get; set; }
        // public ICollection<FollowerModel> Following { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<LikeModel> Likes { get; set; }  
            
    }
}