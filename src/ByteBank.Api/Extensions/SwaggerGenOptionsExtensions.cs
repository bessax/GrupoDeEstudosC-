namespace ByteBank.Api.Extensions;

public static class SwaggerGenOptionsExtensions
{
    public static IServiceCollection AddSwaggerGenWithPasswordSecurity(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("bytebank-api-swagger-ui-client", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("/connect/token", UriKind.Relative),
                    }
                }
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "bytebank-api-swagger-ui-client"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        return services;
    }
}