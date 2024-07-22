using Microsoft.EntityFrameworkCore;
using Ecommerse.Models;

namespace Ecommerse.Data
{
    public class Central : DbContext
    {
        public Central(DbContextOptions<Central> options) : base(options) { }
        public DbSet<Items> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ventas> VentaProductos { get; set; }
        public DbSet<PreV> PreV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Prev)
                .WithMany() // No es necesario tener una colección en PreV
                .HasForeignKey(v => v.IdPrev)
                .OnDelete(DeleteBehavior.Restrict); // Configura el comportamiento de eliminación si es necesario

            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Items)
                .WithMany() // No es necesario tener una colección en Items
                .HasForeignKey(v => v.ItemsId)
                .OnDelete(DeleteBehavior.Restrict); // Configura el comportamiento de eliminación si es necesario
        }

    }
}
