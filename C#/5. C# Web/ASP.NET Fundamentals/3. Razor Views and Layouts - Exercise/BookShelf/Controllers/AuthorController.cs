using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BookShelf.Data;
using BookShelf.Data.Models;
using static BookShelf.Common.ApplicationConstants;

namespace BookShelf.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookShelfDbContext _dbContext;

        public AuthorController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Author> authors = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id)
                .Take(EntitiesPerPage)
                .ToArray();

            return View(authors);
        }

        public IActionResult Details(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("There was something wrong with your request! Please try again!");
            }

            Author? authorWithBooks = _dbContext.Authors
                .Include(a => a.Books)
                .SingleOrDefault(a => a.Id == id);
            if (authorWithBooks == null)
            {
                return NotFound("Author could not be found! Please try again!");
            }

            return View(authorWithBooks);
        }
    }
}
