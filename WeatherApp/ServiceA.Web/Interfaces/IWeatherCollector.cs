using ServiceA.Web.Models;

namespace ServiceA.Web.Interfaces;

public interface IWeatherCollector
{
    /// <summary>
    /// Получение погоды из публичного API
    /// </summary>
    /// <param name="city">Город, для которого нужно получить погоду</param>
    /// <param name="lang">Язык, на котором должен прийти ответ</param>
    /// <returns>Текущая погода для выбранного города</returns>
    Task<WeatherApiResponse?> FetchWeatherAsync(string city, string lang);
}