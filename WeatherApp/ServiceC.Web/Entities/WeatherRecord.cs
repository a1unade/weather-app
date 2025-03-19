namespace ServiceC.Web.Entities;

public class WeatherRecord
{
    /// <summary>
    /// ID
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Температура (в градусах по Цельсию)
    /// </summary>
    public double TemperatureC { get; set; }

    /// <summary>
    /// Скорость ветра
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    /// Влажность
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// "Ощущается как" (в градусах по Цельсию)
    /// </summary>
    public double FeelsLike { get; set; }

    /// <summary>
    /// Давление
    /// </summary>
    public double Pressure { get; set; }

    /// <summary>
    /// Точка росы (в градусах по Цельсию)
    /// </summary>
    public double DewPoint { get; set; }
}