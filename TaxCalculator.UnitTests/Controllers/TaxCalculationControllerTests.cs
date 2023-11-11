using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaxCalculator.API.Controllers;
using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.UnitTests.Controllers
{
    public class TaxCalculationControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TaxCalculationController_CalculateTax_OnSuccess()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<TaxCalculationController>>();
            var mockService = new Mock<ITaxCalculationService>();

            var request = new TaxCalculationRequest
            {
                AnnualIncome = 8350,
                PostalCode = "1000"
            };
            
            var response = new TaxCalculationResponse();

            mockService.Setup(x => x.CalculateTax(request))
                .Returns( Task.FromResult(response.CalculatedTax));

            //Act
            var controller = new TaxCalculationController(mockLogger.Object, mockService.Object);

            var result = await controller.CalculateTax(request);
            var statusCodeResult = (ObjectResult?)result;                      

            //Assert
            Assert.True(statusCodeResult.StatusCode == 200);
        }
    }
}