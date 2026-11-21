using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using CinemaApp.Services.Core.Contracts;
using CinemaApp.Services.Core.Data.Ticket.Request;

using static CinemaApp.GCommon.InputValidationConstants.Ticket;

namespace CinemaApp.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketApiController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IProjectionService _projectionService;

        public TicketApiController(ITicketService ticketService, IProjectionService projectionService)
        {
            _ticketService = ticketService;
            _projectionService = projectionService;
        }

        [Authorize]
        [AutoValidateAntiforgeryToken]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("[action]")]
        public async Task<ActionResult> BuyTicket([FromForm] Guid? projectionId, [FromForm] int quantity)
        {
            if (!projectionId.HasValue ||
                quantity < MinimumPurchaseQuantity)
            {
                return BadRequest();
            }

            int ticketsAvailable =
                await _projectionService
                    .GetProjectionAvailabilityAsync(projectionId.Value);
            int ticketsBought =
                await _ticketService
                    .GetBoughtTicketsPerProjectionAsync(projectionId.Value);
            if (ticketsBought + quantity > ticketsAvailable)
            {
                return BadRequest("The available tickets are less than the selected quantity!");
            }

            BuyTicketsRequestModel requestData = new()
            {
                ProjectionId = projectionId.Value,
                UserId = GetUserId()!,
                Quantity = quantity,
            };

            bool ticketBuySuccess =
                await _ticketService.BuyTicketsByUserIdAndProjectionIdAsync(requestData);
            if (!ticketBuySuccess)
            {
                return NotFound();
            }

            return Ok();
        }

        private string? GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
