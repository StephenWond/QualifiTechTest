using QualifiTest.Models;

namespace QualifiTest.BusinessLogic
{
    public interface IPrequalificationServiceManager
    {
        Task<IEnumerable<LoanProduct>> SubmitPrequalificationApplication(Customer customer);
    }
}