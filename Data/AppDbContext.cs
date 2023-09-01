using EventManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Data
{
    public class AppDbContext: DbContext

    {
        public DbSet <Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
