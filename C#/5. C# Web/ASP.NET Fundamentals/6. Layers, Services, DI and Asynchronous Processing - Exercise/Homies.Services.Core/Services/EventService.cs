using Microsoft.EntityFrameworkCore;

using Homies.Data;
using Homies.Data.Models;
using Homies.DataTransferObjects.Event;
using static Homies.GCommon.Constants.ApplicationConstants;
using Homies.Services.Core.Contracts;

namespace Homies.Services.Core.Services;

public class EventService : IEventService
{
    private readonly ITypeService _typeService;
    private readonly HomiesDbContext _dbContext;

    public EventService(ITypeService typeService, HomiesDbContext dbContext)
    {
        _typeService = typeService;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync()
    {
        IEnumerable<EventAllViewModel> allEventsViewModel = await _dbContext.Events
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
            .ToArrayAsync();

        return allEventsViewModel;
    }

    public async Task<EventInputModel> GetEventInputModelAsync()
    {
        EventInputModel eventInputModel = new()
        {
            Types = await _typeService.GetTypesAsync(),
        };

        return eventInputModel;
    }

    public async Task AddEventAsync(EventInputModel eventInputModel, string currentUserId)
    {
        Event newEvent = new()
        {
            Name = eventInputModel.Name,
            Description = eventInputModel.Description,
            OrganiserId = currentUserId,
            CreatedOn = DateTime.Now,
            Start = eventInputModel.Start,
            End = eventInputModel.End,
            TypeId = eventInputModel.TypeId,
        };

        await _dbContext.Events.AddAsync(newEvent);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<EventDetailsViewModel?> GetEventDetailsAsync(int id)
    {
        EventDetailsViewModel? eventDetailsViewModel = await _dbContext.Events
            .Where(e => e.Id == id)
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
            .FirstOrDefaultAsync();

        return eventDetailsViewModel;
    }

    public async Task<EventInputModel?> GetEventForEditAsync(int id, string currentUserId)
    {
        Event? requestedEvent = await _dbContext.Events.FindAsync(id);
        if (requestedEvent == null)
        {
            return null;
        }

        if (requestedEvent.OrganiserId != currentUserId)
        {
            throw new UnauthorizedAccessException();
        }

        EventInputModel eventInputModel = new()
        {
            Name = requestedEvent.Name,
            Description = requestedEvent.Description,
            Start = requestedEvent.Start,
            End = requestedEvent.End,
            TypeId = requestedEvent.TypeId,
            Types = await _typeService.GetTypesAsync(),
        };

        return eventInputModel;
    }

    public async Task<bool> EditEventAsync(int id, EventInputModel eventInputModel, string currentUserId)
    {
        Event? requestedEvent = await _dbContext.Events.FindAsync(id);
        if (requestedEvent == null)
        {
            return false;
        }

        if (requestedEvent.OrganiserId != currentUserId)
        {
            throw new UnauthorizedAccessException();
        }

        if (!(await _typeService.GetTypesAsync())
            .Any(t => t.Id == eventInputModel.TypeId))
        {
            throw new ArgumentException("Type does not exist!");
        }

        requestedEvent.Name = eventInputModel.Name;
        requestedEvent.Description = eventInputModel.Description;
        requestedEvent.Start = eventInputModel.Start;
        requestedEvent.End = eventInputModel.End;
        requestedEvent.TypeId = eventInputModel.TypeId;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<EventAllViewModel>> GetJoinedEventsAsync(string currentUserId)
    {
        IEnumerable<EventAllViewModel> joinedEventsViewModel = await _dbContext.Events
            .Where(e => e.Participants.Any(ep => ep.HelperId == currentUserId))
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
            .ToArrayAsync();

        return joinedEventsViewModel;
    }

    public async Task<bool> JoinAsync(int eventId, string currentUserId)
    {
        Event? requestedEvent = await _dbContext.Events.FindAsync(eventId);
        if (requestedEvent == null)
        {
            return false;
        }

        EventParticipant newEventParticipant = new()
        {
            EventId = eventId,
            HelperId = currentUserId,
        };

        if (await _dbContext.EventsParticipants.ContainsAsync(newEventParticipant))
        {
            return false;
        }

        await _dbContext.EventsParticipants.AddAsync(newEventParticipant);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> LeaveAsync(int eventId, string currentUserId)
    {
        Event? requestedEvent = await _dbContext.Events.FindAsync(eventId);
        if (requestedEvent == null)
        {
            return false;
        }

        EventParticipant? eventParticipant = await _dbContext.EventsParticipants
            .FirstOrDefaultAsync(ep => ep.EventId == eventId && ep.HelperId == currentUserId);
        if (eventParticipant == null)
        {
            return false;
        }

        _dbContext.EventsParticipants.Remove(eventParticipant);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
