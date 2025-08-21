using Microsoft.EntityFrameworkCore;
using FinanceControl.Domain.Entities;

namespace FinanceControl.Infrastructure.Persistence
{
    public class FinanceControlDbContext : DbContext
    {
        public FinanceControlDbContext(DbContextOptions<FinanceControlDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
