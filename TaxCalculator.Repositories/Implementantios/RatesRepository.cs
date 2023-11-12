using TaxCalculator.Models;
using TaxCalculator.Repositories.Interfaces;

namespace TaxCalculator.Repositories.Implementantios
{
    public class RatesRepository : IRatesRepository
    {
        private readonly TaxCalculatorContext _context;

        public RatesRepository(TaxCalculatorContext context) {
            _context = context;
        }

        public async Task<List<Rate>> GetAllRates()
        {
            return _context.Rates.ToList();
        }
    }
}