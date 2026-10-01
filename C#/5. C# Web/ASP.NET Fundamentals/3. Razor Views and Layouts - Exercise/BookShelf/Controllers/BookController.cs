using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using BookShelf.Data;
using BookShelf.Data.Models;
using static BookShelf.Common.ApplicationConstants;

namespace BookShelf.Controllers
{
    public class BookController : Controller
    {
        private readonly BookShelfDbContext _dbContext;

        public BookController(BookShelfDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> booksWithAuthors = _dbContext.Books
                .Include(b => b.Author)
                .OrderBy(b => b.Title)
                .ThenByDescending(b => b.Year)
                .ThenBy(b => b.Id)
                .Take(EntitiesPerPage)
                .ToArray();

            return View(booksWithAuthors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //  Добър дизайн: използвайте front-end application, за да зареждате всички автори chunk-wise (на порции) посредством API
            IEnumerable<Author> authors = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id);
            ViewBag.Authors = authors;

            return View();
        }

        public IActionResult Create(Book book)
        {
            IEnumerable<Author> authors = _dbContext.Authors
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id);

            bool authorExists = authors.Any(a => a.Id == book.AuthorId);
            if (!authorExists)
            {
                ModelState.AddModelError(nameof(Book.AuthorId), "Invalid author was selected!");
                ViewBag.Authors = authors;

                return View(book);
            }

            try
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "General error occurred while adding your book! Please contact our support!");
                ViewBag.Authors = authors;

                return View(book);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
