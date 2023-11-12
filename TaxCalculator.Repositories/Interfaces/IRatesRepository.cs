using TaxCalculator.Models;

namespace TaxCalculator.Repositories.Interfaces
{
    public interface IRatesRepository
    {
        Task<List<Rate>> GetAllRates();
    }
}