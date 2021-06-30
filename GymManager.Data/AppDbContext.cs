using GymManager.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Data
{
    public class AppDbContext : IdentityDbContext<Employee>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                .HasOne(p => p.User)
                .WithMany(b => b.Subscriptions)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}