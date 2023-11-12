using TaxCalculator.Models;
using TaxCalculator.Repositories.Contexts;
using TaxCalculator.Repositories.Interfaces;

namespace TaxCalculator.Repositories.Implementantios
{
    public class CalculationTypesRepository : ICalculationTypesRepository
    {
        private readonly TaxCalculatorContext _context;

        public CalculationTypesRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task<List<CalculationType>> GetAllCalculationTypes()
        {
            var results = _context.CalculationTypes.ToList();

            return results;
        }
    }
}