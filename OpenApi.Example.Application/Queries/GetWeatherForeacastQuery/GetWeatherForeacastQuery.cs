using MediatR;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

public class GetWeatherForeacastQuery : IRequest<GetWeatherForeacastDto>
{
    public int Days { get; set; }

    public string City { get; set; }
}