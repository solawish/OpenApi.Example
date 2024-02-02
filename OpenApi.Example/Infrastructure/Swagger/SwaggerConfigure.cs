using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using OpenApi.Example.Infrastructure.Swagger;
using OpenApi.Example.Infrastructure.Swagger.ConfigureOptions;
using OpenApi.Example.Infrastructure.Swagger.OperationFilter;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace OpenApi.Example.Infrastructure.Swagger;

public static class SwaggerConfigure
{
    public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        // Swagger Register
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options =>
        {
            options.DescribeAllParametersInCamelCase();

            options.AddSwagerServer();

            options.AddDescription();

            options.AddSecurityDefinition();
            options.AddSecurityRequirement();

            options.OperationFilter<AuthorizeOperationFilter>();
            options.OperationFilter<InternalServerErrorOerationFilter>();

            options.UseOneOfForPolymorphism();
            options.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);

            options.ExampleFilters();
        });

        //services.AddSwaggerExamples();
        //services.AddSingleton<BadRequestExamples>();

        services.AddSwaggerExamplesFromAssemblyOf<Program>();

        // Add Fluent Validation Rules to Swagger
        services.AddFluentValidationRulesToSwagger();

        // HttpContextValidatorRegistry requires access to HttpContext
        services.AddHttpContextAccessor();
        //// Register FV validators
        services.AddValidatorsFromAssemblyContaining<Program>(lifetime: ServiceLifetime.Scoped);
        // Add FV to Asp.net
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
    }

    private static void AddSwagerServer(this SwaggerGenOptions options)
    {
        options.AddServer(new OpenApiServer
        {
            Url = "/",
            Description = "Default"
        });
        options.AddServer(new OpenApiServer
        {
            Url = "https://apim.myserver.com.tw",
            Description = "Apim"
        });
    }

    private static void AddSecurityDefinition(this SwaggerGenOptions options)
    {
        options.AddSecurityDefinition(
            nameof(SecuritySchemeType.OAuth2),
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri("https://my.oauth.com.tw/connect/authorize"),
                        TokenUrl = new Uri("https://my.oauth.com.tw/connect/token"),
                        Scopes = new Dictionary<string, string> {
                            { "my_scope", "my scope" }
                        }
                    }
                }
            });

        options.AddSecurityDefinition(
            nameof(SecuritySchemeType.ApiKey),
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                Name = "apim-key",
                In = ParameterLocation.Header,
                Scheme = "ApiKeyScheme",
            }
        );

        options.AddSecurityDefinition(
            nameof(SecuritySchemeType.Http),
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer"
            }
        );
    }

    private static void AddSecurityRequirement(this SwaggerGenOptions options)
    {
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Id = nameof(SecuritySchemeType.OAuth2),
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            },
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = nameof(SecuritySchemeType.ApiKey),
                        Type = ReferenceType.SecurityScheme
                    },
                    In = ParameterLocation.Header,
                },
                new List<string>()
            },
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Id = nameof(SecuritySchemeType.Http),
                        Type = ReferenceType.SecurityScheme
                    }
                },
                new List<string>()
            }
        });
    }

    private static void AddDescription(this SwaggerGenOptions options)
    {
        foreach (var doc in options.SwaggerGeneratorOptions.SwaggerDocs)
        {
            doc.Value.Description += $"\n **Additional Description**";
        }
    }
}