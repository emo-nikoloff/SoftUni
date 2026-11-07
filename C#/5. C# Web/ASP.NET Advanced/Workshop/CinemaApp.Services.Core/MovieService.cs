using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using CinemaApp.Data;
using CinemaApp.Services.Common.Utilities;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Request;
using CinemaApp.Services.Core.Data.Movie.Response;
using CinemaApp.Data.Models;
using CinemaApp.Services.Core.Data.Enums;

namespace CinemaApp.Services.Core;

public class MovieService : IMovieService
{
    private readonly CinemaDbContext _dbContext;

    private readonly BasicModelValidator _modelValidator;

    private readonly ILogger<MovieService> _logger;

    public MovieService(CinemaDbContext dbContext, ILogger<MovieService> logger)
    {
        _dbContext = dbContext;
        _modelValidator = new();
        _logger = logger;
    }

    public async Task<IEnumerable<GetAllMoviesResponseModel>> GetAllMoviesAsync()
    {
        // TODO: Implement Mapperly for auto generation of mapping code

        IEnumerable<GetAllMoviesResponseModel> moviesResponseData = await _dbContext.Movies
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

        return moviesResponseData;
    }

    public async Task<MovieServiceStatusResponseModel> CreateMovieAsync(CreateMovieRequestData requestData)
    {
        MovieServiceStatusResponseModel response = new();

        bool isInputDataValid = _modelValidator.IsValid(requestData);
        if (!isInputDataValid)
        {
            response.Status = MovieServiceResponseStatus.InvalidRequest;
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

                response.Status = MovieServiceResponseStatus.Success;
            }
            catch (DbUpdateException ex)
            {
                // TODO: Log the exception details for further analysis and debugging

                response.Status = MovieServiceResponseStatus.GeneralError;
                response.ErrorMessages = new List<string?>()
                {
                    ex.Message,
                };
            }
        }

        return response;
    }

    public async Task<MovieBasicDataResponseModel?> GetMovieBasicDataByIdAsync(Guid id)
    {
        MovieBasicDataResponseModel? responseData = null;

        Movie? dbMovie =
            await _dbContext.Movies.FindAsync(id);
        if (dbMovie != null)
        {
            responseData = new()
            {
                Id = dbMovie.Id,
                Title = dbMovie.Title,
                Genre = dbMovie.Genre,
                ImageUrl = dbMovie.ImageUrl,
            };
        }

        return responseData;
    }

    public async Task<MovieExtendedDataResponseModel?> GetMovieExtendedDataByIdAsync(Guid id)
    {
        MovieExtendedDataResponseModel? responseData = null;

        Movie? dbMovie =
            await _dbContext.Movies.FindAsync(id);
        if (dbMovie != null)
        {
            responseData = new()
            {
                Id = dbMovie.Id,
                Title = dbMovie.Title,
                Genre = dbMovie.Genre,
                ReleaseDate = dbMovie.ReleaseDate,
                Director = dbMovie.Director,
                Duration = dbMovie.Duration,
                Description = dbMovie.Description,
                ImageUrl = dbMovie.ImageUrl,
            };
        }

        return responseData;
    }

    public async Task<MovieServiceStatusResponseModel> EditMovieAsync(EditMovieRequestData requestData)
    {
        MovieServiceStatusResponseModel response = new()
        {
            Status = MovieServiceResponseStatus.GeneralError,
            ErrorMessages = new List<string?>(),
        };

        Movie? dbMovie =
            await _dbContext.Movies.FindAsync(requestData.Id);
        if (dbMovie == null)
        {
            response.Status = MovieServiceResponseStatus.NotFound;
        }

        bool isRequestDataValid = _modelValidator.IsValid(requestData);
        if (!isRequestDataValid)
        {
            response.Status = MovieServiceResponseStatus.InvalidRequest;
            response.ErrorMessages = _modelValidator.ValidationResults
                .Select(vr => vr.ErrorMessage);
        }

        try
        {
            if (dbMovie != null)
            {
                dbMovie.Title = requestData.Title;
                dbMovie.Genre = requestData.Genre;
                dbMovie.ReleaseDate = requestData.ReleaseDate;
                dbMovie.Director = requestData.Director;
                dbMovie.Duration = requestData.Duration;
                dbMovie.Description = requestData.Description;
                dbMovie.ImageUrl = requestData.ImageUrl;

                await _dbContext.SaveChangesAsync();

                response.Status = MovieServiceResponseStatus.Success;
            }
        }
        catch (DbUpdateException ex)
        {
            response.Status = MovieServiceResponseStatus.GeneralError;
            response.ErrorMessages = new List<string?>()
            {
                ex.Message,
            };
        }

        return response;
    }

    public async Task<MovieServiceStatusResponseModel> SoftDeleteMovieAsync(Guid id)
    {
        MovieServiceStatusResponseModel response = new()
        {
            Status = MovieServiceResponseStatus.GeneralError,
            ErrorMessages = new List<string?>(),
        };

        Movie? dbMovie =
            await _dbContext.Movies.FindAsync(id);
        if (dbMovie == null)
        {
            response.Status = MovieServiceResponseStatus.NotFound;

            return response;
        }

        if (dbMovie.IsDeleted)
        {
            _logger.LogWarning($"Soft delete was performed for already deleted entity! Entity Id: {id}");
        }

        try
        {
            dbMovie.IsDeleted = true;
            await _dbContext.SaveChangesAsync();

            response.Status = MovieServiceResponseStatus.Success;
        }
        catch (DbUpdateException ex)
        {
            response.Status = MovieServiceResponseStatus.GeneralError;
            response.ErrorMessages = new List<string?>()
            {
                ex.Message,
            };
        }

        return response;
    }

    public async Task<MovieServiceStatusResponseModel> HardDeleteMovieAsync(Guid id)
    {
        MovieServiceStatusResponseModel response = new()
        {
            Status = MovieServiceResponseStatus.GeneralError,
            ErrorMessages = new List<string?>(),
        };

        Movie? dbMovie =
            await _dbContext.Movies.FindAsync(id);
        if (dbMovie == null)
        {
            response.Status = MovieServiceResponseStatus.NotFound;

            return response;
        }

        if (dbMovie.IsDeleted)
        {
            _logger.LogWarning($"Hard delete was performed for soft-deleted entity! Entity Id: {id}");
            response.Status = MovieServiceResponseStatus.Success;
        }
        else
        {
            try
            {
                _dbContext.Movies.Remove(dbMovie);
                await _dbContext.SaveChangesAsync();

                response.Status = MovieServiceResponseStatus.Success;
            }
            catch (DbUpdateException ex)
            {
                response.Status = MovieServiceResponseStatus.GeneralError;
                response.ErrorMessages = new List<string?>()
                {
                    ex.Message,
                };
            }
        }

        return response;
    }
}
