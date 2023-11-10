using Microsoft.EntityFrameworkCore;
using NoteExample.Models;

namespace NoteExample.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
