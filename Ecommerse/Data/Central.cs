using Microsoft.EntityFrameworkCore;
using Ecommerse.Models;

namespace Ecommerse.Data
{
    public class Central : DbContext
    {
        public Central(DbContextOptions<Central> options) : base(options) { }

        public DbSet<ObjectsEcommerce> Ecommerce { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectsEcommerce>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ObjectsEcommerce>()
                .Property(e => e.ObjectId)
                .ValueGeneratedOnAdd();
        }
    }
}
