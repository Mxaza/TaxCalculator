using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class RatesService : IRatesService
    {
        public RatesService() { }

        public async Task<List<Rate>> GetAll()
        {
            throw new NotImplementedException();    
        }        
    }
}