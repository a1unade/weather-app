using WeatherApp.Contracts.Models;

namespace ServiceB.Web.Interfaces;

public interface IWeatherSenderService
{
    Task SendWeatherAsync(WeatherApiResponse message, CancellationToken cancellationToken);
}