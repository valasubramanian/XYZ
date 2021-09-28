using System;
using X.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace X.Infrastructure.Context
{
    public class XDbContext: DbContext
    {
        public XDbContext(DbContextOptions<XDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("User");
        }
    }
}
