using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QualifiTest.Models;

namespace QualifiTest.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<LoanProduct> LoanProducts { get; set; }
        DbSet<LoanProductCustomerHistory> LoanProductCustomerHistories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
