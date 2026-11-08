using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Movie.Response;
using CinemaApp.Web.ViewModels.Movie;
using CinemaApp.Services.Core.Data.Movie.Request;
using static CinemaApp.GCommon.ApplicationConstants;
using static CinemaApp.GCommon.ErrorMessages;
using static CinemaApp.GCommon.ErrorMessages.Movie;
using CinemaApp.Services.Core.Data.Movie.Enums;

namespace CinemaApp.Web.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IMovieService _movieService;

        private readonly IWatchlistService _watchlistService;

        public MovieController(IMovieService movieService, IWatchlistService watchlistService)
        {
            _movieService = movieService;
            _watchlistService = watchlistService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetAllMoviesResponseModel> allMoviesResponseData =
                await _movieService.GetAllMoviesAsync();

            IEnumerable<AllMoviesIndexViewModel> allMoviesViewModelData = allMoviesResponseData
                .Select(m => new AllMoviesIndexViewModel()
                {
                    Id = m.Id.ToString(),
                    Title = m.Title,
                    Genre = m.Genre,
                    ReleaseDate = m.ReleaseDate.ToString(DefaultImageUrl, CultureInfo.InvariantCulture),
                    Director = m.Director,
                    ImageUrl = m.ImageUrl ?? DefaultImageUrl,
                })
                .ToArray();

            if (IsUserAuthenticated)
            {
                foreach (AllMoviesIndexViewModel movie in allMoviesViewModelData)
                {
                    movie.IsInUserWatchlist =
                        await _watchlistService.IsMovieInUserWatchlistAsync(GetUserId()!, Guid.Parse(movie.Id));
                }
            }

            return View(allMoviesViewModelData);
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
            if (statusResponse.Status == MovieServiceResponseStatus.GeneralError)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return View(inputModel);
            }

            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            MovieExtendedDataResponseModel? movieExtendedData =
                await _movieService.GetMovieExtendedDataByIdAsync(id.Value);
            if (movieExtendedData == null)
            {
                return NotFound();
            }

            MovieDetailsViewModel movieDetailsViewModel = new()
            {
                Id = movieExtendedData.Id.ToString(),
                Title = movieExtendedData.Title,
                Genre = movieExtendedData.Genre,
                ReleaseDate = movieExtendedData.ReleaseDate.ToString(DateFormat),
                Director = movieExtendedData.Director,
                Duration = movieExtendedData.Duration,
                Description = movieExtendedData.Description,
                ImageUrl = movieExtendedData.ImageUrl ?? DefaultImageUrl,
            };

            return View(movieDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            MovieExtendedDataResponseModel? movieExtendedData =
                await _movieService.GetMovieExtendedDataByIdAsync(id.Value);
            if (movieExtendedData == null)
            {
                return NotFound();
            }

            MovieFormInputModel movieFormModel = new()
            {
                Title = movieExtendedData.Title,
                Genre = movieExtendedData.Genre,
                ReleaseDate = movieExtendedData.ReleaseDate.ToString(DateFormat),
                Director = movieExtendedData.Director,
                Duration = movieExtendedData.Duration,
                Description = movieExtendedData.Description,
                ImageUrl = movieExtendedData.ImageUrl,
            };

            return View(movieFormModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] Guid? id, MovieFormInputModel inputModel)
        {
            if (id == null)
            {
                return BadRequest();
            }

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

            EditMovieRequestData editMovieRequestData = new()
            {
                Id = id.Value,
                Title = inputModel.Title,
                Genre = inputModel.Genre,
                ReleaseDate = releaseDate,
                Duration = inputModel.Duration,
                Director = inputModel.Director,
                Description = inputModel.Description,
                ImageUrl = inputModel.ImageUrl,
            };

            MovieServiceStatusResponseModel responseData =
                await _movieService.EditMovieAsync(editMovieRequestData);
            if (responseData.Status == MovieServiceResponseStatus.InvalidRequest)
            {
                return BadRequest();
            }
            else if (responseData.Status == MovieServiceResponseStatus.NotFound)
            {
                return NotFound();
            }
            else if (responseData.Status == MovieServiceResponseStatus.GeneralError)
            {
                ModelState.AddModelError(string.Empty, GeneralErrorMessage);

                return View(editMovieRequestData);
            }

            return RedirectToAction(nameof(Details), new { id = id.Value.ToString() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            MovieBasicDataResponseModel? movieBasicData =
                await _movieService.GetMovieBasicDataByIdAsync(id.Value);
            if (movieBasicData == null)
            {
                return NotFound();
            }

            MovieDeleteViewModel movieDeleteViewModel = new()
            {
                Id = movieBasicData.Id.ToString(),
                Title = movieBasicData.Title,
                ImageUrl = movieBasicData.ImageUrl ?? DefaultImageUrl,
            };

            return View(movieDeleteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute] Guid? id, [FromForm] MovieDeleteViewModel viewModel)
        {
            if (id == null)
            {
                return BadRequest();
            }

            MovieServiceStatusResponseModel deleteStatus =
                await _movieService.SoftDeleteMovieAsync(id.Value);
            if (deleteStatus.Status == MovieServiceResponseStatus.NotFound)
            {
                return NotFound();
            }
            else if (deleteStatus.Status == MovieServiceResponseStatus.GeneralError)
            {
                ModelState.AddModelError(string.Empty, "");

                return View(viewModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
