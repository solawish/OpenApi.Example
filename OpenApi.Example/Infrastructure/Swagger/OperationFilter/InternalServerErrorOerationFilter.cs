using Microsoft.OpenApi.Models;
using OpenApi.Example.Infrastructure.ApiResponse;
using OpenApi.Example.Infrastructure.ApiResultCodes;
using OpenApi.Example.Infrastructure.Swagger.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace OpenApi.Example.Infrastructure.Swagger.OperationFilter;

public class InternalServerErrorOerationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        if (operation.Responses.Any(x => x.Key.Equals("500")) is false)
        {
            operation.Responses.Add("500", new OpenApiResponse
            {
                Description = "Internal Server Error",
                Content = new Dictionary<string, OpenApiMediaType>()
                {
                    {
                        "application/json", new OpenApiMediaType
                        {
                            Schema = context.SchemaGenerator.GenerateSchema(typeof(Response<object>), context.SchemaRepository),
                            Examples = typeof(ConstApiReslutCodes).GetExamples(HttpStatusCode.InternalServerError)
                        }
                    }
                }
            });
        }
    }
}