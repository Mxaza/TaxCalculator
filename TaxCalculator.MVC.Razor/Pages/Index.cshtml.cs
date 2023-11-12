using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TaxCalculator.Models;

namespace TaxCalculator.MVC.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Models.AppSettings _appSettings;        

        public IndexModel(
            ILogger<IndexModel> logger, 
            Models.AppSettings appSettings)
        {
            _logger = logger;
            _appSettings = appSettings;
        }

        [BindProperty]
        [Required(ErrorMessage = "Annual Income is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a positive number for Annual Income.")]
        public double AnnualIncome { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Postal Code is required.")]
        [StringLength(4, ErrorMessage = "Postal Code must be 4 characters long.")]
        public string PostalCode { get; set; }

        public string Result { get; set; }

        public async Task OnPostAsync()
        {
            // Call Web API endpoint
            using (var httpClient = new HttpClient())
            {
                var apiUrl = _appSettings.ApplicationUrls.WebApiUrl;

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
                if ((int)response.StatusCode == ResponseCodes.BadRequest)
                {
                    Result = "Error calculating tax. Please verify your input is correct and again.";
                }
                else
                {
                    Result = "Error calculating tax. Please try again.";
                }
            }
        }
    }
}