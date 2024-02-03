using Asp.Versioning.ApiExplorer;
using OpenApi.Example.Application;
using OpenApi.Example.Infrastructure.ApiVersion;
using OpenApi.Example.Infrastructure.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersion();

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddApplication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

var apiProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseSwaggerUI(options =>
{
    foreach (ApiVersionDescription description in apiProvider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{description.GroupName}/swagger.json",
            $"OpanApi Example {description.GroupName}");
    }

    options.OAuthClientId("myclientid");
    options.OAuthAppName("my api");
    options.OAuthUsePkce();
});

foreach (ApiVersionDescription description in apiProvider.ApiVersionDescriptions)
{
    app.UseReDoc(options =>
    {
        options.SpecUrl($"/swagger/{description.GroupName}/swagger.json");
        options.RoutePrefix = $"redoc/{description.GroupName}";
        options.DocumentTitle = $"OpanApi Example {description.GroupName}";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();