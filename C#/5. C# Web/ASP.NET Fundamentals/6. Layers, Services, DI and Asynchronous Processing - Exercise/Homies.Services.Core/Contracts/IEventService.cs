using Homies.DataTransferObjects.Event;

namespace Homies.Services.Core.Contracts;

public interface IEventService
{
    Task<IEnumerable<EventAllViewModel>> GetAllEventsAsync();

    Task<EventInputModel> GetEventInputModelAsync();

    Task AddEventAsync(EventInputModel eventInputModel, string currentUserId);

    Task<EventDetailsViewModel?> GetEventDetailsAsync(int id);

    Task<EventInputModel?> GetEventForEditAsync(int id, string currentUserId);

    Task<bool> EditEventAsync(int id, EventInputModel eventInputModel, string currentUserId);

    Task<IEnumerable<EventAllViewModel>> GetJoinedEventsAsync(string currentUserId);

    Task<bool> JoinAsync(int eventId, string currentUserId);

    Task<bool> LeaveAsync(int eventId, string currentUserId);
}
