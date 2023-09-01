namespace EventManagement.Requests
{
    public class AddEvent
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public Guid UserId { get; set; }
    }
}
