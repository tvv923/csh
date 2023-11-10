using CinemaTheater.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaTheater.Data.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).HasColumnType("VARCHAR").IsRequired().HasMaxLength(50);
            builder.Property(m => m.Director).HasColumnType("VARCHAR").IsRequired().HasMaxLength(50);
            builder.Property(m => m.Style).HasColumnType("VARCHAR").IsRequired().HasMaxLength(50);
            builder.Property(m => m.Description).HasColumnType("VARCHAR").IsRequired().HasMaxLength(300);
        }
    }
}
