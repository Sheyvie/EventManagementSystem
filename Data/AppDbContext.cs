using EventManagement.Models;
using EventManagement.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManagement.Data
{
    public class AppDbContext: DbContext

    {

        public DbSet <Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    }
}
