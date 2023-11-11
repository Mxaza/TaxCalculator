namespace TaxCalculator.Models
{
    public class TaxCalculationResponse
    {        
        public Guid Id { get; set; }
        public double CalculatedTax { get; set; }
        public DateTime DateCalculated { get; set; }
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
    }
}
