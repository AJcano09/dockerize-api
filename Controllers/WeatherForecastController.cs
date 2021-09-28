using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Netcore.dockerize.API.Controllers
{
    /// <summary>
    /// WeatherForecastController
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// WeatherForecastController.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="httpContextAccessor"></param>
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            string host = _httpContextAccessor.HttpContext?.Request.Host.Value;
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary =$"HOST[{host}] -[{Summaries[rng.Next(Summaries.Length)]}]"
            })
            .ToArray();
        }
    }
}
