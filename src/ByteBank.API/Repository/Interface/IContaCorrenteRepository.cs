// <copyright file="IContaCorrenteRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Base;
using ByteBank.API.Models;

namespace ByteBank.API.Repository.Interface
{
    public interface IContaCorrenteRepository : IBaseRepository<Conta>
    {
        Task<IEnumerable<Conta>> BuscaPorCpfTitularAsync(string cpf);

        Task<IEnumerable<Conta>> BuscaPorNomeTitularAsync(string nome);
    }
}