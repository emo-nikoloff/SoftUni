using CinemaApp.Services.Core.Data.Watchlist.Response.Enums;

namespace CinemaApp.Services.Core.Data.Watchlist.Response;

public class WatchlistServiceStatusResponseModel
{
    public WatchlistResponseStatus Status { get; set; }

    public ICollection<string?> ErrorMessages { get; set; } = new List<string?>();
}
