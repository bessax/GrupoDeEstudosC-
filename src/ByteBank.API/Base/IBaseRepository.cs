// <copyright file="IBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ByteBank.API.Models;

namespace ByteBank.API.Base
{
    public interface IBaseRepository<T>
        where T : class
    {
        Task AlteraAsync(int id, T obj);

        Task<T?> BuscaPorIdAsync(int id);

        Task<List<T>> BuscaTodosAsync();

        Task CriarAsync(T obj);

        Task DeletaAsync(int id);

        Task<IEnumerable<T>> BuscaTodosPaginadoAsync(int page, int pageSize);
    }
}