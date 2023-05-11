namespace ByteBank.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            MigrateByteBankDatabase(scope);
            MigrateIdentityDatabase(scope);
        }

        host.Run();
    }
    
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());

    private static void MigrateByteBankDatabase(IServiceScope scope)
    {
        scope.ServiceProvider
            .GetRequiredService<ByteBankContext>()
            .Database
            .Migrate();
    }

    private static void MigrateIdentityDatabase(IServiceScope scope)
    {
        scope.ServiceProvider
            .GetRequiredService<IdentityContext>()
            .Database
            .Migrate();
    }
}