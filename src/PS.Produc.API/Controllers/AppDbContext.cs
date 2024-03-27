using Microsoft.EntityFrameworkCore;
using PS.Produc.API.Models;

namespace PS.Produc.API.Controllers
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}