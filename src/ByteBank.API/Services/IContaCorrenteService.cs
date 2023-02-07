// <copyright file="IContaCorrenteService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Dtos;

namespace ByteBank.API.Services
{
    public interface IContaCorrenteService
    {
        Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesAsync();

        Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPaginadoAsync(int pagina, int tamanhoPagina);

        Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPorCpfTitularAsync(string cpf);

        Task<IEnumerable<ContaCorrenteDto>> BuscaContasCorrentesPorNomeTitularAsync(string nome);

        Task<ContaCorrenteDto?> BuscaContaCorrentePorIdAsync(int id);
    }
}