using EventManagement.Data;
using EventManagement.Models;
using EventManagement.Services.Iservices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EventManagement.Services
{
    public class EventService : IEventService
    {
        private readonly AppDbContext _context;
        
        public EventService(AppDbContext context)
        {
            _context = context;
            
        }
        public async Task<string> AddEventAsync(Events events)
        {


            _context.Events.Add(events);
            await _context.SaveChangesAsync();
            return "Event Created Successfully";


        }

        public async Task<string> DeleteEventAsync(Events events)
        {
            _context.Events.Remove(events);
            await _context.SaveChangesAsync();
            return "Event Deleted Successfully";
        }

        public async Task<IEnumerable<Events>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

    



        public async Task<Events> GetEventByIdAsync(Guid id)
        {

            return await _context.Events.Where(e => e.EventId == id)
              .Include(e => e.Users)
              .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Events>> basedOnLocation(string? location)
        {
            var query = _context.Events.AsQueryable<Events>();
            query = query.Where(e => e.Location.ToLower().Contains(location.ToLower()));
            return (await query.ToListAsync());
        }

       


        public async Task<string> UpdateEventAsync(Events events)
        {
            _context.Events.Update(events);
            await _context.SaveChangesAsync();
            return "Event Updated Successfully";
        }
    }
}

