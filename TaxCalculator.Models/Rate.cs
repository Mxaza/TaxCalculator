namespace TaxCalculator.Models
{
    public class Rate
    {        
        public Guid Id { get; set; }
        public double Percentage { get; set; }
        public double From { get; set; }
        public double To { get; set; }
    }
}
