using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
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

        [HttpGet("ConnectionString")]
        public IActionResult TestConnectionString()
        {
            string connectionString = "";

            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return Ok("Connected to SQL Database");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to connect: {ex.Message}");
            }
        }
    }
}