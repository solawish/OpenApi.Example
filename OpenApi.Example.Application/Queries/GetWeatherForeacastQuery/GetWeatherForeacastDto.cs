using OpenApi.Example.Domain.Entities;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

public class GetWeatherForeacastDto
{
    public IEnumerable<WeatherForecast> WeatherForecasts { get; set; }
}