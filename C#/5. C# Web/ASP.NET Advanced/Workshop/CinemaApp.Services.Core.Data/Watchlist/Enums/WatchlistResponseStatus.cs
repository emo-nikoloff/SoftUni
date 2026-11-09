namespace CinemaApp.Services.Core.Data.Watchlist.Response.Enums;

public enum WatchlistResponseStatus
{
    Success = 0,
    InvalidReference = 1,
    DuplicatedEntry = 2,
    EntityNotFound = 4,
    GeneralError = 8,
}
