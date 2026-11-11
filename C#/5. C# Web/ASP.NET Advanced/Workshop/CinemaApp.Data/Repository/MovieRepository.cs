using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Common;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Data.Repository;

public class MovieRepository : BaseSoftDeletableRepository<Movie>, IMovieRepository
{
    public MovieRepository(CinemaDbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<Movie?> FindByIdAsync(Guid id)
        => await DbSet.FindAsync(id);
}
