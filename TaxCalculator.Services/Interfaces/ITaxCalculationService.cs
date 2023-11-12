using TaxCalculator.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface ITaxCalculationService
    {
        Task<double> CalculateTax(TaxCalculationRequest request);
    }
}