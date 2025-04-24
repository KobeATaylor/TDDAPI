using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using TDDAPiQuiz.Data;
namespace TDDAPiQuiz.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly TDDContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TDDContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("ContextTest")]
        public IActionResult ContextTest()
        {
            if (_context != null)
            {
                return Ok("Context successful!");
            }
            else
            {
                return StatusCode(500, "Context not successful");
            }
        }
    }
}