using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using EventManager.Data;
using EventManager.ViewModels.Events;
using static EventManager.Common.ApplicationConstants;
using EventManager.ViewModels.Categories;
using EventManager.Data.Models;

namespace EventManager.Controllers
{
    public class EventController : Controller
    {
        private readonly EventManagerDbContext _dbContext;

        public EventController(EventManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index(
            [FromQuery] string? title,
            [FromQuery] int? categoryId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate)
        {
            IQueryable<Event> allEventsQuery = _dbContext.Events;

            if (!string.IsNullOrWhiteSpace(title))
            {
                title = title.Trim();
                allEventsQuery = allEventsQuery
                    .Where(e => EF.Functions.Like(e.Title, $"%{title}%"));
            }

            if (categoryId.HasValue)
            {
                allEventsQuery = allEventsQuery
                    .Where(e => e.CategoryId == categoryId.Value);
            }

            if (fromDate.HasValue)
            {
                allEventsQuery = allEventsQuery
                    .Where(e => e.StartDate >= fromDate.Value.Date);
            }

            if (toDate.HasValue)
            {
                allEventsQuery = allEventsQuery
                    .Where(e => e.StartDate < toDate.Value.Date.AddDays(1));
            }

            IEnumerable<EventIndexViewModel> allEventsViewModel = allEventsQuery
                .OrderByDescending(e => e.StartDate)
                .ThenBy(e => e.EndDate)
                .ThenBy(e => e.Title)
                .ThenByDescending(e => e.MaxParticipants)
                .Select(e => new EventIndexViewModel
                {
                    Id = e.Id,
                    Title = e.Title,
                    CategoryName = e.Category.Name,
                    StartDate = e.StartDate.ToString(DateTimeFormat),
                    EndDate = e.EndDate.ToString(DateTimeFormat),
                    CurrentParticipants = e.Registrations.Count(),
                    MaxParticipants = e.MaxParticipants,
                    Description = e.Description
                })
                .Take(EntitiesPerPage)
                .ToArray();

            ViewBag.Categories = LoadAllCategoriesDropdownData();
            ViewBag.FilterTitle = title;
            ViewBag.CategoryId = categoryId;
            ViewBag.FromDate = fromDate?.ToString("yyyy-MM-dd");
            ViewBag.ToDate = toDate?.ToString("yyyy-MM-dd");

            return View(allEventsViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<CategoryDropdownViewModel> allCategoriesDropdownViewModels = LoadAllCategoriesDropdownData();
            EventInputModel inputModel = new()
            {
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                Categories = allCategoriesDropdownViewModels
            };

            return View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(EventInputModel inputEvent)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid event data was detected! Please try again"); /* когато ключът е празен стринг, грешката се отразява за цялото
                                                                                                                                  entity, а не за определено property */
                inputEvent.Categories = LoadAllCategoriesDropdownData();

                return View(inputEvent);
            }

            bool isCategoryValid = _dbContext.Categories
                .Any(c => c.Id == inputEvent.CategoryId);
            if (!isCategoryValid)
            {
                ModelState.AddModelError(nameof(EventInputModel.CategoryId), "Invalid category is selected!");
                inputEvent.Categories = LoadAllCategoriesDropdownData();

                return View(inputEvent);
            }

            try
            {
                Event newEvent = new()
                {
                    Title = inputEvent.Title,
                    Description = inputEvent.Description,
                    StartDate = inputEvent.StartDate,
                    EndDate = inputEvent.EndDate,
                    MaxParticipants = inputEvent.MaxParticipants,
                    CategoryId = inputEvent.CategoryId,
                };

                _dbContext.Events.Add(newEvent);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }

            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<CategoryDropdownViewModel> LoadAllCategoriesDropdownData()
        {
            return _dbContext.Categories
                .OrderBy(c => c.Name)
                .ThenBy(c => c.Id)
                .Select(c => new CategoryDropdownViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToArray();
        }
    }
}
