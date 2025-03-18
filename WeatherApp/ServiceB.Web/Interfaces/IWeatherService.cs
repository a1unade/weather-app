using WeatherApp.Contracts.Models;

namespace ServiceB.Web.Interfaces;

public interface IWeatherService
{
    Task SendWeatherAsync(WeatherApiResponse message, CancellationToken cancellationToken);
}