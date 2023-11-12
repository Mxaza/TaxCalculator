using TaxCalculator.Models;
using TaxCalculator.Repositories.Contexts;
using TaxCalculator.Repositories.Interfaces;

namespace TaxCalculator.Repositories.Implementantios
{
    public class TaxCalculationRepository : ITaxCalculationRepository
    {
        private readonly TaxCalculatorContext _context;

        public TaxCalculationRepository(TaxCalculatorContext context)
        {
            _context = context;
        }

        public async Task SaveResults(TaxCalculationResponse response)
        {            
            _context.TaxCalculationResults.Add(response);
            await _context.SaveChangesAsync();
        }
    }
}