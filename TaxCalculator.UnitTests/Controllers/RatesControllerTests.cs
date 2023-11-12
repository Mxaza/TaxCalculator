using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculator.API.Controllers;
using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.UnitTests.Controllers
{

    public class RatesControllerTests
    {
        [Test]
        public async Task RatesController_Get_OnSuccess()
        {
            //Arrange           
            var mockLogger = new Mock<ILogger<RatesController>>();
            var mockService = new Mock<IRatesService>();

            var rates = new List<Rate>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(rates));

            //Act
            var controller = new RatesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;

            //Assert
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.Ok);

        }

        [Test]
        public async Task RatesController_Get_OnNoContent()
        {
            //Arrange           
            var mockLogger = new Mock<ILogger<RatesController>>();
            var mockService = new Mock<IRatesService>();

            var rates = new List<Rate>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(rates));

            //Act
            var controller = new RatesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;

            //Assert            
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.NoContent);
        }

        [Test]
        public async Task RatesController_Get_OnInternalServerError()
        {
            //Arrange
            var mockLogger = new Mock<ILogger<RatesController>>();
            var mockService = new Mock<IRatesService>();

            var rates = new List<Rate>();

            mockService.Setup(x => x.GetAll())
                .Returns(Task.FromResult(rates));

            //Act
            var controller = new RatesController(mockLogger.Object, mockService.Object);

            var result = await controller.GetAll();
            var statusCodeResult = (ObjectResult?)result;

            //Assert
            Assert.True(statusCodeResult.StatusCode == ResponseCodes.InternalServerError);
        }
    }
}
