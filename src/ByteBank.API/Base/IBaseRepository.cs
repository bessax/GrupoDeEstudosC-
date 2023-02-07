// <copyright file="IBaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ByteBank.API.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task AlteraAsync(int id,T obj);

        Task<T> BuscaPorIdAsync(int id);

        Task<List<T>> BuscaTodosAsync();

        Task CriarAsync(T obj);

        Task DeletaAsync(int id);
    }
}