using TaxCalculator.Models;

namespace TaxCalculator.Repositories.Interfaces
{
    public interface ITaxCalculationRepository
    {
        Task SaveResults(TaxCalculationResponse response);
    }
}