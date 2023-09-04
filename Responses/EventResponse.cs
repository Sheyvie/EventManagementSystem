using EventManagement.Models;
using EventManagement.Requests;

namespace EventManagement.Responses
{
    public class EventResponse
    {

        public Guid EventId { get; set; }
        public string EventName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public List<Users> Users { get; set; } = new List<Users>();

       public ICollection<BuyTicket> BuyTickets { get; set; } =new List<BuyTicket>();
    }
}
