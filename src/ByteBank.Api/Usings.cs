global using System.Reflection;

global using ByteBank.Api.Extensions;
global using ByteBank.Api.Identity;
global using ByteBank.Application.Errors;
global using ByteBank.Application.Middlewares;
global using ByteBank.Application.Requests;
global using ByteBank.Domain.AggregateModels.AgenciaAggregates;
global using ByteBank.Domain.AggregateModels.ClienteAggregates;
global using ByteBank.Domain.AggregateModels.ContaAggregates;
global using ByteBank.Domain.SeedWork;
global using ByteBank.Infrastructure.Data.ByteBank;
global using ByteBank.Infrastructure.Data.ByteBank.Repositories;
global using ByteBank.Infrastructure.Data.Identity;

global using Duende.IdentityServer.AspNetIdentity;
global using Duende.IdentityServer.Models;

global using FluentResults;

global using FluentValidation;

global using MediatR;

global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;