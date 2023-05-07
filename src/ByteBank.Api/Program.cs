var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var assemblies = new Dictionary<string, Assembly>
{
    ["App"] = Assembly.Load("ByteBank.Application")
};

services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddScoped<IAgenciaRepository, AgenciaRepository>();
services.AddScoped<IClienteRepository, ClienteRepository>();
services.AddScoped<IContaRepository, ContaRepository>();
services.AddScoped<IAgenciaRepository, AgenciaRepository>();
services.AddScoped(
    typeof(IGenericRepository<>),
    typeof(GenericRepository<>));

services.AddDbContext<ByteBankContext>(
    options => options.UseSqlServer(
        "Name=ByteBankConnection"));

services.AddMediatR(
    c => c.RegisterServicesFromAssembly(
        assemblies["App"]));

services.AddValidatorsFromAssembly(
    assemblies["App"]);

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider
        .GetRequiredService<ByteBankContext>()
        .Database.MigrateAsync();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();