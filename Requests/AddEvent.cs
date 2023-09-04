
namespace EventManagement.Requests
{
    public class AddEvent
    {
        
        public string EventName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public DateTime dateTime { get; set; } = DateTime.Today;

        
        

        
    }
}
