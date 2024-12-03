using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["WeatherApi:BaseUrl"];
        _apiKey = configuration["WeatherApi:ApiKey"];
    }

    public async Task<object> GetWeatherAsync(string city)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}?q={city}&appid={_apiKey}&units=metric");
        response.EnsureSuccessStatusCode();
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<object>(json);
    }
}
