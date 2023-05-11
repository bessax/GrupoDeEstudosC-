namespace ByteBank.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
        ApplicationLayerAssembly = Assembly.Load("ByteBank.Application");
    }

    public Assembly ApplicationLayerAssembly { get; }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ByteBankContext>(
            options => options.UseSqlServer(
                "Name=ConnectionStrings:ByteBankConnection"));

        services.AddDbContext<IdentityContext>(
            options => options.UseSqlServer(
                "Name=ConnectionStrings:IdentityConnection"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAgenciaRepository, AgenciaRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<IAgenciaRepository, AgenciaRepository>();

        services
            .AddMediatR(c => c.RegisterServicesFromAssembly(ApplicationLayerAssembly))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddValidatorsFromAssembly(ApplicationLayerAssembly);

        services
            .AddIdentityCore<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<IdentityUser>>()
            .AddUserManager<UserManager<IdentityUser>>();

        services
            .AddIdentityServer(
                options => options.Discovery.CustomEntries.Add(
                    "registration_endpoint",
                    "~/connect/register"))
            .AddInMemoryIdentityResources(Config.IdentityResources)
            .AddInMemoryApiScopes(Config.ApiScopes)
            .AddInMemoryClients(Config.Clients)
            .AddProfileService<ProfileService<IdentityUser>>()
            .AddAspNetIdentity<IdentityUser>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:5110";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });

        services.AddControllers();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGenWithPasswordSecurity();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.OAuthClientId("bytebank-api-swagger-ui-client");
                options.OAuthAppName("ByteBank Swagger UI Client");
                options.OAuthUsePkce();
            });
        }

        app.UseRouting();

        app.UseIdentityServer();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}