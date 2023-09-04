

namespace EventManagement.Requests
{
    public class BuyTicket
    {
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }   
    }
}
