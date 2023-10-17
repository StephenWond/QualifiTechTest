using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QualifiTest.Models
{
    public class CustomerAddress
    {
        //assuming UK residential only
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? AddressLine1 { get; set; }

        public string? AddressLine2 { get; set; }

        [Required]
        public string? TownCity { get; set; }

        [Required]
        public string? County { get; set; }

        [Required, RegularExpression(@"^[A-Z]{1,2}[0-9R][0-9A-Z]?\s?[0-9][ABD-HJLNP-UW-Z]{2}$", ErrorMessage = "Use Valid UK Postcode")]
        public string? Postcode { get; set; }
    }
}
