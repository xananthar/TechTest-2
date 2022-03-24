using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTest.Core;
using TechTest.Models;

namespace TechTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringStatsController : ControllerBase
    {
        private readonly ILogger<StringStatsController> _logger;
        private readonly IStringStatsProcessor _stringStatsProcessor;

        public StringStatsController(ILogger<StringStatsController> logger, IStringStatsProcessor stringStatsProcessor)
        {
            _logger = logger;
            _stringStatsProcessor = stringStatsProcessor;
        }

        [HttpPost]
        public async Task<ActionResult<StringStatsModel>> AnalyseString([FromBody] string subject)
        {
            _logger.LogInformation("AnalyseString called");

            try
            {
                return Ok(await _stringStatsProcessor.Run(subject));
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred in AnalyseString", ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred processing your request for string stats");  
            }
            
        }
    }
}
