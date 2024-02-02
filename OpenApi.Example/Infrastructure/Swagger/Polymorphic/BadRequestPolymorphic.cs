using OpenApi.Example.Infrastructure.ApiResponse;
using Swashbuckle.AspNetCore.Annotations;

namespace OpenApi.Example.Infrastructure.Swagger.Polymorphic;

[SwaggerSubType(typeof(Response<object>))]
[SwaggerSubType(typeof(OtherResponse))]
public abstract class BadRequestPolymorphic
{
}