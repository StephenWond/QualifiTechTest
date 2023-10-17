using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QualifiTest.Models
{
    public class LoanProduct
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public double? MinSalaryRange { get; set; }

        [Required]
        public double? MaxSalaryRange { get; set; }

        [Required, ForeignKey("TypeId")]
        public LoanProductType? Type { get; set; }

        [IgnoreDataMember]
        public int? TypeId {  get; set; }
    }
}
