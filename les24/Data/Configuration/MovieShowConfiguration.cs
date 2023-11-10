using CinemaTheater.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTheater.Data.Configuration
{
    public class MovieShowConfiguration : IEntityTypeConfiguration<MovieShow>
    {
        public void Configure(EntityTypeBuilder<MovieShow> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.MovieId).HasColumnType("INT").IsRequired();
            builder.Property(m => m.ShowId).HasColumnType("INT").IsRequired();

            builder.HasOne(ms => ms.Movie)
                .WithMany(m => m.MovieShows)
                .HasForeignKey(ms => ms.MovieId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(ms => ms.Show)
                .WithMany(s => s.MovieShows)
                .HasForeignKey(ms => ms.ShowId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
