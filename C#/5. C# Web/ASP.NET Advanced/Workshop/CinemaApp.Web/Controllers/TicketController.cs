using Microsoft.AspNetCore.Mvc;

using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Ticket.Response;
using CinemaApp.Web.ViewModels.UserTicket;
using static CinemaApp.GCommon.ApplicationConstants;

namespace CinemaApp.Web.Controllers
{
    public class TicketController : BaseController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string userId = GetUserId()!;
            IEnumerable<GetUserAllTicketsResponseModel> responseData =
                await _ticketService.GetUserAllTicketsByUserIdAsync(userId);

            IEnumerable<UserTicketIndexViewModel> indexViewModel = responseData
                .Select(t => new UserTicketIndexViewModel
                {
                    CinemaName = t.CinemaName,
                    MovieTitle = t.MovieTitle,
                    MovieImageUrl = t.MovieImageUrl ?? DefaultImageUrl,
                    Price = t.Price.ToString(PriceFormat),
                    TicketsCount = t.Quantity.ToString(),
                });

            return View(indexViewModel);
        }
    }
}
