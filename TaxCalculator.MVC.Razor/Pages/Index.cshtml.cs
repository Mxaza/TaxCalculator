using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaxCalculator.Models;

namespace TaxCalculator.MVC.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public double AnnualIncome { get; set; }

        [BindProperty]
        public string PostalCode { get; set; }

        public string Result { get; set; }

        public async Task OnPostAsync()
        {
            // Call the Web API endpoint
            using (var httpClient = new HttpClient())
            {
                // TODO: Read from App Settings
                var apiUrl = "https://localhost:7186/api/TaxCalculation/CalculateTax";

                var requestData = new TaxCalculationRequest
                {
                    AnnualIncome = AnnualIncome,
                    PostalCode = PostalCode
                };

                var response = await httpClient.PostAsJsonAsync(apiUrl, requestData);

                if (response.IsSuccessStatusCode)
                {
                    Result = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Result = "Error calculating tax. Please try again.";
                }
            }
        }
    }
}