using TaxCalculator.Models;
using TaxCalculator.Repositories.Interfaces;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class CalculationTypesService : ICalculationTypesService
    {
        private readonly ICalculationTypesRepository _repository;

        public CalculationTypesService(ICalculationTypesRepository repository) {
            _repository = repository;
        }

        public async Task<List<CalculationType>> GetAll()
        {
            return await _repository.GetAllCalculationTypes();
        }
    }
}