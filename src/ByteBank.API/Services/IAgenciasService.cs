// <copyright file="IAgenciasService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services
{
    public interface IAgenciasService
    {
        Task<bool> AlteraAgenciaAsync(AgenciaRequest agencia);

        Task<AgenciaViewModel?> BuscaAgenciaPorIdAsync(int id);

        Task<List<AgenciaViewModel>?> BuscaAgenciasAsync();

        Task<AgenciaViewModel> CriaAgenciaAsync(AgenciaRequest agencia);

        Task<bool> DeletaAgenciaAsync(int id);
    }
}