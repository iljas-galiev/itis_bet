using System;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL
{ 
    public class Database : IdentityDbContext<User>
    {
        public override DbSet<User> Users { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Bets> Bets { get; set; }
        public DbSet<UsersBets> UsersBets { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Passport> Passports { get; set; }
        
        public Database(DbContextOptions<Database> options)
            : base(options) { }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql("ITISBet");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserProfile>()
                .Property(profile => profile.CanBet)
                .HasDefaultValue(true);
        }
    }
}

