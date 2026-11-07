using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Response;
using CinemaApp.Web.ViewModels.Movie;
using static CinemaApp.GCommon.ApplicationConstants;
using static CinemaApp.GCommon.ErrorMessages;
using static CinemaApp.GCommon.ErrorMessages.Movie;
using CinemaApp.Services.Core.Data.Movie.Request;
using Humanizer;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllMoviesResponseModel> allMoviesResponseDate =
                await _movieService.GetAllMoviesAsync();

            IEnumerable<AllMoviesIndexViewModel> allMoviesViewModelDate = allMoviesResponseDate
                .Select(m => new AllMoviesIndexViewModel()
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(DefaultImageUrl, CultureInfo.InvariantCulture),
                    Director = m.Director,
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl,
                });

            return View(allMoviesViewModelDate);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] MovieFormInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            bool isReleaseDateValid = DateTime.TryParseExact(
                inputModel.ReleaseDate,
                DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime releaseDate);
            if (!isReleaseDateValid)
            {
                ModelState.AddModelError(nameof(MovieFormInputModel.ReleaseDate), ReleaseDateFormatMessage);

                return View(inputModel);
            }

            CreateMovieRequestData createMovieRequest = new()
            {
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Duration = inputModel.Duration,
                Director = inputModel.Director,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl,
            };

            MovieServiceStatusResponseModel statusResponse =
                await _movieService.CreateMovieAsync(createMovieRequest);
            if (!statusResponse.Status)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
