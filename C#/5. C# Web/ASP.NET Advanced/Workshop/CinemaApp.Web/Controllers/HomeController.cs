namespace CinemaApp.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using CinemaApp.Web.Infrastructure.Filters;
    using CinemaApp.Web.ViewModels;

    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ServiceFilter(typeof(PhoneRequiredActionFilter))]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int? statusCode)
        {
            ErrorViewModel error = statusCode switch
            {
                400 => new ErrorViewModel
                {
                    StatusCode = 400,
                    Title = "Bad request",
                    Message = "The request could not be understood. Please check the information and try again.",
                    Icon = "bi-exclamation-triangle"
                },
                404 => new ErrorViewModel
                {
                    StatusCode = 404,
                    Title = "Page not found",
                    Message = "The scene you are looking for is not in this cinema. It may have moved or gone off the schedule.",
                    Icon = "bi-film"
                },
                403 => new ErrorViewModel
                {
                    StatusCode = 403,
                    Title = "Access forbidden",
                    Message = "You do not have permission to access this scene.",
                    Icon = "bi-shield-lock"
                },
                _ => new ErrorViewModel
                {
                    StatusCode = 500,
                    Title = "Something went wrong",
                    Message = "The projector hit a snag. Please try again in a moment.",
                    Icon = "bi-tools"
                }
            };

            error.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            HttpContext.Response.StatusCode = error.StatusCode;

            return View(error);
        }
    }
}
