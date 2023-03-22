using Asteria.Services.Pay.H5Payment;
using Microsoft.EntityFrameworkCore;

namespace Asteria.Services.Pay.EntityFrameworkCore
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<H5Trade> H5Trades => Set<H5Trade>();
    }
}
