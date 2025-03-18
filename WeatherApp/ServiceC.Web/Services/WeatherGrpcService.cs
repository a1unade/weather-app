using Grpc.Core;
using Weather;

namespace ServiceC.Web.Services;

public class WeatherGrpcService(ILogger<WeatherGrpcService> logger) : WeatherService.WeatherServiceBase
{
    public override Task<WeatherResponse> SetWeather(WeatherRequest request, ServerCallContext context)
    {
        logger.LogInformation($"Received weather update: {request.TemperatureC}°C");
        return Task.FromResult(new WeatherResponse { Status = "Success" });
    }
}