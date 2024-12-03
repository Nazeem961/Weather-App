using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApp.Pages
{
    public class IndexModel : PageModel
    {
        public WeatherData WeatherData { get; set; }
        public string ErrorMessage { get; set; }

        [BindProperty]
        public string City { get; set; }

        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(City))
            {
                ErrorMessage = "City name is required.";
                return Page();
            }

            try
            {
                var response = await _httpClient.GetAsync($"/api/weather/{City}");
                if (!response.IsSuccessStatusCode)
                {
                    ErrorMessage = "City not found or an error occurred.";
                    return Page();
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();
                WeatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);
            }
            catch
            {
                ErrorMessage = "An error occurred while fetching weather data.";
            }

            return Page();
        }
    }

    public class WeatherData
    {
        public string City { get; set; }
        public string Temperature { get; set; }
        public string Condition { get; set; }
    }
}
