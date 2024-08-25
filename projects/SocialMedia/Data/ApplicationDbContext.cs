using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialMedia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace SocialMedia.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration; 
        public ApplicationDbContext(DbContextOptions options , IConfiguration configuration):base(options)
        {
            _configuration =configuration;
        }
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
        public DbSet<FollowerModel>Followers { get; set; }
        public DbSet<FriendRequestModel>FriendRequests { get; set; }
        public DbSet<LikeModel>Likes { get; set; }
        public DbSet<NewsFeedModel>NewsFeeds { get; set; }
        public DbSet<PostModel>Post { get; set; }
    }
}