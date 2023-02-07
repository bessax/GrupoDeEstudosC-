// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Repository;
using ByteBank.API.Repository.EFCore;
using ByteBank.API.Services;
using ByteBank.API.Services.Handlers;

using Microsoft.EntityFrameworkCore;

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