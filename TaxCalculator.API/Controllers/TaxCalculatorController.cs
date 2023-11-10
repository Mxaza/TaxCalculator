using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {       

        // POST api/<TaxCalculatorController>
        [HttpPost("CalculateTax")]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            throw new NotImplementedException();
        }        
    }
}
