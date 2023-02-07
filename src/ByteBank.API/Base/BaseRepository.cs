// <copyright file="BaseRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Microsoft.EntityFrameworkCore;

namespace ByteBank.API.Base;

public class BaseRepository<T> : IBaseRepository<T>
    where T:class
{
    private readonly DbContext? context;
    public BaseRepository(DbContext context)
    {
      this.context = context;
    }
    public async Task AlteraAsync(int id, T obj)
    {
        context.Set<T>().Update(obj);
        await context.SaveChangesAsync();
    }

    public async Task<T> BuscaPorIdAsync(int id)
    {
        return await context.Set<T>().FindAsync(id);
    }
    public async Task<List<T>> BuscaTodosAsync()
    {
        return await context.Set<T>().AsNoTracking().ToListAsync();
    }
    public async Task CriarAsync(T obj)
    {
        await context.Set<T>().AddAsync(obj);
        await context.SaveChangesAsync();
    }
    public async Task DeletaAsync(int id)
    {
        var entity = await this.BuscaPorIdAsync(id);
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }
    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}