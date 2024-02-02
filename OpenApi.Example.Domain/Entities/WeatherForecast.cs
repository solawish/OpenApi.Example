namespace OpenApi.Example.Domain.Entities;

/// <summary>
/// Represents a weather forecast.
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Date
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    /// <summary>
    /// Summary
    /// </summary>
    public string? Summary { get; set; }
}