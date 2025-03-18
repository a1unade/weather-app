using System.Text.Json.Serialization;

namespace WeatherApp.Contracts.Models;

public class WeatherApiResponse
{
    /// <summary>
    /// Температура (в градусах по Цельсию)
    /// </summary>
    [JsonPropertyName("temp_c")]
    public double TemperatureC { get; set; }

    /// <summary>
    /// Скорость ветра
    /// </summary>
    [JsonPropertyName("wind_kph")]
    public double WindSpeed { get; set; }

    /// <summary>
    /// Влажность
    /// </summary>
    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }

    /// <summary>
    /// "Ощущается как" (в градусах по Цельсию)
    /// </summary>
    [JsonPropertyName("feelslike_c")]
    public double FeelsLike { get; set; }

    /// <summary>
    /// Давление
    /// </summary>
    [JsonPropertyName("pressure_mb")]
    public double Pressure { get; set; }

    /// <summary>
    /// Точка росы (в градусах по Цельсию)
    /// </summary>
    [JsonPropertyName("dew_point_c")]
    public double DewPoint { get; set; }
}