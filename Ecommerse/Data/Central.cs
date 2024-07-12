using Microsoft.EntityFrameworkCore;
using Ecommerse.Models;

namespace Ecommerse.Data
{
    public class Central : DbContext
    {
        public Central(DbContextOptions<Central> options) : base(options) { }

        public DbSet<ObjectsEcommerce> Ecommerce { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ventas> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectsEcommerce>()
                .HasKey(e => e.Id);
        }
    }
}
