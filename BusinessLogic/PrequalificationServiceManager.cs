using QualifiTest.Data;
using QualifiTest.Models;

namespace QualifiTest.BusinessLogic
{
    public class PrequalificationServiceManager : IPrequalificationServiceManager
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ILogger<PrequalificationServiceManager> _logger;

        public PrequalificationServiceManager(IApplicationDbContext applicationDbContext,
            ILogger<PrequalificationServiceManager> logger)
        {
            _applicationDbContext = applicationDbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<LoanProduct>> SubmitPrequalificationApplication(Customer customer)
        {
            var savedCustomer = await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();

            _logger.LogInformation("Customer has been saved");

            var loanProducts = _applicationDbContext.LoanProducts
                .Where(lp => lp.MinSalaryRange <= customer.Salary && lp.MaxSalaryRange >= customer.Salary)
                .ToList();

            var LoanProductCustomerHistory = new List<LoanProductCustomerHistory>();
            var requestId = Guid.NewGuid();

            foreach (var loanProduct in loanProducts)
            {
                LoanProductCustomerHistory.Add(
                    new LoanProductCustomerHistory
                    {
                        CustomerId = customer.Id,
                        LoanProductId = loanProduct.Id,
                        RequestId = requestId
                    });
            }

            await _applicationDbContext.LoanProductCustomerHistories.AddRangeAsync(LoanProductCustomerHistory);
            await _applicationDbContext.SaveChangesAsync();

            _logger.LogInformation("History has been saved");

            return loanProducts;
        }
    }
}
