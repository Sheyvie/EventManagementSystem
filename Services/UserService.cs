using EventManagement.Data;
using EventManagement.Models;
using EventManagement.Requests;
using EventManagement.Services.Iservices;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddUserAsync(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return "User Created Successfully";
        }

        //public async Task<string> BuyTicket(BuyTicket buyTicket)
        //{
        //        var user = await _context.Users.Where(x => x.UserId == buyTicket.UserId).FirstOrDefaultAsync();
        //        var event = await _context.Events.Where(x => x.EventId == buyTicket.EventId).FirstOrDefaultAsync();
        //        if (user != null && event != null)
        //        {
        //            //add event or user
        //            user.Events.Add(course);
                   
        //            await _context.SaveChangesAsync();
        //            return "Event Purchased Successffully!!";
        //        }

        //        throw new Exception("Invalid Ids");
            
        //}

        public async Task<string> DeleteUserAsync(Users users)
        {
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return "User Deleted Successfully";
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {

            return await _context.Users.ToListAsync();
        }

        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public Task<string> UpdateUserAsync(Users users)
        {
            throw new NotImplementedException();
        }
    }
}
