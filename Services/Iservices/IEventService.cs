using EventManagement.Models;
using Microsoft.Extensions.Logging;

namespace EventManagement.Services.Iservices
{
    public interface IEventService
    {
        Task<string> AddEventAsync(Events events);
        Task<string> UpdateEventAsync(Events events);
        Task<string> DeleteEventAsync(Events events);
        Task<Events> GetEventByIdAsync(Guid id);
        Task<IEnumerable<Events>> GetAllAsync();

        //return events based on location
        Task<IEnumerable<Events>> basedOnLocation(string? location);
        //Task<IEnumerable<Events>> GetAllEventsAsync(Guid eventId, string Location);
        //get all users for an events
        
    }
}
