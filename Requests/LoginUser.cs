namespace EventManagement.Requests
{
    public class LoginUser
    {

        public string Email{ get; set; }

        public string Password { get; set; } = string.Empty;
    }
}
