using AutoMapper;
using EventManagement.Profiles;
using EventManagement.Models;
using EventManagement.Requests;
using EventManagement.Responses;
using EventManagement.Services.Iservices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EventManagement.Data;
using Microsoft.AspNetCore.Authorization;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEventService _eventService;

        

        public EventsController(IEventService service, IMapper mapper)
        {
            _mapper = mapper;
            _eventService = service;


        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpPost]
        public async Task<ActionResult<SuccessResponse>> AddEvent(AddEvent newEvent)
        {
            var events = _mapper.Map<Events>(newEvent);
            var res = await _eventService.AddEventAsync(events);
            return CreatedAtAction(nameof(AddEvent), new SuccessResponse(201, res));

        }
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<EventResponse>>> GetAllAsync()
        {
            var response = await _eventService.GetAllAsync();
            var events = _mapper.Map<IEnumerable<EventResponse>>(response);
            return Ok(events);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EventResponse>> GetEventByIdAsync([FromQuery] Guid id)
        {
            var response = await _eventService.GetEventByIdAsync(id);
            if (response == null)
            {
                return NotFound(new SuccessResponse(404, "Event Does Not Exist"));
            }

            var events = _mapper.Map<EventResponse>(response);
            return Ok(events);


        }
        //get Event by location
        [HttpGet("location")]
        public async Task<ActionResult<IEnumerable<Events>>> GetEventsByLocation(string? location)
        {
            var Events = await _eventService.basedOnLocation(location);
            return Events.ToList();
        }
        //Event capacity
        [HttpGet("Capacity{id}")]
        public async Task<ActionResult<int>> GetEventCapacity(Guid id)
        {
            var SelectedEvent = await _eventService.GetEventByIdAsync(id);
            if (SelectedEvent == null)
            {
                return BadRequest("Event Does not Exist");
            }
            var Capacity = SelectedEvent.Capacity;
            var BookedSlots = SelectedEvent.Users.Count;
            var remainingSlots = Capacity - BookedSlots;

            return remainingSlots;
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpPut("{id}")]
        public async Task<ActionResult<SuccessResponse>> UpdateEvent(Guid id, AddEvent UpdatedEvent)
        {
               var response = await _eventService.GetEventByIdAsync(id);
               if (response == null)
               {
                  return NotFound(new SuccessResponse(404, "Event Does Not Exist"));
               }
               //update
              var updated = _mapper.Map(UpdatedEvent, response);
              var res = await _eventService.UpdateEventAsync(updated);
              return Ok(new SuccessResponse(204, res));
        }
        [Authorize(Policy = "AdminPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SuccessResponse>> DeleteEvent(Guid id)
        {
             var response = await _eventService.GetEventByIdAsync(id);
             if (response == null)
             {
              return NotFound(new SuccessResponse(404, "Event Does Not Exist"));
             }
              //delete

             var res = await _eventService.DeleteEventAsync(response);
             return Ok(new SuccessResponse(204, res));
        }
        
    }
}

