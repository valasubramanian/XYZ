using System;
using X.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace X.Infrastructure.Context
{
    public class XDbContext: DbContext
    {
        public XDbContext(DbContextOptions<XDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
