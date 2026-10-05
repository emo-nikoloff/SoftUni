using Microsoft.AspNetCore.Mvc;

using GameZone.Data;
using GameZone.ViewModels.Game;
using static GameZone.Common.ApplicationConstants;
using GameZone.ViewModels.Genre;
using GameZone.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        /* ASP.NET Core спецификации:
         * Животът на контролера е равен на един HTTP Request-Response
         * DbContext се инжектира през Constructor Injection, следователно трябва да направим така, че всеки HTTP Request-Response да използва нова инстанция на DbContext
         * .AddDbContext<>() регистрира DbContext като Scoped Service 
            * Scoped Service Lifetime - всяка нова инстанция живее само за текущия контекст */

        private readonly ILogger<GameController> _logger;

        private readonly GameZoneDbContext _dbContext;

        public GameController(ILogger<GameController> logger, GameZoneDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult All()
        {
            IEnumerable<GameAllViewModel> gameAllViewModels = _dbContext.Games
                .OrderByDescending(g => g.ReleasedOn)
                .ThenBy(g => g.Title)
                .ThenBy(g => g.Genre.Name)
                .Select(g => new GameAllViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.PublisherName,
                    ReleasedOn = g.ReleasedOn.ToString(ApplicationDateFormat),
                    GenreName = g.Genre.Name
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(gameAllViewModels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            GameInputModel inputModelAsViewModel = new()
            {
                ReleasedOn = DateTime.Today,
                Genres = LoadAllGenresDropdownItems()
            };

            return View(inputModelAsViewModel);
        }

        [HttpPost]
        public IActionResult Add(GameInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Genres = LoadAllGenresDropdownItems();

                // Връща същото View като GET метода, но попълнено с User Input Binded Data + автоматично попълнени Model Validation Errors
                return View(inputModel);
            }

            bool genreExists = _dbContext.Genres
                .Any(g => g.Id == inputModel.GenreId);
            if (!genreExists)
            {
                ModelState.AddModelError(nameof(GameInputModel.GenreId), "Invalid genre is selected!");
                inputModel.Genres = LoadAllGenresDropdownItems();

                return View(inputModel);
            }

            try
            {
                Game newGame = new()
                {
                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    ImageUrl = inputModel.ImageUrl,
                    PublisherName = inputModel.PublisherName,
                    ReleasedOn = inputModel.ReleasedOn,
                    GenreId = inputModel.GenreId
                };

                _dbContext.Games.Add(newGame);
                _dbContext.SaveChanges();

                TempData["Success"] = "Game added successfully!";
            }
            catch (Exception)
            {
                _logger.LogCritical("Error occurred while saving valid Game data! Check logs as soon as possible!");

                TempData["Error"] = "Unexpected error occurred while saving your data! Please try again later!";
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            GameDetailsViewModel? gameDetailsViewModel = _dbContext.Games
                .Select(g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.PublisherName,
                    ReleasedOn = g.ReleasedOn.ToString(ApplicationDateFormat),
                    GenreName = g.Genre.Name
                })
                .SingleOrDefault(g => g.Id == id.Value);
            if (gameDetailsViewModel == null)
            {
                return NotFound("Requested game was not found! Try again!");
            }

            return View(gameDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            GameInputModel? editingGame = _dbContext.Games
                .Where(g => g.Id == id.Value)
                .Select(g => new GameInputModel
                {
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    PublisherName = g.PublisherName,
                    ReleasedOn = g.ReleasedOn,
                    GenreId = g.GenreId,
                })
                .SingleOrDefault();
            if (editingGame == null)
            {
                return NotFound("Requested game was not found! Try again!");
            }

            editingGame.Genres = LoadAllGenresDropdownItems();

            return View(editingGame);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, GameInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                inputModel.Genres = LoadAllGenresDropdownItems();

                return View(inputModel);
            }

            bool genreExists = _dbContext.Genres
                .Any(g => g.Id == inputModel.GenreId);
            if (!genreExists)
            {
                ModelState.AddModelError(nameof(GameInputModel.GenreId), "Invalid genre is selected!");
                inputModel.Genres = LoadAllGenresDropdownItems();

                return View(inputModel);
            }

            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            Game? editingGame = _dbContext.Games.Find(id);
            if (editingGame == null)
            {
                return NotFound("Requested game was not found! Try again!");
            }

            try
            {
                editingGame.Title = inputModel.Title;
                editingGame.Description = inputModel.Description;
                editingGame.ImageUrl = inputModel.ImageUrl;
                editingGame.PublisherName = inputModel.PublisherName;
                editingGame.ReleasedOn = inputModel.ReleasedOn;
                editingGame.GenreId = inputModel.GenreId;

                _dbContext.SaveChanges();

                TempData["Success"] = "Game edited successfully!";
            }
            catch (Exception)
            {
                _logger.LogCritical("Error occurred while saving valid Game data! Check logs as soon as possible!");

                TempData["Error"] = "Unexpected error occurred while saving your data! Please try again later!";
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public IActionResult Delete([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            GameDeleteViewModel? deletingGame = _dbContext.Games
                .Select(g => new GameDeleteViewModel
                {
                    Id = g.Id,
                    Title = g.Title
                })
                .SingleOrDefault(g => g.Id == id.Value);
            if (deletingGame == null)
            {
                return NotFound("Requested game was not found! Try again!");
            }

            return View(deletingGame);
        }

        [HttpPost]
        public IActionResult Delete([FromRoute] int? id, GameDeleteViewModel inputModel)
        {
            if (!id.HasValue || id.Value <= 0 || id.Value != inputModel.Id)
            {
                return BadRequest("There was an error with your request! Try again!");
            }

            Game? deletingGame = _dbContext.Games.Find(id);
            if (deletingGame == null)
            {
                return NotFound("Requested game was not found! Try again!");
            }

            try
            {
                _dbContext.Games.Remove(deletingGame);
                _dbContext.SaveChanges();

                TempData["Success"] = "Game deleted successfully!";
            }
            catch (Exception)
            {
                _logger.LogCritical("Error occurred while deleting valid Game data! Check logs as soon as possible!");

                TempData["Error"] = "Unexpected error occurred while deleting your data! Please try again later!";
            }

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<GenreDropdownViewModel> LoadAllGenresDropdownItems()
        {
            IEnumerable<GenreDropdownViewModel> allGenresDropdownItems = _dbContext.Genres
                .OrderBy(g => g.Name)
                .ThenBy(g => g.Id)
                .Select(g => new GenreDropdownViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToArray();

            return allGenresDropdownItems;
        }
    }
}
