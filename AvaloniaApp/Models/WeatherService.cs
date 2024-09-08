using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;



namespace AvaloniaApp.Models
{
    public class WeatherService
    {
        private readonly string ApiKey = "xxx";
        private const string BaseUrl = "http://api.weatherapi.com/v1";
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<WeatherResponse> GetCurrentWeatherAsync(string location)
        {
            try
            {
                string url = $"{BaseUrl}/current.json?key={ApiKey}&q={location}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Десериализуем JSON-ответ в объект WeatherResponse
                WeatherResponse weatherData = JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);
                return weatherData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error fetching weather data: {ex.Message}");
                return null;
            }
        }
    }

    // Определите модель данных, чтобы десериализовать JSON-ответ
    public class WeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Localtime { get; set; }
    }

    public class Current
    {
        public double Temp_C { get; set; }
        public double Temp_F { get; set; }
        public double Wind_Kph { get; set; }
        public double Humidity { get; set; }
        public double Feelslike_C { get; set; }
        public double Feelslike_F { get; set; }
        public string last_updated { get; set; }
        public Condition condition { get; set; }
    }

    public class Condition
    {
        public string text { get; set; }

    }
}
