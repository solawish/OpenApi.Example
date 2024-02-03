using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using OpenApi.Example.Infrastructure.ApiResultCodes;
using System.Net;

namespace OpenApi.Example.Infrastructure.Swagger.Extensions;

public static class GetExamplesExtension
{
    public static Dictionary<string, OpenApiExample> GetExamples(this Type type, HttpStatusCode httpStatusCode)
    {
        var dictionary = new Dictionary<string, OpenApiExample>();
        foreach (var field in type.GetProperties())
        {
            var value = field.GetValue(null);
            if (value is ApiResultCode apiResultCode && apiResultCode.HttpStatusCode.Equals(httpStatusCode))
            {
                dictionary.Add($"{apiResultCode.Code}-{apiResultCode.Message}", new OpenApiExample
                {
                    Value = new OpenApiObject
                    {
                        ["code"] = new OpenApiString(apiResultCode.Code),
                        ["message"] = new OpenApiString(apiResultCode.Message),
                    }
                });
            }
        }

        return dictionary;
    }
}