using Microsoft.EntityFrameworkCore;
using SupportDeskAppNew.Models;

namespace SupportDeskAppNew.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
