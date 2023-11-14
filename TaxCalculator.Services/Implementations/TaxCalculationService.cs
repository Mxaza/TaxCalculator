using System.Collections.Generic;
using TaxCalculator.Models;
using TaxCalculator.Repositories.Interfaces;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.Services.Implementations
{
    public class TaxCalculationService : ITaxCalculationService
    {
        private readonly ITaxCalculationRepository _taxCalculationRepository;
        private readonly IRatesRepository _ratesRepository;

        public TaxCalculationService(
            ITaxCalculationRepository taxCalculationRepository,
            IRatesRepository ratesRepository)
        {           
            _taxCalculationRepository = taxCalculationRepository;
            _ratesRepository = ratesRepository;
        }

        public async Task<double> CalculateTax(TaxCalculationRequest request)
        {
            double result = 0;

            //TODO: Refactor  
            switch (request.PostalCode)
            {
                case "1000":
                case "7441":
                    result = await CalculateProgressiveTax(request);
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
        
        private async Task<double> CalculateProgressiveTax(TaxCalculationRequest request)
        {
            double tempIncome = request.AnnualIncome;
            double tax = 0;
            try
            {
                List<Rate> rates = await _ratesRepository.GetAllRates();
                rates = rates.OrderBy(x => x.Percentage).ToList();
                rates.Where(w => w.To == null).ToList().ForEach(s => s.To = double.MaxValue);

                for (int i = 0; i < rates.Count; i++)
                {
                    if (tempIncome <= rates[i].To)
                    {
                        tax += ((tempIncome * 100) / rates[i].Percentage) / 100;
                        break;
                    }
                    else
                    {
                        tax += ((double)rates[i].To * rates[i].Percentage) / 100;
                        tempIncome -= (double)rates[i].To;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }           

            return Math.Round(tax, 2);
        }       

        private async Task SaveResults(TaxCalculationResponse taxCalculationResponse)
        {
            await _taxCalculationRepository.SaveResults(taxCalculationResponse);
        }
    }
}