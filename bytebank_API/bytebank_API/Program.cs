using Microsoft.EntityFrameworkCore;
using bytebank_API.Data;
using bytebank_API.Repository;
using bytebank_API.Repository.EFCore;
using bytebank_API.Models;
using bytebank_API.Services;
using bytebank_API.Services.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ByteBankContext>(options =>
{
    options.UseSqlServer("Name=ByteBankConnection");
});
builder.Services.AddScoped<IRepository<Agencia>, AgenciasRepository>();
builder.Services.AddScoped<IAgenciasService, AgenciasService>();

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ByteBankContext>();
    context.Database.Migrate();
}

app.Run();
