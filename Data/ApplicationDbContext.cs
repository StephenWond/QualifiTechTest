using Microsoft.EntityFrameworkCore;
using QualifiTest.Models;

namespace QualifiTest.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new DbSeed(modelBuilder).Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanProduct> LoanProducts { get; set; }
        public DbSet<LoanProductCustomerHistory> LoanProductCustomerHistories { get; set; }
    }
}