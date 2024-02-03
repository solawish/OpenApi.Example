using MediatR;
using OpenApi.Example.Domain.Entities;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

public class GetWeatherForeacastQueryHandler : IRequestHandler<GetWeatherForeacastQuery, GetWeatherForeacastDto>
{
    public GetWeatherForeacastQueryHandler()
    {
    }

    public async Task<GetWeatherForeacastDto> Handle(GetWeatherForeacastQuery request, CancellationToken cancellationToken)
    {
        return new GetWeatherForeacastDto
        {
            WeatherForecasts = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    TemperatureC = 20,
                    Summary = "Warm"
                },
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    TemperatureC = 25,
                    Summary = "Hot"
                },
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                    TemperatureC = 30,
                    Summary = "Very Hot"
                }
            }
        };
    }
}