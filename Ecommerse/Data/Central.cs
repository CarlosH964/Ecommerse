using Microsoft.EntityFrameworkCore;
using Ecommerse.Models; 

namespace Ecommerse.Data
{
    public class Central : DbContext
    {
        public Central(DbContextOptions<Central> options): base(options) { }
        public DbSet<ObjectsEcommerce> Ecommerce { get; set; }
    }
}
