// <copyright file="IAgenciasService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Request;
using ByteBank.API.ViewModels;

namespace ByteBank.API.Services.Interfaces
{
    public interface IEnderecoAgenciasService
    {
        Task<bool> AlteraEnderecoAgenciaAsync(EnderecoAgenciaRequest objRequest);

        Task<EnderecoAgenciaViewModel?> BuscaEnderecoAgenciaPorIdAsync(int id);

        Task<List<EnderecoAgenciaViewModel>?> BuscaEnderecoAgenciasAsync();

        Task<EnderecoAgenciaViewModel> CriaEnderecoAgenciaAsync(EnderecoAgenciaRequest objRequest);

        Task<bool> DeletaEnderecoAgenciaAsync(int id);
    }
}