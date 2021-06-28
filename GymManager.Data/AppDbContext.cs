using GymManager.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace GymManager.Data
{
    public class UserDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>()
                .HasOne(p => p.User)
                .WithOne(b => b.Subscription)
                .HasForeignKey<Subscription>(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}