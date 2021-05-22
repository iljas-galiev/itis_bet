using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Itis_bet.DAL.Models
{
    public partial class ITISbetContext : 
            IdentityDbContext<Users,IdentityRole<Guid>,Guid>
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Matches> Matches { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Bets> Bets { get; set; }
        public DbSet<UsersBets> UsersBets { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public ITISbetContext()
        {
        }

        public ITISbetContext(DbContextOptions<ITISbetContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("ITISBet");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
