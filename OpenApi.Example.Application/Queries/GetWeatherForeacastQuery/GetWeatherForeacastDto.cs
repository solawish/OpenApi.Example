using OpenApi.Example.Domain.Entities;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

/// <summary>
/// Get weather forecast Result
/// </summary>
public class GetWeatherForeacastDto
{
    /// <summary>
    /// WeatherForecast List
    /// </summary>
    public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }
}