using EventManagement.Requests;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace EventManagement.Models
{
    public class Events
    {
        [Key]
        public Guid EventId { get; set; }
        public string EventName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public int Capacity { get; set; } = 5000;
        public int ticketAmount { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Today;


        public ICollection<Users> Users { get; set; }  = new List<Users>();

       

        

    }
}
