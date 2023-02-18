// <copyright file="ConfigureDependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Repository;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Request.Validator;
using ByteBank.API.Services.Handlers;
using ByteBank.API.Services.Interfaces;
using FluentValidation;
using System;
using System.Runtime.CompilerServices;

namespace ByteBank.API.Extensions;

public static class ConfigureDependencyInjection
{
    public static void ConfigureDI(this IServiceCollection services)
    {
        ConfigureAppServices(services);
    }

    internal static void ConfigureAppServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));
        services.AddScoped<ByteBankContext>();
        services.AddScoped<IValidator<EnderecoAgenciaRequest>, EnderecoAgenciaValidator>();
        services.AddScoped<IRepository<Agencia>, AgenciasRepository>();
        services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
        services.AddScoped<IAgenciasService, AgenciasService>();
        services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddScoped<IEnderecoAgenciasService, EnderecoAgenciasService>();
        services.AddTransient<IEnderecoAgenciaRepository, EnderecoAgenciaRepository>();
        services.AddScoped<IValidator<AgenciaRequest>, AgenciaValidator>();
    }
}