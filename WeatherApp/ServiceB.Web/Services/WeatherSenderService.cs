using ServiceB.Web.Interfaces;
using Weather;
using WeatherApp.Contracts.Models;

namespace ServiceB.Web.Services;

public class WeatherSenderService(ILogger<WeatherSenderService> logger, WeatherService.WeatherServiceClient grpcClient): IWeatherSenderService
{
    public async Task SendWeatherAsync(WeatherApiResponse message, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Sending weather request. TemperatureC: {message.TemperatureC}");
        
        var grpcRequest = new WeatherRequest
        {
            TemperatureC = message.TemperatureC,
            WindSpeed = message.WindSpeed,
            Humidity = message.Humidity,
            Pressure = message.Pressure,
            DewPoint = message.DewPoint
        };

        var grpcResponse = await grpcClient.SetWeatherAsync(grpcRequest, cancellationToken: cancellationToken);
        logger.LogInformation($"gRPC response: {grpcResponse.Status}");
    }
}