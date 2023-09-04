using System.ComponentModel.DataAnnotations;

namespace EventManagement.Requests
{
    public class AddUser
    {
        //what a user will be requested to input

       [Required]
        public string Name { get; set; } = string.Empty;

       [Required]
       [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        
        
    }
}
