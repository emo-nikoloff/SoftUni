using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Repository.Contracts.Common;

namespace CinemaApp.Data.Repository.Common;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>, IDisposable
    where TEntity : class
{
    protected BaseRepository(CinemaDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<TEntity>();
    }

    protected CinemaDbContext DbContext { get; }

    protected DbSet<TEntity> DbSet { get; }

    public IQueryable<TEntity> All()
        => DbSet.AsQueryable();

    public IQueryable<TEntity> AllAsNoTracking()
        => DbSet.AsNoTracking().AsQueryable();

    public void Add(TEntity entity)
        => DbSet.Add(entity);

    public async Task AddAsync(TEntity entity)
        => await DbSet.AddAsync(entity);

    public void AddRange(IEnumerable<TEntity> entityCollection)
        => DbSet.AddRange(entityCollection);

    public async Task AddRangeAsync(IEnumerable<TEntity> entityCollection)
        => await DbSet.AddRangeAsync(entityCollection);

    public void Update(TEntity entity)
        => DbSet.Update(entity);

    public void UpdateRange(IEnumerable<TEntity> entityCollection)
        => DbSet.UpdateRange(entityCollection);

    public void Remove(TEntity entity)
        => DbSet.Remove(entity);

    public void RemoveRange(IEnumerable<TEntity> entityCollection)
        => DbSet.RemoveRange(entityCollection);

    public int SaveChanges()
        => DbContext.SaveChanges();

    public async Task<int> SaveChangesAsync()
        => await DbContext.SaveChangesAsync();

    public void Dispose()
    {
        DbContext.Dispose();
    }
}
