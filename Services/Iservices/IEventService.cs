using EventManagement.Models;

namespace EventManagement.Services.Iservices
{
    public interface IEventService
    {
        Task<string> AddEventAsync(Events events);
        Task<string> UpdateEventAsync(Events events);
        Task<string> DeleteEventAsync(Users users);
        Task<string> GetOneEventAsync();

        Task<IEnumerable<Events>> GetAllEventsAsync();
    }
}
