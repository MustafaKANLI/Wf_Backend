﻿namespace UsersService.Infrastructure.Persistence.Repositories;

using UsersService.Application.Interfaces.Repositories;
using UsersService.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Common.Exceptions;

public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
{
    private readonly UsersServiceDbContext _dbContext;

    public GenericRepositoryAsync(UsersServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
    {
        return await _dbContext
            .Set<T>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        var result = _dbContext.Entry(entity).State = EntityState.Modified;
        var entitySetName = _dbContext.Model.FindEntityType(typeof(T)).GetTableName();
        if (entity != null)
        {
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ApiException(entitySetName + " cannot found!");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbContext.Set<T>().FindAsync(id);
        var entitySetName =  _dbContext.Model.FindEntityType(typeof(T)).GetTableName();
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ApiException(entitySetName + " cannot found!");
        }
     
    }


    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _dbContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<int> GetDataCount()
    {
        return await _dbContext
        .Set<T>()
        .CountAsync();
    }

    public async Task MarkUnchangedAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Unchanged;
    }

    public async Task MarkDetachedAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Detached;
    }

    public async Task MarkModifiedAsync(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public async Task ClearChangeTracker()
    {
        _dbContext.ChangeTracker.Clear();
    }
}
