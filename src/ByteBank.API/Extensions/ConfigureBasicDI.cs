// <copyright file="ConfigureDependencyInjection.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Data;
using ByteBank.API.Models;
using ByteBank.API.Repository;
using ByteBank.API.Repository.Interface;
using ByteBank.API.Request;
using ByteBank.API.Request.DTO;
using ByteBank.API.Request.Validator;
using ByteBank.API.Services.Handlers;
using ByteBank.API.Services.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.CompilerServices;

namespace ByteBank.API.Extensions;

public static class ConfigureBasicDI
{
    public static void ConfigureDI(this IServiceCollection services)
    {
        ConfigureAppServices(services);
    }

    internal static void ConfigureAppServices(IServiceCollection services)
    {


        services.AddAutoMapper(typeof(Program));
        services.AddScoped<ByteBankContext>();
        //Repositorys
        services.AddScoped<IAgenciaRepository, AgenciasRepository>();
        services.AddTransient<IClienteRepository, ClienteRepository>();
        services.AddTransient<IEnderecoAgenciaRepository, EnderecoAgenciaRepository>();
        services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
        //Services
        services.AddScoped<IAgenciasService, AgenciasService>();
        services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IEnderecoAgenciasService, EnderecoAgenciasService>();
        //Validator
        services.AddScoped<IValidator<EnderecoAgenciaRequest>, EnderecoAgenciaValidator>();
        services.AddScoped<IValidator<AgenciaRequest>, AgenciaValidator>();
        services.AddScoped<IValidator<UserDTO>, UsuarioDTOValidator>();
        services.AddScoped<IValidator<ClienteRequest>, ClienteValidator>();
    }
}