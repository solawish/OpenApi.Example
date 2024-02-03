using Microsoft.OpenApi.Models;
using OpenApi.Example.Infrastructure.ApiResponse;
using OpenApi.Example.Infrastructure.ApiResultCodes;
using OpenApi.Example.Infrastructure.Swagger.Extensions;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Net;

namespace OpenApi.Example.Infrastructure.Swagger.OperationFilter
{
    public class AuthorizeOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Responses.Any(x => x.Key.Equals("401")) is false)
            {
                operation.Responses.Add("401", new OpenApiResponse
                {
                    Description = "Unauthorized",
                    Content = new Dictionary<string, OpenApiMediaType>()
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Schema = context.SchemaGenerator.GenerateSchema(typeof(Response<object>), context.SchemaRepository),
                                Examples = typeof(ConstApiReslutCodes).GetExamples(HttpStatusCode.Unauthorized)
                            }
                        }
                    }
                });
            }

            if (operation.Responses.Any(x => x.Key.Equals("403")) is false)
            {
                operation.Responses.Add("403", new OpenApiResponse
                {
                    Description = "Forbidden",
                    Content = new Dictionary<string, OpenApiMediaType>()
                    {
                        {
                            "application/json", new OpenApiMediaType
                            {
                                Schema = context.SchemaGenerator.GenerateSchema(typeof(Response<object>), context.SchemaRepository),
                                Examples = typeof(ConstApiReslutCodes).GetExamples(HttpStatusCode.Forbidden)
                            }
                        }
                    }
                });
            }
        }
    }
}