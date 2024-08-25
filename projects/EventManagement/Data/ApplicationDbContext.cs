// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
// using EventManagement.Models;
// namespace EventManagement.Data
// {
//     public class ApplicationDbContext:DbContext
//     {
//         private readonly IConfiguration _configuration;
//         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options , IConfiguration configuration): base(options)
//         {
//             _configuration = configuration;
//         }
//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if(!optionsBuilder.IsConfigured)
//             {
//                 optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
//             }
//         }
//         public DbSet<EventModel> Events { get; set; }
//         public DbSet<RegistrationModel> Registrations { get; set; }
//         public DbSet<TicketModel> Tickets { get; set; }

//     }
// }
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EventManagement.Models;

namespace EventManagement.Data
{
    public class ApplicationDbContext : DbContext//IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventModel> Events { get; set; }
        public DbSet<RegistrationModel> Registrations { get; set; }
        public DbSet<TicketModel> Tickets { get; set; }

        // You can override OnModelCreating if needed for custom configurations.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration if needed
        }
    }
}
