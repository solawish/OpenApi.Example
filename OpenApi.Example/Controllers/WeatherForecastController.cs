using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenApi.Example.Application.Queries.GetWeatherForeacastQuery;
using OpenApi.Example.Infrastructure.Swagger.Polymorphic;
using OpenApi.Example.Infrastructure.Swagger.ResponseExamples;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Mime;

namespace OpenApi.Example.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get weather forecast
        /// </summary>
        /// <param name="getWeatherForeacastQuery"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(GetWeatherForeacastDto), 200)]
        [ProducesResponseType(typeof(BadRequestPolymorphic), 400)]
        [SwaggerResponseExample(400, typeof(BadRequestExamples))]
        public async Task<IActionResult> Get(GetWeatherForeacastQuery getWeatherForeacastQuery)
        {
            var result = await _mediator.Send(getWeatherForeacastQuery);
            return Ok(result);
        }
    }
}