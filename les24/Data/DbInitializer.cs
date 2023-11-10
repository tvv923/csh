using CinemaTheater.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTheater.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder _modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            _modelBuilder.Entity<Movie>(x =>
            {
                _modelBuilder.Entity<Show>(x =>
                {
                    x.HasData(new Show
                    {
                        Id = 1,
                        ShowTime = "11"
                    });
                    x.HasData(new Show
                    {
                        Id = 2,
                        ShowTime = "13"
                    });
                    x.HasData(new Show
                    {
                        Id = 3,
                        ShowTime = "15"
                    });
                    x.HasData(new Show
                    {
                        Id = 4,
                        ShowTime = "17"
                    });
                    x.HasData(new Show
                    {
                        Id = 5,
                        ShowTime = "19"
                    });
                    x.HasData(new Show
                    {
                        Id = 6,
                        ShowTime = "21"
                    });
                });

                x.HasData(new Movie
                {
                    Id = 1,
                    Name = "The Shawshank Redemption",
                    Director = "Frank Darabont",
                    Style = "Drama",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."
                });
                x.HasData(new Movie
                {
                    Id = 2,
                    Name = "The Godfather",
                    Director = "Francis Ford Coppola",
                    Style = "Crime, Drama",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
                });
                x.HasData(new Movie
                {
                    Id = 3,
                    Name = "The Dark Knight",
                    Director = "Christopher Nolan",
                    Style = "Action, Crime, Drama",
                    Description = "When the menace known as The Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham."
                });
                x.HasData(new Movie
                {
                    Id = 4,
                    Name = "Pulp Fiction",
                    Director = "Quentin Tarantino",
                    Style = "Crime, Drama",
                    Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption."
                });
                x.HasData(new Movie
                {
                    Id = 5,
                    Name = "Forrest Gump",
                    Director = "Robert Zemeckis",
                    Style = "Drama, Romance",
                    Description = "The presidencies of Kennedy and Johnson, the events of Vietnam, Watergate, and other historical events unfold through the perspective of an Alabama man with an IQ of 75."
                });
                x.HasData(new Movie
                {
                    Id = 6,
                    Name = "The Matrix",
                    Director = "The Wachowskis",
                    Style = "Action, Sci-Fi",
                    Description = "A computer programmer who discovers that reality as he knows it is a simulation created by machines to subjugate humanity."
                });
                x.HasData(new Movie
                {
                    Id = 7,
                    Name = "Inception",
                    Director = "Christopher Nolan",
                    Style = "Action, Adventure, Sci-Fi",
                    Description = "A thief who enters the dreams of others to obtain information is tasked with planting an idea into the mind of a CEO."
                });
                x.HasData(new Movie
                {
                    Id = 8,
                    Name = "The Lord of the Rings: The Fellowship of the Ring",
                    Director = "Peter Jackson",
                    Style = "Action, Adventure, Drama",
                    Description = "A young hobbit, Frodo, who has been entrusted with an ancient ring, must journey to Mount Doom to destroy it."
                });
                x.HasData(new Movie
                {
                    Id = 9,
                    Name = "The Godfather: Part II",
                    Director = "Francis Ford Coppola",
                    Style = "Crime, Drama",
                    Description = "The early life and career of Vito Corleone in 1920s New York is portrayed while his son, Michael, expands and tightens his grip on the family crime syndicate."
                });
                x.HasData(new Movie
                {
                    Id = 10,
                    Name = "Schindler's List",
                    Director = "Steven Spielberg",
                    Style = "Biography, Drama, History",
                    Description = "In German-occupied Poland during World War II, Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis."
                });
            });

            _modelBuilder.Entity<MovieShow>(x =>
            {
                x.HasData(new MovieShow
                {
                    Id = 1,
                    MovieId = 1,
                    ShowId = 1
                });
                x.HasData(new MovieShow
                {
                    Id = 2,
                    MovieId = 2,
                    ShowId = 1
                });
                x.HasData(new MovieShow
                {
                    Id = 3,
                    MovieId = 2,
                    ShowId = 2
                });
                x.HasData(new MovieShow
                {
                    Id = 4,
                    MovieId = 3,
                    ShowId = 3
                });
                x.HasData(new MovieShow
                {
                    Id = 5,
                    MovieId = 3,
                    ShowId = 4
                });
                x.HasData(new MovieShow
                {
                    Id = 6,
                    MovieId = 4,
                    ShowId = 5
                });
                x.HasData(new MovieShow
                {
                    Id = 7,
                    MovieId = 5,
                    ShowId = 6
                });
                x.HasData(new MovieShow
                {
                    Id = 8,
                    MovieId = 6,
                    ShowId = 1
                });
                x.HasData(new MovieShow
                {
                    Id = 9,
                    MovieId = 7,
                    ShowId = 3
                });
                x.HasData(new MovieShow
                {
                    Id = 10,
                    MovieId = 8,
                    ShowId = 4
                });
                x.HasData(new MovieShow
                {
                    Id = 11,
                    MovieId = 8,
                    ShowId = 6
                });
                x.HasData(new MovieShow
                {
                    Id = 12,
                    MovieId = 9,
                    ShowId = 2
                });
                x.HasData(new MovieShow
                {
                    Id = 13,
                    MovieId = 9,
                    ShowId = 5
                });
                x.HasData(new MovieShow
                {
                    Id = 14,
                    MovieId = 10,
                    ShowId = 1
                });
                x.HasData(new MovieShow
                {
                    Id = 15,
                    MovieId = 10,
                    ShowId = 3
                });
            });
        }
    }
}
