using TaxCalculator.Models;
using TaxCalculator.Repositories.Interfaces;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly ITaxCalculationRepository _taxCalculationRepository;

        public TaxCalculationService(ITaxCalculationRepository taxCalculationRepository)
        {           
            _taxCalculationRepository = taxCalculationRepository;
        }

        public async Task<double> CalculateTax(TaxCalculationRequest request)
        {
            double result = 0;

            //TODO: Refactor  
            switch (request.PostalCode)
            {
                case "1000":
                case "7441":
                    result = CalculateProgressiveTax(request);
                    break;
                case "A100":
                    result = CalculateFlatValueTax(request);
                    break;
                case "7000":
                    result = CalculateFlatRateTax(request);
                    break;
            }

            // Persist results
            var taxCalculationResponse = new TaxCalculationResponse
            {
                AnnualIncome = request.AnnualIncome,
                PostalCode = request.PostalCode,
                CalculatedTax = result,
                DateCreated = DateTime.UtcNow
            };
            await SaveResults(taxCalculationResponse);

            return result;
        }

        private double CalculateFlatValueTax(TaxCalculationRequest request)
        {
            if (request.AnnualIncome >= 200000)
            {
                return (request.AnnualIncome / 100) * 0.5;
            }
            else
            {
                return 10000;
            }
        }

        private double CalculateFlatRateTax(TaxCalculationRequest request)
        {
            return (request.AnnualIncome / 100) * 17.5;
        }

        private double CalculateProgressiveTax(TaxCalculationRequest request)
        {
            double result = 0;

            if (request.AnnualIncome >= 0 && request.AnnualIncome <= 8350)
            {
                result = (request.AnnualIncome / 100) * 10.0;
            }
            else if (request.AnnualIncome >= 8351 && request.AnnualIncome <= 33950)
            {
                result = (request.AnnualIncome / 100) * 15.0;
            }
            else if (request.AnnualIncome >= 33951 && request.AnnualIncome <= 82250)
            {
                result = (request.AnnualIncome / 100) * 25.0;
            }
            else if (request.AnnualIncome >= 82251 && request.AnnualIncome <= 171550)
            {
                result = (request.AnnualIncome / 100) * 28.0;
            }
            else if (request.AnnualIncome >= 171551 && request.AnnualIncome <= 372950)
            {
                result = (request.AnnualIncome / 100) * 33.0;
            }
            else if (request.AnnualIncome >= 372951)
            {
                result = (request.AnnualIncome / 100) * 35.0;
            }

            return result;
        }

        private async Task SaveResults(TaxCalculationResponse taxCalculationResponse)
        {
            await _taxCalculationRepository.SaveResults(taxCalculationResponse);
        }
    }
}
