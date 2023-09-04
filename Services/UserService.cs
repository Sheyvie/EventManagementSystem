
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
        public async Task<Users> GetUserByEmailAsync(String email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
        public async Task<string> RegisterUser(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();
            return "User Created Successfully";
        }

        public async Task<string> BuyTicket(BuyTicket buyTicket)
        {
            var users = await _context.Users.Where(x => x.UserId == buyTicket.UserId).FirstOrDefaultAsync();
            var events = await _context.Events.Where(x => x.EventId == buyTicket.EventId).FirstOrDefaultAsync();
                if (users != null && events!= null)
                {
                  //add event or user
                 
                  events.Users.Add(users); 

                  await _context.SaveChangesAsync();
                return "Ticket Purchased Successffully!!";
                }

                
                // Check if the event is full.
                if (events.Users.Count >= events.Capacity)
                {
                    return "The event is full.";
                }

            // Create and save the registration.
            var eventRegistration = new BuyTicket
            {
                UserId = users.UserId,
                EventId = events.EventId,

            };

                 return "Registration successful.";

                
          throw new Exception("Invalid Ids");
        }
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
            return await _context.Users.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task<string> UpdateUserAsync(Users users)
        {
            _context.Users.Update(users);
            await _context.SaveChangesAsync();
            return "User Updated Successfully";
        }
    }
}
