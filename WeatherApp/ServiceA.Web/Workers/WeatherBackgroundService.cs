using Microsoft.Extensions.Hosting.Internal;
using ServiceA.Web.Interfaces;
using ServiceA.Web.Models;

namespace ServiceA.Web.Workers;

public class WeatherBackgroundService(
    IWeatherCollector weatherCollector, 
    ILogger<WeatherBackgroundService> logger, 
    IHostApplicationLifetime applicationLifetime,
    IConfiguration configuration): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));

        while (await timer.WaitForNextTickAsync(cancellationToken))
        {
            try
            {
                WeatherApiResponse? weather = await weatherCollector.FetchWeatherAsync(
                    configuration["WeatherApiConfig:WeatherApiCity"]!, configuration["WeatherApiConfig:WeatherApiLang"]!);
                
                if (weather is not null)
                {
                    // TODO: Sending data...
                    Console.WriteLine($"[{DateTime.UtcNow}] Температура: {weather.TemperatureC}°C");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                applicationLifetime.StopApplication();
            }
        }
    }
}