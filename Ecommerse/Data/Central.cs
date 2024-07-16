using Microsoft.EntityFrameworkCore;
using Ecommerse.Models;

namespace Ecommerse.Data
{
    public class Central : DbContext
    {
        public Central(DbContextOptions<Central> options) : base(options) { }
        public DbSet<Items> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<PreV> PreV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
