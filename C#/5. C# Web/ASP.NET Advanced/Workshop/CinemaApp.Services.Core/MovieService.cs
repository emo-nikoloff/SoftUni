using CinemaApp.Data;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Response;
using Microsoft.EntityFrameworkCore;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly CinemaDbContext _dbContext;

    public MovieService(CinemaDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<GetAllMoviesResponseModel>> GetAllMoviesAsync()
    {
        // TODO: Implement Mapperly for auto generation of mapping code
        IEnumerable<GetAllMoviesResponseModel> moviesResponseDate = await _dbContext.Movies
            .OrderBy(m => m.Title)
            .ThenBy(m => m.Genre)
            .Select(m => new GetAllMoviesResponseModel()
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                ReleaseDate = m.ReleaseDate,
                Director = m.Director,
                ImageUrl = m.ImageUrl,
            })
            .ToArrayAsync();

        return moviesResponseDate;
    }
}
