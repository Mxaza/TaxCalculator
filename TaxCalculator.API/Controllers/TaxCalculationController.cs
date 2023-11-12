using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculationController : ControllerBase
    {
        private readonly ILogger<TaxCalculationController> _logger;
        private readonly ITaxCalculationService _service;

        public TaxCalculationController(
            ILogger<TaxCalculationController> logger,
            ITaxCalculationService service)
        {
            _logger = logger;
            _service = service;         
        }

        // POST api/<TaxCalculationController>
        [HttpPost("CalculateTax")]
        public async Task<IActionResult> CalculateTax([FromBody] TaxCalculationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _service.CalculateTax(request);                

                return StatusCode(ResponseCodes.Ok, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ResponseCodes.InternalServerError);
            }
        }        
    }
}
