using OpenApi.Example.Infrastructure.ApiResponse;
using OpenApi.Example.Infrastructure.ApiResultCodes;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace OpenApi.Example.Infrastructure.Swagger.ResponseExamples;

public class BadRequestExamples : IMultipleExamplesProvider<object>
{
    public IEnumerable<SwaggerExample<object>> GetExamples()
    {
        // FluentValidation Error Exceiption
        yield return SwaggerExample.Create("OtherResponse", new OtherResponse
        {
            ErrorCode = "99",
            ErrorMessage = "參數有誤"
        } as object);

        // ApiResultCode
        var type = typeof(ConstApiReslutCodes);

        foreach (var field in type.GetProperties())
        {
            var value = field.GetValue(null);
            if (value is ApiResultCode apiResultCode && apiResultCode.HttpStatusCode.Equals(HttpStatusCode.BadRequest))
            {
                yield return SwaggerExample.Create($"{apiResultCode.Code}-{apiResultCode.Message}", new Response<object>
                {
                    Code = apiResultCode.Code,
                    Message = apiResultCode.Message,
                } as object);
            }
        }
    }
}