using TaxCalculator.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface ICalculationTypesService
    {
        Task<List<CalculationType>> GetAll();
    }
}