﻿
using HouseRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Infrastructure.Common;

public class Repository : IRepository
{
    private readonly DbContext context;

    public Repository(HouseRentingSystemDbContext _context)
    {
        context = _context;       
    }

    private DbSet<T> DbSet<T>() where T : class
    {
        return context.Set<T>();
    }

    public IQueryable<T> All<T>() where T : class
    {
        return DbSet<T>();
    }

    public IQueryable<T> AllReadOnly<T>() where T : class
    {
        return DbSet<T>()
            .AsNoTracking();
    }

    public async Task AddAsync<T>(T entity) where T : class
    {
        await DbSet<T>().AddAsync(entity);
    }


    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();    }

    public Task RemoveAsync<T>(T entity) where T : class
    {
        DbSet<T>().Remove(entity);
        return Task.CompletedTask;
    }
}
