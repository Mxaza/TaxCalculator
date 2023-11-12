using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations.Mocks
{
    public class CalculationTypesMockService : ICalculationTypesService
    {
        public CalculationTypesMockService() { }

        public async Task<List<CalculationType>> GetAll()
        {
            return new List<CalculationType> {
                new CalculationType{
                    Id = Guid.NewGuid(), PostalCode = "7441", TaxCalculationType = "Progressive"
                },
                new CalculationType{
                    Id = Guid.NewGuid(), PostalCode = "A100", TaxCalculationType = "Flat Value"
                },
                new CalculationType{
                    Id = Guid.NewGuid(), PostalCode = "7000", TaxCalculationType = "Flat rate"
                },
                new CalculationType{
                    Id = new Guid(), PostalCode = "1000", TaxCalculationType = "Progressive"
                }
            };
        }
    }
}