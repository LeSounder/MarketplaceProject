using Microsoft.EntityFrameworkCore;
using MarketplaceProject.Domain.Entities;


namespace MarketplaceProject.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
