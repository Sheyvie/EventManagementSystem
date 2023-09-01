namespace EventManagement.Models
{
    public class Users
    {
        
        public Guid Id { get; set; }

        public string Name { get; set; } =string.Empty;
        public int phoneNumber { get; set; }
        public string Email { get; set; }= string.Empty;

        public List<Events> Events { get; set; }
    }
}
