// <copyright file="IContaCorrenteRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

namespace ByteBank.API.Repository.Interface
{
    public interface IContaCorrenteRepository
    {
        Task<Conta?> BuscaPorIdAsync(int id);

        Task<IEnumerable<Conta>> BuscaTodosAsync();

        Task<IEnumerable<Conta>> BuscaTodosPaginadoAsync(int pagina, int tamanhoPagina);

        Task<IEnumerable<Conta>> BuscaPorCpfTitularAsync(string cpf);

        Task<IEnumerable<Conta>> BuscaPorNomeTitularAsync(string nome);
    }
}