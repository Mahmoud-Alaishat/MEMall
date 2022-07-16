using ME_Mall.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME_Mall.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ProductStore> ProductStore { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Design> Design { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<NewsAndArticles> NewsAndArticles { get; set; }
    }
}
