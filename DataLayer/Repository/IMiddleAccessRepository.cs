using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace DataLayer;
public interface IMiddleAccessRepository<TEntity> where TEntity : class, IBaseEntity
{
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? predicate);
    int Count(Expression<Func<TEntity, bool>>? predicate);
    void Remove(TEntity entity);
    void Update(TEntity entity);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);

    Task<TEntity?> FindSingle(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity?> FindFirst(Expression<Func<TEntity, bool>> predicate);
    Task<List<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> GetAllList();

}

public class MiddleAccessRepository<TEntity> : IMiddleAccessRepository<TEntity> where TEntity : class, IBaseEntity
{
    protected readonly DbContext DbContext;

    protected MiddleAccessRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }


    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>>? predicate)
    {
        if (predicate == null)
            return await DbContext.Set<TEntity>().AnyAsync();
        return await DbContext.Set<TEntity>().AnyAsync(predicate);
    }

    public void Remove(TEntity entity)
    {
        DbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        DbContext.Set<TEntity>().Update(entity);
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbContext.Set<TEntity>().AddAsync(entity);
    }

    public int Count(Expression<Func<TEntity, bool>>? predicate)
    {
        if (predicate == null)
            return DbContext.Set<TEntity>().Count();
        return DbContext.Set<TEntity>().Count(predicate);
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return DbContext.Set<TEntity>().AnyAsync(predicate);
    }

    public async Task<TEntity?> FindSingle(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().SingleOrDefaultAsync(predicate);
    }

    public async Task<TEntity?> FindFirst(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<List<TEntity>> FindList(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<List<TEntity>> GetAllList()
    {
        return await DbContext.Set<TEntity>().ToListAsync();
    }

}