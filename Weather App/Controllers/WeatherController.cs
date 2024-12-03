using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;
using Microsoft.Extensions.Configuration;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return BadRequest("City name cannot be empty.");
            }

            var weatherData = await _weatherService.GetWeatherAsync(city);
            if (weatherData == null)
            {
                return NotFound("City not found or an error occurred.");
            }

            return Ok(weatherData);
        }
    }
}
    