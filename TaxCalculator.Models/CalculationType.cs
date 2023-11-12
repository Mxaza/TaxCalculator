using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculator.Models
{
    [Table("CalculationType")]
    public class CalculationType
    {
        [Key]
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string TaxCalculationType { get; set; }
    }
}