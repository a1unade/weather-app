using Grpc.Core;
using ServiceC.Web.Contexts;
using ServiceC.Web.Entities;
using Weather;

namespace ServiceC.Web.Services;

public class WeatherGrpcService(ILogger<WeatherGrpcService> logger, ApplicationDbContext dbContext) : WeatherService.WeatherServiceBase
{
    public override async Task<WeatherResponse> SetWeather(WeatherRequest request, ServerCallContext context)
    {
        var weatherData = new WeatherRecord
        {
            TemperatureC = request.TemperatureC,
            WindSpeed = request.WindSpeed,
            Humidity = request.Humidity,
            Pressure = request.Pressure,
            DewPoint = request.DewPoint
        };
        
        dbContext.WeatherRecords.Add(weatherData);
        await dbContext.SaveChangesAsync();
        
        return await Task.FromResult(new WeatherResponse { Status = "Success" });
    }
}