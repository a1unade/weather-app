using ServiceB.Web.Interfaces;
using WeatherApp.Contracts.Models;

namespace ServiceB.Web.Services;

public class WeatherService(ILogger<WeatherService> logger): IWeatherService
{
    public async Task SendWeatherAsync(WeatherApiResponse message, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Sending weather request. TemperatureC: {message.TemperatureC}");
        
        await Task.CompletedTask;
    }
}