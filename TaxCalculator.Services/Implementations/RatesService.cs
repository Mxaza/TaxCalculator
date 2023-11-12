using TaxCalculator.Models;
using TaxCalculator.Repositories.Interfaces;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class RatesService : IRatesService
    {
        private readonly IRatesRepository _repository;

        public RatesService(IRatesRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<Rate>> GetAll()
        {
            return await _repository.GetAllRates();
        }        
    }
}