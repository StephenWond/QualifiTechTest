using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QualifiTest.Models
{
    public class LoanProductCustomerHistory
    {
        public LoanProductCustomerHistory()
        {
            CreatedDateTime = DateTime.Now;
        }

        [Key]
        public int? Id { get; set; }

        [Required]
        public DateTime? CreatedDateTime { get; private set; }

        [Required]
        public Guid? RequestId { get; set; }

        [Required, ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }

        [IgnoreDataMember]
        public int? CustomerId { get; set; }

        [Required, ForeignKey("LoanProductId")]
        public LoanProduct? LoanProduct { get; set; }

        [IgnoreDataMember]
        public int? LoanProductId { get; set; }
    }
}

