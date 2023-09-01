using EventManagement.Models;
using EventManagement.Requests;

namespace EventManagement.Services.Iservices
{
    public interface IUserService
    {

        Task<string> AddUserAsync(Users user);
        Task<string> UpdateUserAsync(Users user);
        Task<string> DeleteUserAsync(Users user);
        Task<Users> GetUserByIdAsync(Guid Id);
        //buy ticket
        //Task<string> BuyTicket(BuyTicket buyTicket);

        Task<IEnumerable<Users>> GetAllUsersAsync();    

     
    }
}
