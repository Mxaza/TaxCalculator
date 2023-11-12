using TaxCalculator.Models;

namespace TaxCalculator.Repositories.Interfaces
{
    public interface ICalculationTypesRepository
    {
        Task<List<CalculationType>> GetAllCalculationTypes();
    }
}