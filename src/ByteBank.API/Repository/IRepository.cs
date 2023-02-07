// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ByteBank.API.Repository
{
    public interface IRepository<T>
    {
        Task AlteraAsync(T obj);

        Task<T> BuscaPorIdAsync(int id);

        Task<List<T>> BuscaTodosAsync();

        Task CriarAsync(T obj);

        Task DeletaAsync(T obj);
    }
}