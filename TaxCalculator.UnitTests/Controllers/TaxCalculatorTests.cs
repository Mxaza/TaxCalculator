using Microsoft.AspNetCore.Mvc;
using TaxCalculator.API.Controllers;

namespace TaxCalculator.UnitTests.Controllers
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TaxCalculatorController_CalculateTax_OnSuccess()
        {
            //Arrange
            var sut = new TaxCalculatorController();

            //Act
            var result = await sut.Post("string");
            var statusCodeResult = (ObjectResult?)result;

            //Assert
            Assert.True(statusCodeResult.StatusCode == 200);
        }
    }
}