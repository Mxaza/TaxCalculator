using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxCalculator.Models
{
    [Table("TaxCalculationResponse")]
    public class TaxCalculationResponse
    {
        [Key]
        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        [Column(TypeName = "float")]
        public double AnnualIncome { get; set; }

        [Column(TypeName = "float")]
        public double CalculatedTax { get; set; }
        
        public DateTime DateCreated { get; set; }
        
    }
}
