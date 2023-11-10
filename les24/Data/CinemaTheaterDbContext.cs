using CinemaTheater.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTheater.Data
{
    public class CinemaTheaterDbContext : DbContext
    {
        public CinemaTheaterDbContext(DbContextOptions<CinemaTheaterDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<MovieShow> MovieShows { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CinemaTheaterDbContext).Assembly);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}
