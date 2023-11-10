﻿using Microsoft.AspNetCore.Mvc;
using TaxCalculator.Models;
using TaxCalculator.Services.Interfaces;

namespace TaxCalculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : ControllerBase
    {
        private readonly ILogger<RatesController> _logger;
        private readonly IRatesService _service;

        public RatesController(
            ILogger<RatesController> logger,
            IRatesService service)
        {
            _logger = logger;
            _service = service;            
        }

        // GET: api/<RatesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAll();

                if (result.Count > 0)
                {
                    return StatusCode(ResponseCodes.Ok, result);
                }
                else
                {
                    return StatusCode(ResponseCodes.NoContent, result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(ResponseCodes.InternalServerError);
            }
        }        
    }
}
