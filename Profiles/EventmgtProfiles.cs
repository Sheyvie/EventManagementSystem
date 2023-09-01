using AutoMapper;
using EventManagement.Models;
using EventManagement.Requests;
using EventManagement.Responses;
namespace EventManagement.Profiles
{
    public class EventmgtProfiles : Profile
    {
        public EventmgtProfiles()
        {


            //user
            CreateMap<AddUser, Users>().ReverseMap();
            CreateMap<UserResponse, Users>().ReverseMap();





            //Event
            CreateMap<AddEvent, Events>().ReverseMap();
            CreateMap<UpdateEvent, Events>().ReverseMap();
            CreateMap<EventResponse, Events>().ReverseMap();
        }
    }
}
