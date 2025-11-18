using Luche.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Luche.Infrastructure.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
