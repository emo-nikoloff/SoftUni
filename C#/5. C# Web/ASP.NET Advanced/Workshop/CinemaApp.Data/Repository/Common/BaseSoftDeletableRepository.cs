using Microsoft.EntityFrameworkCore;

using CinemaApp.Data.Common.Models;
using CinemaApp.Data.Repository.Contracts.Common;

namespace CinemaApp.Data.Repository.Common;

public class BaseSoftDeletableRepository<TEntity> : BaseRepository<TEntity>, ISoftDeletableRepository<TEntity>
    where TEntity : class, ISoftDeletableEntity
{
    public BaseSoftDeletableRepository(CinemaDbContext dbContext)
        : base(dbContext)
    {
    }

    public IQueryable<TEntity> AllWithDeleted()
        => DbSet.IgnoreQueryFilters().AsQueryable();

    public IQueryable<TEntity> AllWithDeletedAsNoTracking()
        => DbSet.IgnoreQueryFilters().AsNoTracking().AsQueryable();

    public void SoftDelete(TEntity entity)
        => entity.IsDeleted = true;

    public void Recover(TEntity entity)
        => entity.IsDeleted = true;
}
