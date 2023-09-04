using EventManagement.Models;
using EventManagement.Requests;

namespace EventManagement.Services.Iservices
{
    public interface IUserService
    {

        Task<string> RegisterUser(Users users);
        Task<string> UpdateUserAsync(Users users);
        Task<string> DeleteUserAsync(Users users);
        Task<Users> GetUserByIdAsync(Guid id);

        Task<Users> GetUserByEmailAsync(String email);
        //buy ticket
        Task<string> BuyTicket(BuyTicket buyTicket);

        Task<IEnumerable<Users>> GetAllUsersAsync();    

     
    }
}
