using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace QualifiTest.Models
{
    public class Customer
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public double? Salary { get; set; }

        [Required, ForeignKey("AddressId")]
        public CustomerAddress? Address { get; set; }

        [IgnoreDataMember]
        public int AddressId { get; set; }
    }
}
