using Microsoft.OpenApi.Models;

namespace ByteBank.API.Extensions
{
    public static class ConfigureBasicSwagger
    {
        public static void ConfigureSwaggerBearer(this IServiceCollection services)
        {
            ConfigureAppServiceSwagger(services);
        }

        internal static void ConfigureAppServiceSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(
                        swagger =>
                        {
                            swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "Grupo de Estudos C# - ByteBankAPI", Version = "v1" });
                            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                            {
                                Name = "Authorization",
                                Type = SecuritySchemeType.ApiKey,
                                Scheme = "Bearer",
                                BearerFormat = "JWT",
                                In = ParameterLocation.Header,
                                Description = "Header de autorização de esquema JWT usando Bearer.",
                            });
                            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                       Reference = new OpenApiReference
                                       {
                                           Type=ReferenceType.SecurityScheme,
                                           Id="Bearer"

                                       }
                                    },
                                    new string[]{}
                                }
                            });
                        });
        }
    }
}
