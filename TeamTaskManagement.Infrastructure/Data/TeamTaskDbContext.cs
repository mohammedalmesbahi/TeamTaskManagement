using Azure.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamTaskManagement.Domain.Entities;
using TeamTaskManagement.Infrastructure.Seed;

namespace TeamTaskManagement.Infrastructure.Data
{
    public class TeamTaskDbContext : IdentityDbContext<User, Role, long>
    {
        public TeamTaskDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Role>().Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<User>().Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<Team>().Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.Entity<TaskItem>().Property(x => x.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            builder.SeedData();
        }

    }
}
