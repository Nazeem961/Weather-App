# Weather App

The Weather App allows users to get current weather information for a city by fetching data from an external weather API. The backend is built using ASP.NET Core Web API.

## Features

- Search for current weather by city name
- Fetches real-time data from an external weather API
- Returns simplified JSON data to the user

## Technologies Used

- ASP.NET Core Web API
- C#
- External Weather API (e.g., OpenWeatherMap)

## How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/YourUsername/Weather-App.git
   
2.Open the project in Visual Studio.

3.Add your weather API key to the appsettings.json file:
{
  "WeatherApi": {
    "BaseUrl": "https://api.openweathermap.org/data/2.5/weather",
    "ApiKey": "Your_API_Key"
  }
}

4.Run the project using Ctrl + F5.

5.Use any REST client (e.g., Postman) to interact with the API using the following endpoint:

*GET /api/weather?city={cityName} - Get weather for a specific city

Example JSON Response
{
  "city": "London",
  "temperature": "15°C",
  "description": "Partly Cloudy"
}
