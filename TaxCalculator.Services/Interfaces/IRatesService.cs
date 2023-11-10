using TaxCalculator.Models;

namespace TaxCalculator.Services.Interfaces
{
    public interface IRatesService
    {
        Task<List<Rate>> GetAll();
    }
}