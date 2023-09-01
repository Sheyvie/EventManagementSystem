using System.Diagnostics.Contracts;

namespace EventManagement.Models
{
    public class Events
    {
        public Guid Id { get; set; }
        public string EventName { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public int Capacity { get; set; }
        public int ticketAmount { get; set; }

        public DateTime  DateTime { get; set; }

        public Users users { get; set; }

        public Guid UserId { get; set; }
    }
}
