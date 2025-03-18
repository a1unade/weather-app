using ServiceA.Web.Interfaces;
using WeatherApp.Contracts.Models;

namespace ServiceA.Web.Workers;

public class WeatherBackgroundService(
    IWeatherCollector weatherCollector, 
    ILogger<WeatherBackgroundService> logger, 
    IHostApplicationLifetime applicationLifetime,
    IConfiguration configuration,
    IKafkaProducer<WeatherApiResponse> producer): BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                WeatherApiResponse? weather = await weatherCollector.FetchWeatherAsync(
                    configuration["WeatherApiConfig:WeatherApiCity"]!, configuration["WeatherApiConfig:WeatherApiLang"]!);
                
                if (weather is not null)
                    await producer.ProduceAsync(weather, cancellationToken);
                
                await Task.Delay(TimeSpan.FromMinutes(1), cancellationToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                applicationLifetime.StopApplication();
            }
        }
    }
}