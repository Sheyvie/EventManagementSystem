using EventManagement.Models;

namespace EventManagement.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public List<Events> Events { get; set; } = new List<Events>();

    }
}
