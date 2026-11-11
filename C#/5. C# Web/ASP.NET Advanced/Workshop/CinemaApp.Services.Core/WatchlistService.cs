using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using CinemaApp.Data;
using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Watchlist.Response;
using CinemaApp.Services.Core.Data.Watchlist.Response.Enums;
using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts;

namespace CinemaApp.Services.Core;

public class WatchlistService : IWatchlistService
{
    private readonly IMovieRepository _movieRepository;

    private readonly IUserMovieRepository _userMovieRepository;

    private readonly UserManager<IdentityUser> _userManager;

    public WatchlistService(IUserMovieRepository userMovieRepository, UserManager<IdentityUser> userManager, IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
        _userMovieRepository = userMovieRepository;
        _userManager = userManager;
    }

    public async Task<UserFullWatchlistResponseData> GetUserFullWatchlistDataAsync(string userId)
    {
        IEnumerable<WatchlistMovieDataModel> userWatchlistMoviesData = await _userMovieRepository
            .AllAsNoTracking()
            .Where(um => um.UserId.ToLower() == userId.ToLower())
            .Select(um => um.Movie)
            .OrderBy(m => m.Title)
            .ThenBy(m => m.Genre)
            .Select(m => new WatchlistMovieDataModel
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                ReleaseDate = m.ReleaseDate,
                ImageUrl = m.ImageUrl,
            })
            .ToArrayAsync();

        UserFullWatchlistResponseData userFullWatchlistResponseData = new()
        {
            Movies = userWatchlistMoviesData,
        };

        return userFullWatchlistResponseData;
    }

    public async Task<bool> IsMovieInUserWatchlistAsync(string userId, Guid movieId)
    {
        bool isMovieInWatchlist =
            await _userMovieRepository
                .AllAsNoTracking()
                .AnyAsync(um => um.UserId.ToLower() == userId.ToLower() &&
                                                    um.MovieId == movieId);

        return isMovieInWatchlist;
    }

    public async Task<WatchlistServiceStatusResponseModel> AddMovieToWatchlistAsync(string userId, Guid movieId)
    {
        WatchlistServiceStatusResponseModel responseData = new()
        {
            Status = WatchlistResponseStatus.GeneralError,
            ErrorMessages = new List<string?>(),
        };

        IdentityUser? user =
            await _userManager.FindByIdAsync(userId);

        bool movieExists =
            await _movieRepository
                .AllAsNoTracking()
                .AnyAsync(m => m.Id == movieId);
        if (!movieExists)
        {
            responseData.Status = WatchlistResponseStatus.InvalidReference;
            responseData.ErrorMessages.Add("Referenced movie does not exist!");
        }

        if (user == null)
        {
            responseData.Status = WatchlistResponseStatus.InvalidReference;
            responseData.ErrorMessages.Add("Referenced user does not exist!");
        }

        bool watchlistEntryExists =
            await _userMovieRepository
                .AllAsNoTracking()
                .AnyAsync(um => um.UserId.ToLower() == userId.ToLower() &&
                                                    um.MovieId == movieId);
        if (watchlistEntryExists)
        {
            responseData.Status = WatchlistResponseStatus.DuplicatedEntry;
        }
        else
        {
            try
            {
                UserMovie userMovie = new()
                {
                    UserId = userId,
                    MovieId = movieId,
                };

                await _userMovieRepository.AddAsync(userMovie);
                await _userMovieRepository.SaveChangesAsync();

                responseData.Status = WatchlistResponseStatus.Success;
            }
            catch (DbUpdateException ex)
            {
                responseData.Status = WatchlistResponseStatus.GeneralError;
                responseData.ErrorMessages = new List<string?>()
                {
                    ex.Message,
                };
            }
        }

        return responseData;
    }

    public async Task<WatchlistServiceStatusResponseModel> RemoveMovieFromWatchlistAsync(string userId, Guid movieId)
    {
        WatchlistServiceStatusResponseModel responseData = new()
        {
            Status = WatchlistResponseStatus.GeneralError,
            ErrorMessages = new List<string?>(),
        };

        IdentityUser? dbUser =
            await _userManager.FindByIdAsync(userId);

        bool movieExists =
            await _movieRepository
                .AllAsNoTracking()
                .AnyAsync(m => m.Id == movieId);
        if (!movieExists)
        {
            responseData.Status = WatchlistResponseStatus.InvalidReference;
            responseData.ErrorMessages.Add("Referenced movie does not exist!");
        }

        if (dbUser == null)
        {
            responseData.Status = WatchlistResponseStatus.InvalidReference;
            responseData.ErrorMessages.Add("Referenced user does not exist!");
        }

        UserMovie? dbWatchlistEntry =
            await _userMovieRepository
                .All()
                .SingleOrDefaultAsync(um => um.UserId.ToLower() == userId.ToLower() &&
                                                                um.MovieId == movieId);
        if (dbWatchlistEntry == null)
        {
            responseData.Status = WatchlistResponseStatus.EntityNotFound;
        }
        else
        {
            try
            {
                _userMovieRepository.Remove(dbWatchlistEntry);
                await _userMovieRepository.SaveChangesAsync();

                responseData.Status = WatchlistResponseStatus.Success;
            }
            catch (DbUpdateException ex)
            {
                responseData.Status = WatchlistResponseStatus.GeneralError;
                responseData.ErrorMessages = new List<string?>()
                {
                    ex.Message,
                };
            }
        }

        return responseData;
    }
}
