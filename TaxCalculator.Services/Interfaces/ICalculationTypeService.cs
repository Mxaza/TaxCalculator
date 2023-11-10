using TaxCalculator.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface ICalculationTypeService
    {
        Task<List<CalculationType>> GetAll();
    }
}