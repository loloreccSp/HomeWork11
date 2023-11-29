using HomeWork11.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeWork11.Data
{
    public class ApplicationNoteDbContext : DbContext
    {
        public ApplicationNoteDbContext(DbContextOptions<ApplicationNoteDbContext> option) : base(option) 
        {

        }

        public DbSet<NoteModel> Note { get; set; }
    }
}
