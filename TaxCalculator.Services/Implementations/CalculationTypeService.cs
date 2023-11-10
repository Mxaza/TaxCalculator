using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class CalculationTypeService : ICalculationTypeService
    {
        public CalculationTypeService() { }

        public async Task<List<CalculationType>> GetAll()
        {
            var result = new List<CalculationType>();

            return result;
        }
    }
}