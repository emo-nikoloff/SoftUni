using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Homies.DataTransferObjects.Event;
using Homies.Services.Core.Contracts;

namespace Homies.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ITypeService _typeService;

        public EventController(IEventService eventService, ITypeService typeService)
        {
            _eventService = eventService;
            _typeService = typeService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            IEnumerable<EventAllViewModel> allEventsViewModel = await _eventService.GetAllEventsAsync();

            return View(allEventsViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventInputModel eventInputModel = await _eventService.GetEventInputModelAsync();

            return View(eventInputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(EventInputModel eventInputModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid event data was detected! Please try again!");
                eventInputModel.Types = await _typeService.GetTypesAsync();

                return View(eventInputModel);
            }

            bool typeIdExists = (await _typeService.GetTypesAsync())
                .Any(t => t.Id == eventInputModel.TypeId);
            if (!typeIdExists)
            {
                ModelState.AddModelError(nameof(eventInputModel.TypeId), "Please select a valid type!");
                eventInputModel.Types = await _typeService.GetTypesAsync();

                return View(eventInputModel);
            }

            string userId = ValidateAuthorizedUserId(GetUserId());
            await _eventService.AddEventAsync(eventInputModel, userId);

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            EventDetailsViewModel? eventDetailsViewModel = await _eventService.GetEventDetailsAsync(id.Value);
            if (eventDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(eventDetailsViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            try
            {
                string userId = ValidateAuthorizedUserId(GetUserId());

                EventInputModel? requestedEvent = await _eventService.GetEventForEditAsync(id.Value, userId);
                if (requestedEvent == null)
                {
                    return NotFound();
                }

                return View(requestedEvent);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, EventInputModel eventInputModel)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            if (!ModelState.IsValid)
            {
                eventInputModel.Types = await _typeService.GetTypesAsync();

                return View(eventInputModel);
            }

            try
            {
                string userId = ValidateAuthorizedUserId(GetUserId());

                bool request = await _eventService.EditEventAsync(id.Value, eventInputModel, userId);
                if (!request)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(All));
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(nameof(eventInputModel.TypeId), ex.Message);
                eventInputModel.Types = await _typeService.GetTypesAsync();

                return View(eventInputModel);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = ValidateAuthorizedUserId(GetUserId());

            IEnumerable<EventAllViewModel> joinedEventsViewModel = await _eventService.GetJoinedEventsAsync(userId);

            return View(joinedEventsViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Join([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            bool requestedEvent = await _eventService.JoinAsync(id.Value, userId);
            if (!requestedEvent)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Joined));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Leave([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            bool requestedEvent = await _eventService.LeaveAsync(id.Value, userId);
            if (!requestedEvent)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(All));
        }

        private string? GetUserId()
        {
            string? userId = null;

            Claim? idClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (idClaim != null)
            {
                userId = idClaim.Value;
            }

            return userId;
        }

        private string ValidateAuthorizedUserId(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new InvalidOperationException("General identity error occurred - id is null in authorized area!");
            }

            return userId;
        }
    }
}
