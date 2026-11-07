using Microsoft.EntityFrameworkCore;

using CinemaApp.Data;
using CinemaApp.Services.Common.Utilities;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;
using CinemaApp.Data.Models;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly CinemaDbContext _dbContext;

    private readonly BasicModelValidator _modelValidator;

    public MovieService(CinemaDbContext dbContext)
    {
        _dbContext = dbContext;
        _modelValidator = new();
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

    public async Task<MovieServiceStatusResponseModel> CreateMovieAsync(CreateMovieRequestData requestData)
    {
        MovieServiceStatusResponseModel response = new();

        bool isInputDataValid = _modelValidator.IsValid(requestData);
        if (!isInputDataValid)
        {
            response.Status = false;
            response.ErrorMessages = _modelValidator.ValidationResults
                .Select(vr => vr.ErrorMessage);
        }
        else
        {
            Movie movie = new()
            {
                Title = requestData.Title,
                Genre = requestData.Genre,
                ReleaseDate = requestData.ReleaseDate,
                Director = requestData.Director,
                Duration = requestData.Duration,
                Description = requestData.Description,
                ImageUrl = requestData.ImageUrl,
            };

            try
            {
                await _dbContext.Movies.AddAsync(movie);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
            }
            catch (DbUpdateException ex)
            {
                // TODO: Log the exception details for further analysis and debugging

                response.Status = false;
                response.ErrorMessages = new List<string?>()
                {
                    ex.Message,
                };
            }
        }

        return response;
    }
}
