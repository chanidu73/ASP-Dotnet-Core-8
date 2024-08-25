using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineFood.Models;



namespace OnlineFood.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
        :base(options)
        {
        }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public DbSet<MenuItemModel> MenuItems { get; set; }
        public DbSet<OrderModel> Orders { get; set ;}
        public DbSet<OrderItemModel>OrderItems { get; set; }
        public DbSet<PaymentModel> Payments { get; set; }
        public DbSet<DeliveryModel> Deliveries { get; set; }
        public DbSet<ReviewModel> Reviews { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}