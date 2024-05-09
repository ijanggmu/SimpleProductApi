using Microsoft.EntityFrameworkCore;

namespace SimpleProductApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Product> Products { get; set; }
    }
}
