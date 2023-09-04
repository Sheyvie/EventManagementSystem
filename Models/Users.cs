using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class Users
    {
        [Key]
        public Guid UserId { get; set; }

        public string Name { get; set; } =string.Empty;
        public int phoneNumber { get; set; }
        public string Email { get; set; }= string.Empty;

        public string Role { get; set; } = "User";

        public string Password { get; set; } = string.Empty;

        
        public ICollection<Events> Events { get; set; } = new List<Events>();   




    }
}
