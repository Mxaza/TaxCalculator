using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations.Mocks
{
    public class RatesMockService : IRatesService
    {
        public async Task<List<Rate>> GetAll()
        {
            return new List<Rate> {
                new Rate{ Id = Guid.NewGuid(), Percentage = 10.0, From = 0, To = 8350 },
                new Rate{ Id = Guid.NewGuid(), Percentage = 15.0, From = 8351, To = 33950 },
                new Rate{ Id = Guid.NewGuid(), Percentage = 25.0, From = 33951, To = 82250 },
                new Rate{ Id = Guid.NewGuid(), Percentage = 28.0, From = 82251, To = 171550 },
                new Rate{ Id = Guid.NewGuid(), Percentage = 33.0, From = 171551, To = 372950 },
                new Rate{ Id = Guid.NewGuid(), Percentage = 35.0, From = 372951 }
            };
        }
    }
}