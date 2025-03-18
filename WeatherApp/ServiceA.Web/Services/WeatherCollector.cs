using System.Runtime.Serialization;
using System.Text.Json;
using ServiceA.Web.Interfaces;
using WeatherApp.Contracts.Models;

namespace ServiceA.Web.Services;

public class WeatherCollector(IConfiguration configuration, HttpClient httpClient) : IWeatherCollector
{
    private readonly string _resourceUrl = configuration["WeatherApiConfig:WeatherApiUrl"]!;
    private readonly string _apiKey = configuration["WeatherApiConfig:WeatherApiKey"]!;

    public async Task<WeatherApiResponse?> FetchWeatherAsync(string city, string lang)
    {
        string url = $"{_resourceUrl}?q={city}&lang={lang}&key={_apiKey}";
        
        string json = await httpClient.GetStringAsync(url);

        using JsonDocument doc = JsonDocument.Parse(json);
        JsonElement root = doc.RootElement;

        if (root.TryGetProperty("current", out JsonElement current))
        {
            return JsonSerializer.Deserialize<WeatherApiResponse>(current.GetRawText(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        throw new SerializationException("Failed to fetch weather data");
    }
}
