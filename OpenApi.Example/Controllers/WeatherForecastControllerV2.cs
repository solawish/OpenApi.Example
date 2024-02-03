using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;
using OpenApi.Example.Infrastructure.Filters;
using OpenApi.Example.Infrastructure.Swagger.Polymorphic;
using OpenApi.Example.Infrastructure.Swagger.ResponseExamples;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Mime;

namespace OpenApi.Example.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/WeatherForecast")]
    [Tags("WeatherForecast")]
    public class WeatherForecastControllerV2 : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastControllerV2(
            ILogger<WeatherForecastController> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Get weather forecast
        /// </summary>
        /// <param name="getWeatherForeacastQuery"></param>
        /// <remarks>取得天氣預報</remarks>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [CustomValidator(typeof(GetWeatherForeacastQueryValidator))]
        [ProducesResponseType(typeof(GetWeatherForeacastDto), 200)]
        [ProducesResponseType(typeof(BadRequestPolymorphic), 400)]
        [SwaggerResponseExample(400, typeof(BadRequestExamples))]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForeacastQuery getWeatherForeacastQuery)
        {
            var result = await _mediator.Send(getWeatherForeacastQuery);
            return Ok(result);
        }
    }
}