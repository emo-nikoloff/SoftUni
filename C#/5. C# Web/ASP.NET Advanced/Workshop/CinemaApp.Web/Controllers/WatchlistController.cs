using Microsoft.AspNetCore.Mvc;

using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Watchlist.Response;
using CinemaApp.Services.Core.Data.Watchlist.Response.Enums;
using CinemaApp.Web.ViewModels.Watchlist;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    public class WatchlistController : BaseController
    {
        private readonly IWatchlistService _watchlistService;

        public WatchlistController(IWatchlistService watchlistService)
        {
            _watchlistService = watchlistService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId()!;
            UserFullWatchlistResponseData watchlistResponseData =
                await _watchlistService.GetUserFullWatchlistDataAsync(userId);

            IEnumerable<WatchlistViewModel> watchlistViewModel = watchlistResponseData.Movies
                .Select(m => new WatchlistViewModel
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(DateFormat),
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl,
                })
                .ToArray();

            return View(watchlistViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            string userId = GetUserId()!;
            WatchlistServiceStatusResponseModel responseData =
                await _watchlistService.AddMovieToWatchlistAsync(userId, id.Value);
            if (responseData.Status == WatchlistResponseStatus.InvalidReference)
            {
                return NotFound();
            }
            else if (responseData.Status == WatchlistResponseStatus.GeneralError)
            {
                // TODO: Add JS notification about the error
            }

            return RedirectToAction(nameof(Index), "Movie");
        }
    }
}
