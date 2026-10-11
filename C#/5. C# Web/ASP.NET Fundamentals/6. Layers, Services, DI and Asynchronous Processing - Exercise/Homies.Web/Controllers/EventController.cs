using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Homies.Web.Data;
using Homies.Web.Data.Models;
using Homies.Web.ViewModels.Event;
using static Homies.Web.Common.ApplicationConstants;
using Homies.Web.ViewModels.Type;

namespace Homies.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly HomiesDbContext _dbContext;

        public EventController(HomiesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
        {
            IEnumerable<EventAllViewModel> allEventsViewModel = _dbContext.Events
                .OrderBy(e => e.Name)
                .ThenByDescending(e => e.Start)
                .Select(e => new EventAllViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    TypeName = e.Type.Name,
                    OrganiserUsername = e.Organiser.UserName ?? string.Empty,
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(allEventsViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Add()
        {
            EventInputModel inputModel = new()
            {
                Types = LoadTypeDropdownEntries(),
            };

            return View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(EventInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid event data was detected! Please try again!");
                inputModel.Types = LoadTypeDropdownEntries();

                return View(inputModel);
            }

            bool typeIdExists = _dbContext.Types
                .Any(t => t.Id == inputModel.TypeId);
            if (!typeIdExists)
            {
                ModelState.AddModelError(nameof(EventInputModel.TypeId), "Please select a valid type!");
                inputModel.Types = LoadTypeDropdownEntries();

                return View(inputModel);
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            Event newEvent = new()
            {
                Name = inputModel.Name,
                Description = inputModel.Description,
                OrganiserId = userId,
                CreatedOn = DateTime.Now,
                Start = inputModel.Start,
                End = inputModel.End,
                TypeId = inputModel.TypeId,
            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            EventDetailsViewModel? eventDetailsViewModel = _dbContext.Events
                .Where(e => e.Id == id.Value)
                .Select(e => new EventDetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DateTimeFormat),
                    End = e.End.ToString(DateTimeFormat),
                    Organiser = e.Organiser.UserName ?? string.Empty,
                    CreatedOn = e.CreatedOn.ToString(DateTimeFormat),
                    Type = e.Type.Name,
                })
                .FirstOrDefault();

            if (eventDetailsViewModel == null)
            {
                return NotFound();
            }

            return View(eventDetailsViewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            Event? requestedEvent = _dbContext.Events.Find(id);
            if (requestedEvent == null)
            {
                return NotFound();
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            bool isUserOrganiserOfEvent = requestedEvent.OrganiserId == userId;
            if (!isUserOrganiserOfEvent)
            {
                TempData["Error"] = "You can edit only the events, that you are organising!";

                return RedirectToAction(nameof(All));
            }

            IEnumerable<TypeDropdownViewModel> typeDropdownEntries = LoadTypeDropdownEntries();
            EventInputModel eventInputModel = new()
            {
                Name = requestedEvent.Name,
                Description = requestedEvent.Description,
                Start = requestedEvent.Start,
                End = requestedEvent.End,
                TypeId = requestedEvent.TypeId,
                Types = typeDropdownEntries,
            };

            return View(eventInputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, EventInputModel inputModel)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            Event? requestedEvent = _dbContext.Events.Find(id);
            if (requestedEvent == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                inputModel.Types = LoadTypeDropdownEntries();

                return View(inputModel);
            }

            bool typeIdExists = _dbContext.Types
                .Any(t => t.Id == inputModel.TypeId);
            if (!typeIdExists)
            {
                ModelState.AddModelError(nameof(EventInputModel.TypeId), "Please select a valid type!");
                inputModel.Types = LoadTypeDropdownEntries();

                return View(inputModel);
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            bool isUserOrganiserOfEvent = requestedEvent.OrganiserId == userId;
            if (!isUserOrganiserOfEvent)
            {
                TempData["Error"] = "You can edit only the events, that you are organising!";

                return RedirectToAction(nameof(All));
            }

            requestedEvent.Name = inputModel.Name;
            requestedEvent.Description = inputModel.Description;
            requestedEvent.Start = inputModel.Start;
            requestedEvent.End = inputModel.End;
            requestedEvent.TypeId = inputModel.TypeId;

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Joined()
        {
            string userId = ValidateAuthorizedUserId(GetUserId());

            IEnumerable<EventAllViewModel> joinedEventsViewModel = _dbContext.Events
                .Where(e => e.Participants.Any(ep => ep.HelperId == userId))
                .OrderBy(e => e.Name)
                .ThenByDescending(e => e.Start)
                .Select(e => new EventAllViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DateTimeFormat),
                    TypeName = e.Type.Name,
                    OrganiserUsername = e.Organiser.UserName ?? string.Empty,
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(joinedEventsViewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Join([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            Event? requestedEvent = _dbContext.Events.Find(id);
            if (requestedEvent == null)
            {
                return NotFound();
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            bool isUserOrganiserOfEvent = requestedEvent.OrganiserId == userId;
            if (isUserOrganiserOfEvent)
            {
                TempData["Error"] = "You can't join events, organised by you!";

                return RedirectToAction(nameof(All));
            }

            bool userAlreadyJoined = requestedEvent.Participants
                .Any(ep => ep.HelperId == userId);
            if (!userAlreadyJoined)
            {
                EventParticipant newEventParticipant = new()
                {
                    EventId = id.Value,
                    HelperId = userId,
                };

                _dbContext.EventsParticipants.Add(newEventParticipant);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Joined));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Leave([FromRoute] int? id)
        {
            if (!id.HasValue || id <= 0)
            {
                return BadRequest("There was an issue with your request!");
            }

            Event? requestedEvent = _dbContext.Events.Find(id);
            if (requestedEvent == null)
            {
                return NotFound();
            }

            string userId = ValidateAuthorizedUserId(GetUserId());

            EventParticipant? eventParticipant = _dbContext.EventsParticipants
                .FirstOrDefault(ep => ep.EventId == id.Value && ep.HelperId == userId);

            if (eventParticipant != null)
            {
                _dbContext.EventsParticipants.Remove(eventParticipant);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(All));
        }

        private IEnumerable<TypeDropdownViewModel> LoadTypeDropdownEntries()
        {
            IEnumerable<TypeDropdownViewModel> typeDropdownEntries = _dbContext.Types
                .OrderBy(t => t.Name)
                .Select(t => new TypeDropdownViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToArray();

            return typeDropdownEntries;
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
