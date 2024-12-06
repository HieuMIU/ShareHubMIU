using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Domain.View;

namespace ShareHubMIU.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<CarSharing> CarSharings { get; set; }

        public DbSet<RoomSharing> RoomSharings { get; set; }

        public DbSet<CommonItem> CommonItems { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<UserReview> UserReviews { get; set; }

        public DbSet<UserReport> UserReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.Seller)
                .WithMany() // If Seller can have multiple items
                .HasForeignKey(i => i.SellerId)
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete
        }
    }
}
