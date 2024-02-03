using MediatR;

namespace OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;

public class GetWeatherForeacastQuery : IRequest<GetWeatherForeacastDto>
{
    /// <summary>
    /// 日期
    /// </summary>
    /// <example>2021-01-01</example>
    public DateTime Day { get; set; }

    /// <summary>
    /// 城市
    /// </summary>
    /// <example>Taipei</example>
    public string City { get; set; }

    /// <summary>
    /// 未來幾天
    /// </summary>
    /// <example>7</example>
    public int Days { get; set; }
}