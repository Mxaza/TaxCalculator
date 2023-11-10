using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TaxCalculator.API.Controllers;
using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.UnitTests.Controllers
{
    public class CalculationTypesControllerTests
    {      
        [Test]
        public async Task CalculationTypesController_Get_OnSuccess()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CalculationTypesController>>();
            var mockService = new Mock<ICalculationTypeService>();

            var calculationTypes = new List<CalculationType>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(calculationTypes));

            //Act
            var controller = new CalculationTypesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;
            
            //Assert
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.Ok);
            
        }

        [Test]
        public async Task CalculationTypesController_Get_OnNoContent()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CalculationTypesController>>();
            var mockService = new Mock<ICalculationTypeService>();

            var calculationTypes = new List<CalculationType>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(calculationTypes));

            //Act
            var controller = new CalculationTypesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;

            //Assert            
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.NoContent);
        }

        [Test]
        public async Task CalculationTypesController_Get_OnInternalServerError()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<CalculationTypesController>>();
            var mockService = new Mock<ICalculationTypeService>();

            var calculationTypes = new List<CalculationType>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(calculationTypes));

            //Act
            var controller = new CalculationTypesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;

            //Assert
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.InternalServerError);
        }        
    }
}