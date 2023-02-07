// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Base;

public class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    private readonly DbContext context;

    public BaseRepository(DbContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AlteraAsync(int id, T obj)
    {
        this.context.Set<T>().Update(obj);
        await this.context.SaveChangesAsync();
    }

    public async Task<T?> BuscaPorIdAsync(int id)
    {
        return await this.context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> BuscaTodosAsync()
    {
        return await this.context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task CriarAsync(T obj)
    {
        await this.context.Set<T>().AddAsync(obj);
        await this.context.SaveChangesAsync();
    }

    public async Task DeletaAsync(int id)
    {
        var entity = await this.BuscaPorIdAsync(id);

        if (entity == null)
        {
            return;
        }

        this.context.Set<T>().Remove(entity);
        await this.context.SaveChangesAsync();
    }
}