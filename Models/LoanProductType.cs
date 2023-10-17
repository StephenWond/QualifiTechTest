using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualifiTest.Models
{
    public class LoanProductType
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}