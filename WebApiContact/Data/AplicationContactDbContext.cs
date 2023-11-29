using Microsoft.EntityFrameworkCore;
using WebApiContact.Models;

namespace WebApiContact.Data
{
    public class AplicationContactDbContext : DbContext
    {
        public AplicationContactDbContext(DbContextOptions<AplicationContactDbContext> optins) : base(optins) { }

        public DbSet<ContactModel> Contact { get; set; }
    }
}
