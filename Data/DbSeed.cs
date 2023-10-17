using Microsoft.EntityFrameworkCore;
using QualifiTest.Models;

namespace QualifiTest.Data
{
    public class DbSeed
    {
        private readonly ModelBuilder modelBuilder;

        public DbSeed(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            var creditCardProductType = new LoanProductType { Id = 1, Name = "Credit Card" };
            var bnplProductType = new LoanProductType { Id = 2, Name = "Buy Now Pay Later" };
            var carFinanceProductType = new LoanProductType { Id = 3, Name = "Car Finance" };
            var loanSharkProductType = new LoanProductType { Id = 4, Name = "Loan Shark" };

            modelBuilder.Entity<LoanProductType>().HasData(
                creditCardProductType,
                bnplProductType,
                carFinanceProductType,
                loanSharkProductType
                );                   

            modelBuilder.Entity<LoanProduct>().HasData(
                   new LoanProduct { 
                       Id = 1, 
                       Name = "Balance Transfer Card", 
                       TypeId = 1,
                       MinSalaryRange = 10000,
                       MaxSalaryRange = 20000
                   },
                   new LoanProduct
                   {
                       Id = 2,
                       Name = "Interest Free Card",
                       TypeId = 1,
                       MinSalaryRange = 15000,
                       MaxSalaryRange = 50000
                   },
                   new LoanProduct
                   {
                       Id = 3,
                       Name = "Millionaire Card",
                       TypeId = 1,
                       MinSalaryRange = 1000000,
                       MaxSalaryRange = 100000000
                   },
                   new LoanProduct
                   {
                       Id = 4,
                       Name = "BNPL Finance",
                       TypeId = 2,
                       MinSalaryRange = 10000,
                       MaxSalaryRange = 50000
                   },
                   new LoanProduct
                   {
                       Id = 5,
                       Name = "Car Finance 5%",
                       TypeId = 3,
                       MinSalaryRange = 250000,
                       MaxSalaryRange = 750000
                   },
                   new LoanProduct
                   {
                       Id = 6,
                       Name = "Loan Shark Agreement",
                       TypeId = 4,
                       MinSalaryRange = 1,
                       MaxSalaryRange = 1000000
                   }
            );
        }
    }
}
