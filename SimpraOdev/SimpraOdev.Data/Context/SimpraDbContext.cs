using Microsoft.EntityFrameworkCore;
using SimpraOdev.Data.Models;

namespace SimpraOdev.Data.Context;
    public class SimpraDbContext : DbContext
    {
        public SimpraDbContext(DbContextOptions<SimpraDbContext> options) : base(options)
        {

        }

        public DbSet<Staff> Staff { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StaffConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
