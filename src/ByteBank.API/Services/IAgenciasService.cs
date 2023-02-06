// <copyright file="IAgenciasService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

namespace ByteBank.API.Services
{
    public interface IAgenciasService
    {
        Task<bool> AlteraAgenciaAsync(Agencia agencia);

        Task<Agencia?> BuscaAgenciaPorIdAsync(int id);

        Task<List<Agencia>?> BuscaAgenciasAsync();

        Task<Agencia> CriaAgenciaAsync(Agencia agencia);

        Task<bool> DeletaAgenciaAsync(int id);
    }
}